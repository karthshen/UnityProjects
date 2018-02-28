using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 

{
	[SerializeField] private float moveSpeed = 1.0f;
	[SerializeField] private float rotateSpeed = 4.0f;
	[SerializeField] private float jumpForce = 20.0f;

	private GameObject[] coins;
	private int coinsCollected;

	private Rigidbody rbd;
	private bool bWallClimb = false;
	private Vector3 initialRotation;
	private Vector3 initialPosition;
	private bool bIsOnGround = true;

	private void Start ()
	{
		this.rbd = this.gameObject.GetComponent<Rigidbody> ();
		coins = GameObject.FindGameObjectsWithTag ("Coin");
		coinsCollected = 0;
		Debug.Log (coins.Length + " coins left to collect\n");

		initialRotation = this.transform.rotation.eulerAngles;
		initialPosition = this.transform.position;
	}

	private void FixedUpdate ()
	{
		float x = Input.GetAxis ("Horizontal");

		float z = Input.GetAxis ("Vertical");

		float y = Input.GetAxis ("Climb");

		if (bWallClimb)
			WallClimbing (y);

		FloorWalking (x, z);
		if (Input.GetKeyDown (KeyCode.Mouse1))
			this.gameObject.transform.eulerAngles = initialRotation;

		if (Input.GetKeyDown (KeyCode.Space) && bIsOnGround) {
			this.rbd.AddForce (Vector3.up * jumpForce);
		}


		if (this.transform.position.y < -1)
			this.transform.position = initialPosition;
	}

	private void FloorWalking(float x, float z)
	{
		/*
		Vector3 movement = new Vector3 (0, this.rbd.velocity.y, z);

		this.rbd.velocity = movement;
		if (Input.GetKey (KeyCode.A))
			this.gameObject.transform.Rotate(0,rotateSpeed,0);
		else if (Input.GetKey (KeyCode.D))
			this.gameObject.transform.Rotate(0,-rotateSpeed,0);
        */

		z = z * moveSpeed * Time.deltaTime;
	
		x = x * moveSpeed * Time.deltaTime * 0.75f;

		this.gameObject.transform.Translate (x, 0, z);


		float rotateY = 0;
		rotateY = Input.GetAxis ("RotatePlayer");

		this.gameObject.transform.Rotate (0, rotateSpeed* rotateY, 0);

		this.gameObject.transform.rotation = Quaternion.Euler (0, this.gameObject.transform.rotation.eulerAngles.y, 0);
	}

	private void WallClimbing(float y)
	{
		if (bWallClimb) {
			Vector3 movement = new Vector3 (0, y, 0);
			this.rbd.velocity = movement;
		}
	}

	private void OnTriggerEnter(Collider collider){
		if (collider.tag == "Coin") {
			GameObject.Destroy (collider.gameObject);
			coinsCollected++;
			//For some reason my game is recgonizing picking up 1 coin as picking up 3
			Debug.Log (coinsCollected/3 + " coins collected, " + (coins.Length - coinsCollected/3) + " coins left\n");

			//when all coins collected, quit.
			if ((coins.Length - coinsCollected / 3) == 0)
				Application.Quit ();
		}
	}

	private void OnCollisionEnter(Collision collision){
		bIsOnGround = true;
	}

	private void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.tag == "Wall"){
			bWallClimb = true;
			this.rbd.useGravity = false;
		}
		bIsOnGround = true;

	}

	private void OnCollisionExit (Collision collision)
	{
		bWallClimb = false;
		this.rbd.useGravity = true;
		if(collision.gameObject.tag == "Wall")
			//this.rbd.velocity = new Vector3 (0, 0, 0);
		this.gameObject.transform.Rotate (0, 0, 0);
		this.bIsOnGround = false;
	}

	private bool isOut(){
		if (this.gameObject.transform.position.x > 0 || this.gameObject.transform.position.x < -12 ||
		    this.gameObject.transform.position.z > 3.682 || this.gameObject.transform.position.z < -8.24)
			return true;
		else
			return false;
	}
}

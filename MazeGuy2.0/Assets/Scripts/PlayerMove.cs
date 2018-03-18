using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 

{
	[SerializeField] private float moveSpeed = 10.0f;

	private Rigidbody rbd;

	private void Start ()
	{
		this.rbd = this.gameObject.GetComponent<Rigidbody> ();
	}

	private void FixedUpdate ()
	{
		//If esc is pressed, exit
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
			Debug.Log ("Game is Exited by Player");
		}


		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (x*moveSpeed, 0.0f, y*moveSpeed);

		this.rbd.AddForce (movement);
	}

}

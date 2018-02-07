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
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (x, 0.0f, y);

		this.rbd.AddForce (movement * moveSpeed);
	}

}

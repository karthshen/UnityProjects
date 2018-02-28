using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

	[SerializeField]
	private float countDownTime = 3.0f;
	[SerializeField]
	private float movementSpeed = 1.0f;

	private bool bGoingDown = true;
	private Rigidbody rbd;
	private float time;
	// Use this for initialization
	void Start () {
		this.rbd = this.gameObject.GetComponent<Rigidbody>();
		time = countDownTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (countDownTime > 0) {
			countDownTime = countDownTime - Time.deltaTime;
		} 
		else {
			if (this.gameObject.transform.position.y < 0.70f) {
				countDownTime = time;
				bGoingDown = false; //going up
			} else if (this.gameObject.transform.position.y > 6f) {
				bGoingDown = true; //going down
				countDownTime = time;
			}
			if (bGoingDown) {
				this.gameObject.transform.Translate (0, -movementSpeed * Time.deltaTime, 0);
			} else if (bGoingDown == false) {
				this.gameObject.transform.Translate (0, movementSpeed * Time.deltaTime, 0);
			}

		}
	}
}

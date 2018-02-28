using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour 
{

	private void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Application.Quit ();
			Debug.Log ("Game is finished");
		}
	}
}

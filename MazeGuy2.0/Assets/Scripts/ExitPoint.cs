using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour 
{

	private void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			SceneManager.LoadScene (2);
		}
	}
}

using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	[SerializeField] float cameraRotateSpeed = 1.5f;

    public GameObject player;

    private Vector3 offset;

	private Vector3 initialRotation;
	private Vector3 initialRotationPlayer;

    void Start()
    {
		this.transform.position = player.transform.position;
        offset = transform.position - player.transform.position;

		initialRotation = this.transform.rotation.eulerAngles;
		initialRotationPlayer = player.transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
			this.gameObject.transform.eulerAngles = initialRotation;
			player.transform.eulerAngles = initialRotationPlayer;
		}
		

        transform.position = player.transform.position + offset;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {

			float y = Input.GetAxis ("CameraRotateHori");

			this.gameObject.transform.Rotate (0, cameraRotateSpeed * y, 0);
		} else if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow))) {
			float z = Input.GetAxis ("CameraRotateVert");

			this.gameObject.transform.Rotate (0, 0, cameraRotateSpeed * z);

		}
    }
}
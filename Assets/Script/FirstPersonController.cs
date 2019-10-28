using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	public float basemovementSpeed = 5.0f ;
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	float verticalRotation = 0;

	public float upDownRange = 60.0f;
	public float sprintSpeed = 10.0f;
	float VerticalVelocity = 0;

	CharacterController characterController;


	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		 characterController = GetComponent<CharacterController> ();
	

	}
	
	// Update is called once per frame
	void Update () {



		// Rotate

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;

	
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);


		// movememt 
		float forwardspeed = Input.GetAxis ("Vertical") * movementSpeed ;
		float sidespeed = Input.GetAxis ("Horizontal") * movementSpeed ;

		VerticalVelocity += Physics.gravity.y * Time.deltaTime;


		// Jumping 

		if (  characterController.isGrounded && Input.GetButton ("Jump")) {
			VerticalVelocity = jumpSpeed;
				
		}

		// Restart
		if ( Input.GetButton ("Submit")) {

			SceneManager.LoadScene("1");

		}

		if ( Input.GetButton ("Cancel")) {

			Application.Quit ();

		}

		// Sprinting 
		if (characterController.isGrounded && Input.GetButton ("Fire3")) 
			movementSpeed = sprintSpeed;
		 else 
			movementSpeed = basemovementSpeed;


			Vector3 speed = new Vector3 (sidespeed, VerticalVelocity, forwardspeed);
        
			speed = transform.rotation * speed;
	


			characterController.Move (speed * Time.deltaTime);
		


}
}

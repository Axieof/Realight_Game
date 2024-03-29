﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{

	//public CharacterController controller;
	public float speed = 12f;
	/*
	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;  // Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
	*/
	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void FixedUpdate()
	{
		SendInputToServer();

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		//controller.Move(move * speed * Time.deltaTime);
		/*
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))  // If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("w"))  // If the player is pressing the "w" key
		{
			// Add a force to the left
			rb.AddForce(0, 0, forwardForce * Time.deltaTime,ForceMode.VelocityChange);
		}

		if (Input.GetKey("s"))  // If the player is pressing the "s" key
		{
			// Add a force to the left
			rb.AddForce(0, 0, - forwardForce * Time.deltaTime,ForceMode.VelocityChange);
		}
		*/

	}

	private void SendInputToServer()
	{
		bool[] _inputs = new bool[]
		{
			Input.GetKey(KeyCode.W),
			Input.GetKey(KeyCode.S),
			Input.GetKey(KeyCode.A),
			Input.GetKey(KeyCode.D),
		};

		ClientSend.PlayerMovement(_inputs);
	}
}
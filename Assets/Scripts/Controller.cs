using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	// public variables
	public float moveSpeed = 3.0f;
	public float gravity = 9.81f;
	public float jumpPower = 2;

	private CharacterController myController;
	private float k_GroundRayLength = 1.1f;
//	private Rigidbody m_Rigidbody;

	// Use this for initialization
	void Start () {
		// store a reference to the CharacterController component on this gameObject
		// it is much more efficient to use GetComponent() once in Start and store
		// the result rather than continually use etComponent() in the Update function
		myController = gameObject.GetComponent<CharacterController>();
//		m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Determine how much should move in the z-direction
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

		// Determine how much should move in the x-direction
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

		// Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
		Vector3 movement = transform.TransformDirection(movementZ+movementX);
		
		// Apply gravity (so the object will fall if not grounded)
		movement.y -= gravity * Time.deltaTime;

//		Debug.Log ("Movement Vector = " + movement);

		// Actually move the character controller in the movement direction
		myController.Move(movement);

		// If on the ground and jump is pressed...
//		if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && Input.GetButtonDown("Jump"))
//		{
//			Debug.Log ("JUMP NOW");
//			// ... add force in upwards.
//			m_Rigidbody.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
//		}
	}
}

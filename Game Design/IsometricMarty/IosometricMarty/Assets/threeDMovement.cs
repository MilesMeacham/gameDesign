using UnityEngine;
using System.Collections;

public class threeDMovement : MonoBehaviour {

	public float moveVelocity = 7f;
	public float walkMoveVelocity = 7f;
	public float runMoveVelocity = 10f;
	public float jumpForce = 5f;

	public bool doubleJumped;

	public bool grounded;
	public LayerMask whatIsGround;

	public GameObject startingSpawnPoint;
	public GameObject throwingKnife;
	
	// Use this for initialization
	void Start () {
		//currentCheckpoint = new Vector2 (startingSpawnPoint.transform.position.x, startingSpawnPoint.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void FixedUpdate () {
		//grounded = Physics.OverlapSphere
	}

	
	void Movement () {
		
		
		
		if(Input.GetKey (KeyCode.LeftShift)){
			moveVelocity = runMoveVelocity;
		} else {
			moveVelocity = walkMoveVelocity;
		}

		
		//Move player on input and stop him when user lets go of key
		if(Input.GetKeyDown (KeyCode.D)) {
			//GetComponent<Rigidbody>().transform.localRotation = new Vector3 ((GetComponent<Rigidbody>().transform.localRotation.x + 90), GetComponent<Rigidbody>().transform.localRotation.y, GetComponent<Rigidbody>().transform.localRotation.z);  
			//GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);
			GetComponent<Rigidbody>().transform.localPosition = new Vector3 ((GetComponent<Rigidbody>().transform.localPosition.x + 1), GetComponent<Rigidbody>().transform.localPosition.y, GetComponent<Rigidbody>().transform.localPosition.z);
		}

		if(Input.GetKeyUp (KeyCode.D))
			GetComponent<Rigidbody>().velocity = new Vector2(0, GetComponent<Rigidbody>().velocity.y);
		
		if(Input.GetKey (KeyCode.A))
			GetComponent<Rigidbody>().velocity = new Vector2(-moveVelocity, GetComponent<Rigidbody>().velocity.y);
		if(Input.GetKeyUp (KeyCode.A))
			GetComponent<Rigidbody>().velocity = new Vector2(0, GetComponent<Rigidbody>().velocity.y);

		if(Input.GetKey (KeyCode.W))
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.y, moveVelocity);
		if(Input.GetKeyUp (KeyCode.W))
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.y, 0);

		if(Input.GetKey (KeyCode.S))
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.y, -moveVelocity);
		if(Input.GetKeyUp (KeyCode.S))
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.y, 0);
		
		
		//Jump
		//if ((Input.GetKeyDown (KeyCode.Space) && groundedLeft) || (Input.GetKeyDown (KeyCode.Space) && groundedRight))
		//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
		
		//Double Jump
		//if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !groundedLeft && !groundedRight) {
		//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
		//	doubleJumped = true;
		//}

	}

}
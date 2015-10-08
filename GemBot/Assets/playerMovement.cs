using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public Rigidbody rb;

	public int speed = 5;
	public int jumpForce = 10;

	public float moveVelocity;

	public bool grounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundCheckRadius = 0.1f;

	private Vector3 bodyUp;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
		Movement ();
	}

	void FixedUpdate () {

	}

	void Movement () {
			rb.MovePosition (rb.position + transform.TransformDirection (Input.GetAxisRaw ("Horizontal"), 0, 0) * speed * Time.deltaTime);
			//rb.velocity = transform.TransformDirection (new Vector3 (speed, 0, 0));

	}

	void Jump () {

		if (grounded && Input.GetKey (KeyCode.Space)) {
			rb.velocity = transform.TransformDirection (new Vector3 (0, jumpForce, 0));
		}
	}

	void OnCollisionStay (Collision collider){
		if (collider.gameObject.layer == 8)
			grounded = true;
	}

	void OnCollisionExit (Collision collider){
		if (collider.gameObject.layer == 8)
			grounded = false;
	}

}

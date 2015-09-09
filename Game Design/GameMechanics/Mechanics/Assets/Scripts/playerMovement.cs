using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveVelocity = 7f;
	public float jumpForce = 5f;

	public bool grounded;
	public bool doubleJumped;
	public bool crouched = false;

	public Transform lineGround;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		GroundCheck ();
		Movement ();
	
	}

	void GroundCheck () {
		Debug.DrawLine (this.transform.position, lineGround.position, Color.green);

		grounded = Physics2D.Linecast (this.transform.position, lineGround.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (grounded)
			doubleJumped = false;


	}
	

	void Movement () {

		//Turn player Sprite the direction he is moving
		//Leave him facing the way he last was traveling
		if (GetComponent<Rigidbody2D> ().velocity.x < -1) {
			transform.localScale = new Vector2 (-1, transform.localScale.y);
		} else if (GetComponent<Rigidbody2D> ().velocity.x > 1) {
			transform.localScale = new Vector2 (1, transform.localScale.y);
		} else {
			transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y);
		}

			
		//Move player on input and stop him when user lets go of key
		if(Input.GetKey (KeyCode.D))
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		if(Input.GetKeyUp (KeyCode.D))
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

		if(Input.GetKey (KeyCode.A))
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		if(Input.GetKeyUp (KeyCode.A))
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);


		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);

		//Double Jump
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
			doubleJumped = true;
		}

		//crouch
		if (Input.GetKey (KeyCode.S)) {
			crouched = true;
		    anim.SetBool("crouched", crouched);
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			crouched = false;
			anim.SetBool("crouched", crouched);
		}


		
		
	}



}

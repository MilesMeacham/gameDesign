using UnityEngine;
using System.Collections;

public class threeDMovement : MonoBehaviour {

	public float moveVelocity = 5f;
	public float walkMoveVelocity = 5f;
	public float runMoveVelocity = 7f;
	public float jumpForce = 7f;
	public float rotateSpeed = 5f;
	public float boostForce = 2000f;

	public bool doubleJumped;
	public bool grounded;
	public bool currentlyJumping;

	public Vector3 spawnPoint;

	public gravityBody myGravityBody;

	

	Rigidbody player;
	
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
		spawnPoint = new Vector3 (player.position.x, player.position.y, player.position.z);
		myGravityBody = FindObjectOfType<gravityBody> ();
	}

	void Update () {

		if(Input.GetKeyDown (KeyCode.Space) && grounded) {
			player.AddForce(transform.up * jumpForce);
		}


/*		//jump
		if(Input.GetKeyDown (KeyCode.Space) && grounded){
			player.velocity = new Vector3 (player.velocity.x, jumpForce, player.velocity.z);
			doubleJumped = false;
			currentlyJumping = true;
			grounded = false;
		}
		if (Input.GetKeyUp (KeyCode.Space) && !grounded)
			currentlyJumping = false;
		
		//double Jump
		if (Input.GetKey (KeyCode.Space) && !doubleJumped && !grounded && !currentlyJumping) {
			player.velocity = new Vector3 (player.velocity.x, jumpForce, player.velocity.z);
			doubleJumped = true;
		}
*/	
	}

	void FixedUpdate () {
		Movement ();
	}

	
	void Movement () {
		

		//run
		if(Input.GetKey (KeyCode.LeftShift)){
			moveVelocity = runMoveVelocity;
		} else {
			moveVelocity = walkMoveVelocity;
		}

		//Movement
		if (Input.GetKey (KeyCode.W))
			transform.Translate ((Vector3.forward) * moveVelocity * Time.deltaTime);
		if(Input.GetKey (KeyCode.S))
			transform.Translate ((Vector3.back) * moveVelocity * Time.deltaTime);
		if (Input.GetKey (KeyCode.A))
			player.transform.Rotate (Vector3.down * rotateSpeed);
		if(Input.GetKey (KeyCode.D))
			player.transform.Rotate (Vector3.up * rotateSpeed);


 
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == 8) {
			grounded = true;
			currentlyJumping = false;
			doubleJumped = false;
		}

		if (other.gameObject.layer == 9)
			StartCoroutine ("Respawn");
		
		if (other.gameObject.layer == 10)
			myGravityBody.ChangeGravity(other);

		if (other.gameObject.layer == 11) 
			StartCoroutine ("Boost");
			


	}

	public IEnumerator Boost () {
		FindObjectOfType<threeDMovement> ().enabled = false;
	

	//	yield return new WaitForSeconds (1);

		player.AddForce(transform.up * boostForce);

		yield return new WaitForSeconds (1);

		FindObjectOfType<threeDMovement> ().enabled = true;
	}

	public IEnumerator Respawn () {

		GetComponent<Renderer> ().enabled = false;
		player.velocity = Vector3.zero;
		player.useGravity = false;
		FindObjectOfType<threeDMovement> ().enabled = false;

		yield return new WaitForSeconds (2);

		player.position = spawnPoint;
		player.useGravity = true;
		GetComponent<Renderer> ().enabled = true;
		FindObjectOfType<threeDMovement> ().enabled = true;


	}

}
using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public cameraFollow myCam;

	public float moveVelocity = 7f;
	public float walkMoveVelocity = 7f;
	public float runMoveVelocity = 10f;
	public float jumpForce = 5f;

	public bool groundedLeft;
	public bool ceilingedLeft;
	public bool groundedRight;
	public bool ceilingedRight;
	public bool doubleJumped;
	public bool crouched = false;

	public Transform lineGroundLeft;
	public Transform lineCeilingLeft;
	public Transform lineGroundRight;
	public Transform lineCeilingRight;
	public Transform throwingPoint;	

	public Vector2 currentCheckpoint;

	private Animator anim;

	public GameObject startingSpawnPoint;
	public GameObject throwingKnife;

	// Use this for initialization
	void Start () {
		//startingSpawnPoint = GameObject.Find ("StartingSpawnPoint");
		anim = GetComponent<Animator> ();
		myCam = FindObjectOfType<cameraFollow> ();
		currentCheckpoint = new Vector2 (startingSpawnPoint.transform.position.x, startingSpawnPoint.transform.position.y);
		//throwingKnife = GameObject.Find ("throwingKnife");
	}
	
	// Update is called once per frame
	void Update () {

		RayCasting ();
		Movement ();
		Attack ();
	
	}


	//raycasting to see if player is grounded or if there is a ceiling above his head
	void RayCasting () {
		Debug.DrawLine (this.transform.position, lineCeilingLeft.position, Color.green);
		Debug.DrawLine (this.transform.position, lineGroundLeft.position, Color.green);
		Debug.DrawLine (this.transform.position, lineCeilingRight.position, Color.green);
		Debug.DrawLine (this.transform.position, lineGroundRight.position, Color.green);

		groundedLeft = Physics2D.Linecast (this.transform.position, lineGroundLeft.position, 1 << LayerMask.NameToLayer ("Ground"));
		ceilingedLeft = Physics2D.Linecast (this.transform.position, lineCeilingLeft.position, 1 << LayerMask.NameToLayer ("Ground"));
		groundedRight = Physics2D.Linecast (this.transform.position, lineGroundRight.position, 1 << LayerMask.NameToLayer ("Ground"));
		ceilingedRight = Physics2D.Linecast (this.transform.position, lineCeilingRight.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (groundedLeft || groundedRight)
			doubleJumped = false;


	}

	void Attack () {
		if(Input.GetKeyDown (KeyCode.F)) {
			Instantiate (throwingKnife, throwingPoint.position, throwingPoint.rotation);
		}

	}
	

	void Movement () {



		if(Input.GetKey (KeyCode.LeftShift)){
			moveVelocity = runMoveVelocity;
		} else {
			moveVelocity = walkMoveVelocity;
		}


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
		if ((Input.GetKeyDown (KeyCode.Space) && groundedLeft) || (Input.GetKeyDown (KeyCode.Space) && groundedRight))
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);

		//Double Jump
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !groundedLeft && !groundedRight) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
			doubleJumped = true;
		}

		//crouch
		if (Input.GetKey (KeyCode.S)) {
			crouched = true;
		    anim.SetBool("crouched", crouched);
		}
		if ((Input.GetKeyUp (KeyCode.S) && !ceilingedLeft) && (Input.GetKeyUp (KeyCode.S) && !ceilingedRight)){
			crouched = false;
			anim.SetBool("crouched", crouched);
		}
		if ((!Input.GetKey (KeyCode.S) && !ceilingedLeft) && (!Input.GetKey (KeyCode.S) && !ceilingedRight)) {
			crouched = false;
			anim.SetBool("crouched", crouched);
		}


		
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.layer == 11)
			StartCoroutine("Respawn");

		if (col.gameObject.layer == 9)
			currentCheckpoint = new Vector2 (col.transform.position.x, col.transform.position.y);
		
		//if (col.name == "StartingSpawnPoint")
		//	currentCheckpoint = new Vector2 (col.transform.position.x, col.transform.position.y);
	

	}

	public IEnumerator Respawn(){
		GetComponent<Renderer> ().enabled = false;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		yield return new WaitForSeconds(2);

		GetComponent<Rigidbody2D> ().transform.position = new Vector2 (currentCheckpoint.x, currentCheckpoint.y);
		transform.localScale = new Vector2 (1, transform.localScale.y);
		GetComponent<Rigidbody2D> ().gravityScale = 1;
		GetComponent<Renderer> ().enabled = true;
	
	}


}

using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public Rigidbody rb;

	public int speed = 5;
	public int jumpForce = 10;
	public int moveVelocity = 10;

	//public float moveVelocity;

	public bool grounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundCheckRadius = 0.1f;

	private Vector3 bodyUp;

	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		Jump ();
		SwipeMovement ();
	}

	void SwipeMovement () {
		if (Input.touchCount > 0) 
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
				
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				
				if (swipeDistVertical > minSwipeDistY) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
					{
						//Jump ();
						rb.velocity = transform.TransformDirection (new Vector3 (0, jumpForce, 0));
					}
					else if (swipeValue < 0)//down swipe
					{
						rb.velocity = transform.TransformDirection (new Vector3 (0, -jumpForce, 0));	
						//Shrink ();
					}		
				}
				
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0)//right swipe
					{
						rb.velocity = transform.TransformDirection (new Vector3 (moveVelocity, 0, 0));
						//MoveRight ();
					}	
					else if (swipeValue < 0)//left swipe
					{
							//MoveLeft ();
						rb.velocity = (rb.position + transform.TransformDirection (-moveVelocity, 0, 0) * speed * Time.deltaTime);
					}		
				}
				break;
			}
		}
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

using UnityEngine;
using System.Collections;

public class throwingKnifeScript : MonoBehaviour {

	public float throwVelocity;
	public int originalThrowVelocity = 10;
	public float knifeDuration = 1f;

	playerMovement player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playerMovement> ();
		throwVelocity = (originalThrowVelocity + player.GetComponent<Rigidbody2D> ().velocity.x);

		if (player.transform.localScale.x < 0){
			throwVelocity = -originalThrowVelocity + player.GetComponent<Rigidbody2D> ().velocity.x;
			GetComponent<Transform> ().localScale = new Vector2 (-1.680365f, transform.localScale.y);
		}

	
	}
	
	// Update is called once per frame
	void Update () {




		GetComponent<Rigidbody2D> ().velocity = new Vector2 (throwVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		StartCoroutine ("DestroyKnife");
			
	}
		    	

	public IEnumerator DestroyKnife(){
		yield return new WaitForSeconds (knifeDuration);
		Destroy (gameObject);
	}
}

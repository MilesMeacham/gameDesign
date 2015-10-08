using UnityEngine;
using System.Collections;

public class pickUps : MonoBehaviour {
	
	public float topLimit = 30f;
	public float downLimit = -30f;
	public float speed = 80f;
	private float direction = 1f;
	public Vector3 rotate;


	void Update () {
		rotate = new Vector3(direction * speed * Time.deltaTime, 0, 0);
		transform.Rotate (rotate);
	}


	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == 12) {
			Destroy(gameObject);
		}
		
		
	}



}

using UnityEngine;
using System.Collections;

public class obstacleRotate : MonoBehaviour {

	public float topLimit = 30f;
	public float downLimit = -30f;
	public float speed = 80f;
	private float direction = 1f;
	public Vector3 rotate;
	
	
	void Start () {
		
	}
	
	void Update () {
		if (transform.rotation.x > topLimit) {
			direction = -1;
			Debug.Log ("Top Limit Reached");
		}
		else if (transform.rotation.x < downLimit) {
			direction = 1;
			Debug.Log ("Down Limit Reached");
		}


		rotate = new Vector3(direction * speed * Time.deltaTime, 0, 0);
		transform.Rotate (rotate);
	}

}

using UnityEngine;
using System.Collections;

public class springBounce : MonoBehaviour {

	public Animator anim;

	public bool bounce = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void onTriggerEnter (Collider other){
		Debug.Log ("Bounce");
		if (other.gameObject.layer == 12) {
			bounce = true;
			Debug.Log ("Bounce");
			anim.SetBool ("bounce", bounce);
		}


	}

}

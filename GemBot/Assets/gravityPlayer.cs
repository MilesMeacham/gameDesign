using UnityEngine;
using System.Collections;

public class gravityPlayer : MonoBehaviour {

	public gravityAttractor attractor;
	
	private Transform myTransform;
	
	// Use this for initialization
	void Start () {
		attractor = FindObjectOfType<gravityAttractor> ();
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		GetComponent<Rigidbody> ().useGravity = false;
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		attractor.Attract (myTransform);
	}
	
	public void ChangeGravity (Collider other) {
		attractor = other.gameObject.GetComponent<gravityAttractor>();
		
		
		
	}
	
}

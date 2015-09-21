using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

	public threeDMovement player;
	public gravityAttractor currentGravity;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<threeDMovement> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

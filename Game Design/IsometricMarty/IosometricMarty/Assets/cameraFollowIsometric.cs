using UnityEngine;
using System.Collections;

public class cameraFollowIsometric : MonoBehaviour {


	public bool isFollowing;
	public threeDMovement player;

	public float xOffset = 0;
	public float zOffset = -5.8f;
	public float yOffset = 5.8f;

	// Use this for initialization
	void Start () {
		isFollowing = true;
		player = FindObjectOfType<threeDMovement> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isFollowing)
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
	}
}

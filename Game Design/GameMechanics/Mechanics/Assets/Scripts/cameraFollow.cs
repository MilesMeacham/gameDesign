using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	
	public playerMovement player;
	
	public bool isFollowing;
	
	public float xOffset;
	public float yOffset;
	
	public GUISkin myGuiSkin;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playerMovement> ();
		
		isFollowing = true;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing)
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + 2 + yOffset, transform.position.z);
		
		
	}

}
using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {
	
	public bool activated = false;
	
	void OnTriggerEnter2D(Collider2D other)	{
		if (other.gameObject.layer == 10) {
			activated = true;
			GetComponent<Animator>().SetBool("activated", activated);
			//GetComponent<Animation>().Play("checkpointActivated");
		}


	}

}

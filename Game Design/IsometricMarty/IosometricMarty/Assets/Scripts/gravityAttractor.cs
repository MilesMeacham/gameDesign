using UnityEngine;
using System.Collections;

public class gravityAttractor : MonoBehaviour {

	public float gravity = -10;

	public void Attract(Transform body) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		//body.rigidbody.Addforce (gravityUp * gravity);
		body.GetComponent<Rigidbody> ().AddForce (gravityUp * gravity);




		Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp (body.rotation, targetRotation, 5 * Time.deltaTime);
	}



}

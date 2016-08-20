using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;

	//updates once per physics action
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical= Input.GetAxis ("Vertical")* -1;

		Vector3 movement = new Vector3(moveVertical,0.0f, moveHorizontal);
		GetComponent<Rigidbody>().velocity= movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3
			(Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 0.0f, 
			 Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));
	}
}

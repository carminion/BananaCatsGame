using UnityEngine;
using System.Collections;

public class PointsOnContact : MonoBehaviour {
	
	//public GameObject pointAddEffect;
	//public GameObject playerPointAddEffect;
	public int scoreValue;
	private GameController gameController;

	void Start ()
		{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");	
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
			}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
			}
		}
	void OnTriggerEnter(Collider other) {
		/*if (other.tag == "Boundary" || other.tag == "Hazard") {
			return;
		}
		//Instantiate (pointAddEffect, transform.position, transform.rotation); */
		if (other.tag == "Player") {
			//Instantiate (playerPointAddEffect, other.transform.position, other.transform.rotation);
		
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
		}
	}
}

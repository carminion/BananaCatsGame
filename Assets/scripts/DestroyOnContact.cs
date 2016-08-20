using UnityEngine;
using System.Collections;
using System;


public class DestroyOnContact : MonoBehaviour {

	//public bool gameOver;
	//public score;
	public GameController gameController;
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag == "Bonus") {
			return;
		}

		if (other.tag == "Player") {
			Instantiate (explosion, transform.position, transform.rotation);

			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Destroy (gameObject);

			Destroy(explosion);
			Destroy (playerExplosion);
			gameController.GameOver();

		
		}




	
		
	}
}

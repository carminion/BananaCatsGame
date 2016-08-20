using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject bonus;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Vector3 bonusValues;
	public float bonusWait;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText scoreText;
	private bool gameOver;
	private bool restart;
	public int score;



	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves () 
	 {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-3.8f, 3.8f));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				//yield return new WaitForSeconds (spawnWait);

				//for (int i = 0; i < hazardCount; i++) {
				Vector3 bonusPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-3.8f, 3.8f));
				Quaternion bonusRotation = Quaternion.identity;
				Instantiate (bonus, bonusPosition, bonusRotation);
				yield return new WaitForSeconds (spawnWait);
					
				//}

			}

			yield return new WaitForSeconds (waveWait);
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				//Destroy(
				break;
			}
		}

	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public  void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		Application.LoadLevel("game_over_scene");
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
}

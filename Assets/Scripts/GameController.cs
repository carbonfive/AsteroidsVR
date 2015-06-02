using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	private Text gameOverText;
	private Text restartText;
	private GameObject crosshair;
	public static bool gameOver;
	public GameObject asteroid;
	
	void Start () {
		GameObject gameOverTextObject = GameObject.Find ("GameOverText");
		gameOverText = gameOverTextObject.GetComponent <Text>();

		GameObject restartTextObject = GameObject.Find ("RestartText");
		restartText = restartTextObject.GetComponent <Text>();

		crosshair = GameObject.Find("Crosshair");
		gameOver = false;

		for(int i = 0; i < 6; i++) {
			SpawnAsteroid();
		}

		// A MonoBehavior function that takes a function name, when to first invoke it, and how often to repeat it
		InvokeRepeating ("SpawnAsteroid", 0, 10f);
	}

	void Update() {
		if (gameOver && Cardboard.SDK.Triggered) {
			// Reload the current level
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void SpawnAsteroid() {
		// Select a random point in a sphere
		Vector3 randomPosition = Random.onUnitSphere;

		// Move the point 20 units away 
		Vector3 scaledPosition = randomPosition * 20f;

		// Make sure it is in front of the camera (z-axis is positive)
		Vector3 spawnPosition = new Vector3 (scaledPosition.x, scaledPosition.y, Mathf.Abs (scaledPosition.z));

		// Corresponds to "no rotation"
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (asteroid, spawnPosition, spawnRotation);
	}

	public void GameOver() {
		CancelInvoke ("SpawnAsteroid");

		// Display Game Over and Restart text
		gameOverText.text = "Game Over";
		restartText.text = "Trigger to Restart";
		Destroy (crosshair);

		gameOver = true;
	}
}

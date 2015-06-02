using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	private GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.Find ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();

	}

	// Requires a Rigidbody to be on one of the GameObjects
	void OnTriggerEnter (Collider other)
	{
		gameController.GameOver();
		Destroy (gameObject);
	}
}
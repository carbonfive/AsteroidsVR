using UnityEngine;
using System.Collections;

public class AsteroidController: MonoBehaviour {
	public GameObject explosion;
	
	void Update () {
		if (GameController.gameOver == false) {

			// Colliders have a function called Raycast that takes the a Ray, a RaycastHit, and a maxDistance float
			// 'out' assigns the variable hit with the object that was hit
			RaycastHit hit;
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			bool isLookedAt = GetComponent<CapsuleCollider> ().Raycast (ray, out hit, Mathf.Infinity);

            // When the Asteroid is looked at and the magnet is triggered, blow up the Asteroid
			if (Cardboard.SDK.Triggered && isLookedAt) {
	  			ScoreManager.score += 5;
				Instantiate (explosion, hit.transform.position, hit.transform.rotation);
				Destroy (gameObject);
			}
		}
	}	
}

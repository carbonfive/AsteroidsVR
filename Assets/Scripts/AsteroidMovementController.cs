using UnityEngine;
using System.Collections;

public class AsteroidMovementController : MonoBehaviour {
	private Transform target;
	public float speed;
	
	void Start () {
		target = Camera.main.transform;
	}

	void Update () {
		if (GameController.gameOver == false) {

			// Moves the Asteroid toward the camera at a given speed
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
}

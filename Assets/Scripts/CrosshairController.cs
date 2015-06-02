using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrosshairController: MonoBehaviour {	
	void Update() {
		// Unlike for the Asteroid controller, the Raycast function here is called on Physics, not a collider.
		// Raycast() takes an origin position, an origin direction, and how long the Raycast can go.
		bool isLookingAt = Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, Mathf.Infinity);

		// Change the color of the Crosshair depending on if it is looking at something
		if (isLookingAt) {
			GetComponent<Image> ().color = Color.red;
		} else {
			GetComponent<Image> ().color = Color.white;
		}
	}
}
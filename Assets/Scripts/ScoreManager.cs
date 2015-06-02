using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static int score;
	Text textComponent;
	
	void Awake () {
		textComponent = GetComponent<Text> ();
		score = 0;
	}

	void Update () {
		textComponent.text = "Score: " + score;
	}
}

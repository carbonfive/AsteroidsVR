using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float tumble;
	private Vector3 axis;
	
	void Start ()
	{
		axis = Random.insideUnitSphere;
	}
	
	void Update() {
		transform.Rotate (axis * tumble * Time.deltaTime);
	}
}
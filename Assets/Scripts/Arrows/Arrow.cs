using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow.
/// Handles its own input and detection of successful matches.
/// When the correct input is made while the arrow is within the AM's margin, the object is destroyed 
/// and a method is run in AM
/// </summary>
public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * ArrowManager.AM.speed * Time.deltaTime;
	}
}

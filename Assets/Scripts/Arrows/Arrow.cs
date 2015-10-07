using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPos = new Vector2 (transform.position.x, transform.position.y + 1);
		transform.position = Vector2.Lerp (transform.position, newPos, Time.deltaTime * speed);
	}
}

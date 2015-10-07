using UnityEngine;
using System.Collections;

public class Graveyard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Arrow") {
			print ("Arrow destroyed");
			Destroy(coll.gameObject);
		}
	}
}

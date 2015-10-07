using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	GameObject current;
	bool ready = false;

	void OnTriggerStay2D (Collider2D col){
		if (col.gameObject.tag == "Arrow") {
			current = col.gameObject;
			ready = true;
		} else {
			ready = false;
		}
	}

	public void trigger(){
		if (ready) {
			Destroy(current);
			ready = false;
		}
	}
}

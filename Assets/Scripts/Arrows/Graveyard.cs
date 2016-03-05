using UnityEngine;

public class Graveyard : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Arrow") {
			Destroy(col.gameObject);
            ScoreManager.instance.updateScore("miss");
        }
	}
}

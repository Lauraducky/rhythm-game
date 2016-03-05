using UnityEngine;

public class Goal : MonoBehaviour {
    static float arrowSize = 1.9f;
    [SerializeField] float ok = arrowSize/4*3f;
    [SerializeField] float good = arrowSize/2;
    [SerializeField] float perfect = arrowSize/4;

    public char identity;
    GameObject current = null;
    GameObject[] arrows;
    bool ready = false;

    void Update() {
        ready = false;

        if(current == null) {
            current = (GameObject)ArrowManager.instance.getArrow(identity);
        }
        if (current != null) {
            float dist = Vector2.Distance(transform.position, current.transform.position);
            if (dist < arrowSize) {
                ready = true;
            }
        }
    }

	public void trigger(){
		if (ready) {
            float dist = Vector2.Distance(transform.position, current.transform.position);
            if (dist < perfect) {
                ScoreManager.instance.updateScore("perfect");
            }else if (dist < good) {
                ScoreManager.instance.updateScore("good");
            } else if (dist < ok) {
                ScoreManager.instance.updateScore("ok");
            } else {
                ScoreManager.instance.updateScore("bad");
            }
            ready = false;
            Destroy(current);
            current = null;
        }
	}

    public void delArrow(GameObject arrow) {
        if(current == arrow || current.Equals(arrow)) {
            current = null;
        }
    }
}

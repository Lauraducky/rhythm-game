using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    static float arrowSize = 1.9f;
    [SerializeField] float ok = arrowSize/4*3f;
    [SerializeField] float good = arrowSize/2;
    [SerializeField] float perfect = arrowSize/4;

    GameObject current;
	bool ready = false;
    bool collided = false;
    string labeltext = "";

    float guitimer = 0;
    float timerCooldown = 0.25f;

    void Update() {
        if(collided) {
            collided = false;
            ready = true;
        } else {
            ready = false;
        }

        guitimer += Time.deltaTime;
        if(guitimer > timerCooldown) {
            labeltext = "";
            guitimer = 0;
        }
    }

	void OnTriggerStay2D (Collider2D col){
		if (col.gameObject.tag == "Arrow") {
			current = col.gameObject;
			collided = true;
		}
	}

	public void trigger(){
		if (ready) {
            float dist = Vector2.Distance(transform.position, current.transform.position);
            if (dist < perfect) {
                print("Perfect!");
                labeltext = "Perfect!";
            }else if (dist < good) {
                print("Good");
                labeltext = "Good";
            }else if (dist < ok) {
                print("Ok");
                labeltext = "Ok";
            } else {
                print("Bad");
                labeltext = "Bad";
            }
            guitimer = 0;
            ready = false;
            Destroy(current);
           
        }
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), labeltext);
    }
}

using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    static float arrowSize = 1.9f;
    [SerializeField] float ok = arrowSize/4*3f;
    [SerializeField] float good = arrowSize/2;
    [SerializeField] float perfect = arrowSize/4;

    GameObject current;
    GameObject[] arrows;
    bool ready = false;
    string labeltext = "";

    float guitimer = 0;
    float timerCooldown = 0.25f;

    void Update() {
        ready = false;
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach(GameObject arrow in arrows) {
            if (transform.position.x == arrow.transform.position.x || transform.position.y == arrow.transform.position.y) {
                float dist = Vector2.Distance(transform.position, arrow.transform.position);
                if (dist < arrowSize) {
                    ready = true;
                    current = arrow;
                }
            }
        }

        guitimer += Time.deltaTime;
        if(guitimer > timerCooldown) {
            labeltext = "";
            guitimer = 0;
        }
    }

	public void trigger(){
		if (ready) {
            float dist = Vector2.Distance(transform.position, current.transform.position);
            if (dist < perfect) {
                labeltext = "Perfect!";
            }else if (dist < good) {
                labeltext = "Good";
            }else if (dist < ok) {
                labeltext = "Ok";
            } else {
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

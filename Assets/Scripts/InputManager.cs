using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	[SerializeField] Goal upGoal;
    [SerializeField] Goal rightGoal;
    [SerializeField] Goal downGoal;
    [SerializeField] Goal leftGoal;

    // Update is called once per frame
    void Update () {
        //deal with up arrow input
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.JoystickButton3)) {
			upGoal.trigger();
		}
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.JoystickButton1)) {
            rightGoal.trigger();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.JoystickButton0)) {
            downGoal.trigger();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.JoystickButton2)) {
            leftGoal.trigger();
        }
    }
}

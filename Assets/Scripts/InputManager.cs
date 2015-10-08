using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	[SerializeField] Goal upGoal;

	// Update is called once per frame
	void Update () {
        //deal with up arrow input
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.JoystickButton3)) {
			upGoal.trigger();
		}
	}
}

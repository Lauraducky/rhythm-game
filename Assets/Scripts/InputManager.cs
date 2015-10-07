using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	[SerializeField] Goal upGoal;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			upGoal.trigger();
		}
	}
}

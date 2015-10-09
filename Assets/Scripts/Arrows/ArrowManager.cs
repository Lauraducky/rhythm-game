using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow manager.
/// A reference manager of and for the arrows in the scene.
/// </summary>
public class ArrowManager : MonoBehaviour {

	public static ArrowManager AM;

	public float margin = 1;
	public float speed = 10;

	[SerializeField] Object[] arrows;
	[SerializeField] Transform[] startPos;
	[SerializeField] float interval = 1;
	float timer = 0;

	// Use this for initialization
	void Start () {


		if (AM == null) {
			AM = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > interval) {
			timer = 0;
			spawnArrow('N');
		}
	}

	public void spawnArrow(char direction){
		if (direction == 'N') {
			Instantiate (arrows [0], startPos [0].position, Quaternion.identity);
		} else if (direction == 'E') {
			Instantiate (arrows [1], startPos [1].position, Quaternion.identity);
		} else if (direction == 'S') {
			Instantiate (arrows [2], startPos [2].position, Quaternion.identity);
		} else if (direction == 'W') {
			Instantiate (arrows [3], startPos [3].position, Quaternion.identity);
		}
	}
}

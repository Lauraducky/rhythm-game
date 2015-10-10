using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {

	public static ArrowManager instance;

	[SerializeField] Object[] arrows;
	[SerializeField] Transform[] startPos;
	[SerializeField] float interval = 0.91666f;
	float timer = 0;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= interval) {
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

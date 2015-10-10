using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public static SoundManager myManager;
    public Music myMusic;

	// Use this for initialization
	void Start () {
        if (myManager == null) {
            DontDestroyOnLoad(gameObject);
            myManager = this;
        } else if (myManager != this) {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}

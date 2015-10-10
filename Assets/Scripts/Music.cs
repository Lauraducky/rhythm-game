using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour {
    public AudioClip LevelMusic;
    AudioSource player;
    float volume = 1.5f;
    float startTimer = 0;
    bool playing = false;

    // Use this for initialization
    void Start () {
        player = GetComponent<AudioSource>();
        player.loop = false;
        player.volume = volume;
        player.clip = LevelMusic;
    }
	
	// Update is called once per frame
	void Update () {
        startTimer += Time.deltaTime;
        if (startTimer > 2 && !playing) {
            player.Play();
            playing = true;
        }
    }
}

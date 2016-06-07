using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Collections;

public class MenuUIManager : MonoBehaviour {
    public GameObject songButton;
    public GameObject content;
    public GameObject details;
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject playButton;
    private ArrayList songButtons;

	// Use this for initialization
	void Start () { 
        DirectoryInfo songs = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Assets\Songs");
        FileInfo[] files = songs.GetFiles("*.txt");                                                 //get file names
        content.GetComponent<RectTransform>().sizeDelta = new Vector3(0, files.Length * 40 + 20);   //make content pane the right size
        songButtons = new ArrayList();                                                              //initialise button arraylist
        int songnum = 0;
        foreach (FileInfo file in files) {
            string songname = Path.GetFileNameWithoutExtension(file.ToString());    //get song name string
            GameObject bt = Instantiate(songButton);                                //instantiate button
            bt.GetComponentInChildren<Text>().text = songname;
            bt.transform.SetParent(content.transform, false);                       //set button parent
            bt.GetComponent<RectTransform>().localPosition = new Vector3(0, -songnum*40-30, 0);
            bt.GetComponent<Button>().onClick.AddListener(() => { clickSongNameButton(songname, bt); }); //add event handler
            bt.GetComponent<Image>().color = Color.clear;
            songButtons.Add(bt);    //add button to arraylist
            songnum++;
        }
        content.GetComponent<RectTransform>().localPosition = new Vector3(0,0);
    }

    private void clickSongNameButton(string songname, GameObject button) {
        details.GetComponent<Text>().text = "";
        foreach(GameObject g in songButtons) {
            g.GetComponent<Image>().color = Color.clear;
        }
        button.GetComponent<Image>().color = Color.cyan;
        string[] lines = File.ReadAllLines("Assets/Songs/" + songname + ".txt");
        foreach(string line in lines) {
            details.GetComponent<Text>().text = details.GetComponent<Text>().text + line + "\n";
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}

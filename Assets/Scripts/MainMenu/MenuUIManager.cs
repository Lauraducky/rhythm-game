using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {

    public GameObject songButton;
    public GameObject panel;

	// Use this for initialization
	void Start () { 
        DirectoryInfo songs = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Assets\Songs");
        FileInfo[] files = songs.GetFiles("*.txt");
        int songnum = 0;
        foreach (FileInfo file in files) {
            string songname = Path.GetFileNameWithoutExtension(file.ToString());
            GameObject bt = Instantiate(songButton);
            bt.GetComponentInChildren<Text>().text = songname;
            bt.transform.SetParent(panel.transform, false);
            songnum++;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

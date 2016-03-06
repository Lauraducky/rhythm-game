using UnityEngine;
using System.IO;

public class MenuControl : MonoBehaviour {
    FileInfo[] files;

    // Use this for initialization
    void Start () {
        DirectoryInfo songs = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Assets\Songs");
        files = songs.GetFiles("*.txt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        int songnum = 0;
        foreach (FileInfo file in files) {
            GUI.Button(new Rect(20, 40*songnum+20, Screen.width - 40, 30), Path.GetFileNameWithoutExtension(file.ToString()));
            songnum++;
        }
    }
}

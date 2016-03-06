using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    const int BAD = 10;
    const int OK = 50;
    const int GOOD = 100;
    const int PERFECT = 200;
    const int COMBO_BONUS = 10;

    enum Score {Total, Misses, Bads, Oks, Goods, Perfects, CurrentCombo, MaxCombo};
    int[] Scores = new int[8];

    string labeltext = "";
    string scoretext = "0";
    string combotext = "";

    bool gameEnded = false;
    float guitimer = 0;
    float timerCooldown = 0.25f;

    // Use this for initialization
    void Start () {
        instance = this;
	    for(int i = 0; i<Scores.Length; i++) {
            Scores[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        guitimer += Time.deltaTime;
        if (guitimer > timerCooldown) {
            labeltext = "";
            guitimer = 0;
        }
    }

    public void updateScore(string type) {
        if (type.Equals("perfect")) {
            Scores[(int)Score.Perfects]++;
            Scores[(int)Score.Total] += PERFECT;
            Scores[(int)Score.CurrentCombo]++;
        }else if (type.Equals("good")) {
            Scores[(int)Score.Goods]++;
            Scores[(int)Score.Total] += GOOD;
            Scores[(int)Score.CurrentCombo]++;
        }else if (type.Equals("ok")) {
            Scores[(int)Score.Oks]++;
            Scores[(int)Score.Total] += OK;
            Scores[(int)Score.CurrentCombo]++;
        }else if (type.Equals("bad")) {
            Scores[(int)Score.Bads]++;
            Scores[(int)Score.Total] += BAD;
            breakCombo();
        }else if (type.Equals("miss")) {
            Scores[(int)Score.Misses]++;
            breakCombo();
        }

        scoretext = Scores[(int)Score.Total].ToString();
        if (Scores[(int)Score.CurrentCombo] > 0) {
            combotext = Scores[(int)Score.CurrentCombo].ToString();
        } else {
            combotext = "";
        }
        labeltext = type;
        guitimer = 0;
    }
    
    void breakCombo() {
        Scores[(int)Score.Total] += Scores[(int)Score.CurrentCombo] * COMBO_BONUS;
        if (Scores[(int)Score.CurrentCombo] > Scores[(int)Score.MaxCombo]) {
            Scores[(int)Score.MaxCombo] = Scores[(int)Score.CurrentCombo];
        }
        Scores[(int)Score.CurrentCombo] = 0;
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), labeltext);
        GUI.Label(new Rect(10, 30, 100, 20), scoretext);
        GUI.Label(new Rect(10, 50, 100, 20), combotext);
        if (gameEnded) {
            GUI.Window(0, new Rect((Screen.width-200)/2, (Screen.height-200)/2, 200, 300), endWindow, "Game Over");
        }
    }

    void endWindow(int windowId) {
        GUI.Label(new Rect(30, 30, 100, 20), "Score: " + scoretext);
        GUI.Label(new Rect(30, 60, 100, 20), "Perfects: " + Scores[(int)Score.Perfects].ToString());
        GUI.Label(new Rect(30, 90, 100, 20), "Goods: " + Scores[(int)Score.Goods].ToString());
        GUI.Label(new Rect(30, 120, 100, 20), "OKs: " + Scores[(int)Score.Oks].ToString());
        GUI.Label(new Rect(30, 150, 100, 20), "Bads: " + Scores[(int)Score.Bads].ToString());
        GUI.Label(new Rect(30, 180, 100, 20), "Misses: " + Scores[(int)Score.Misses].ToString());
        GUI.Label(new Rect(30, 210, 100, 20), "Best Combo: " + Scores[(int)Score.MaxCombo].ToString());
        if(GUI.Button(new Rect(30,240,100,20), "Continue")) {
            GUI.enabled = false;
            SceneManager.LoadScene("menu");
        }
    }

    public void endGame() {
        gameEnded = true;
        breakCombo();
    }
}

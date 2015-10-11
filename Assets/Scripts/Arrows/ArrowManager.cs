using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ArrowManager : MonoBehaviour {

	public static ArrowManager instance;

	[SerializeField] Object[] arrows;
	[SerializeField] Transform[] startPos;
    public float speed = 10;

    float interval = 1;
	float timer = 0;
    int lineNum = 1;
    string[] lines;

    Queue<Object> upArrows;
    Queue<Object> downArrows;
    Queue<Object> leftArrows;
    Queue<Object> rightArrows;

    // Use this for initialization
    void Start () {
        instance = this;
        
        upArrows = new Queue<Object>();
        downArrows = new Queue<Object>();
        leftArrows = new Queue<Object>();
        rightArrows = new Queue<Object>();

        lines = File.ReadAllLines("Assets/Songs/dontyouforget.txt");
        interval = float.Parse(lines[0]);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= interval*lineNum && lineNum<lines.Length) {
            int line = int.Parse(lines[lineNum]);
            if(line%10 != 0) {
                spawnArrow('E');
                line -= 1;
            }
            if(line%100 != 0) {
                spawnArrow('N');
                line -= 10;
            }
            if(line%1000 != 0) {
                spawnArrow('W');
                line -= 100;
            }
            if(line%10000 != 0) {
                spawnArrow('S');
            }
            lineNum++;
        }
	}

	public void spawnArrow(char direction){
		if (direction == 'N') {
			upArrows.Enqueue(Instantiate (arrows [0], startPos [0].position, Quaternion.identity));
		} else if (direction == 'E') {
			rightArrows.Enqueue(Instantiate (arrows [1], startPos [1].position, Quaternion.identity));
		} else if (direction == 'S') {
			downArrows.Enqueue(Instantiate (arrows [2], startPos [2].position, Quaternion.identity));
		} else if (direction == 'W') {
			leftArrows.Enqueue(Instantiate (arrows [3], startPos [3].position, Quaternion.identity));
		}
	}

    public Object getArrow(char direction) {
        if (direction == 'N' && upArrows.Count > 0) {
            return upArrows.Dequeue();
        } else if (direction == 'E' && rightArrows.Count > 0) {
            return rightArrows.Dequeue();
        } else if (direction == 'S' && downArrows.Count > 0) {
            return downArrows.Dequeue();
        } else if (direction == 'W' && leftArrows.Count > 0) {
            return leftArrows.Dequeue();
        }
        return null;
    }
}

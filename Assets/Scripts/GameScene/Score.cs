using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private GameObject scoreText;
    public static int blowoffCounter;      //吹き出しを何回消したか  初期値は0

    //private ActivateBlowoff activateBlowoff;



    // Use this for initialization
    void Start () {
        this.scoreText = GameObject.Find("Score");
        Score.blowoffCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //this.scoreText.GetComponent<Text>().text = "消した吹き出し  :  " + this.blowoffCounter.ToString("F0")+"こ";
	}

    public static int getScore()
    {
        return blowoffCounter;
    }
}

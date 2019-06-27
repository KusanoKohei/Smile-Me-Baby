using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextCtrl : MonoBehaviour {

    public Text timerText;

    [SerializeField]
    private float limmitTime;
    private float passedTime;
    private int currentTime;

	// Use this for initialization
	void Start () {
        this.passedTime = 0;
        this.currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        //ゲームの状態がゲーム中でなければ生成しない
        if (GameStatus.instance.state != GameStatus.STATE.RUN)
        {
            return;
        }
        

        this.passedTime += Time.deltaTime;
            this.currentTime = (int)(this.limmitTime - this.passedTime);
            timerText.text = this.currentTime.ToString();
	}
}

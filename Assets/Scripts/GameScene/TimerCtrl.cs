using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCtrl : MonoBehaviour {

    public Image timerGage;         //タイマーゲージ
    public string nextSceneName;    //遷移先のシーン

    private VoiceScript voice;

    private GameStatusTransitionManager statusManager;

    [SerializeField]
    private float limmitTime;       //制限時間
    private float passedTime;       //経過時間
    private float currentTime;      //残り時間

	// Use this for initialization
	void Start () {
        this.passedTime = 0;
        this.currentTime = 0;
        statusManager = FindObjectOfType<GameStatusTransitionManager>();
        voice = FindObjectOfType<VoiceScript>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //ゲームの状態がゲーム中でなければ生成しない
        if(GameStatus.instance.state != GameStatus.STATE.RUN)
        {
            return;
        }
        

        this.passedTime += Time.deltaTime;
        this.currentTime = (this.limmitTime - this.passedTime);
        timerGage.fillAmount = this.currentTime / this.limmitTime;

        //もし残り時間が0いかになったなら
        if (currentTime < 0) {
            GameStatus.instance.state = GameStatus.STATE.TIMEUP;
            voice.timeleft = 0;
            statusManager.StartCoroutine("Timeup");
        }

    }
}

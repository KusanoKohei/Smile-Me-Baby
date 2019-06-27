using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    private static GameStatus mInstance;
    public static GameStatus instance
    {
        get
        {
            //インスタンスが参照されているか
            if (mInstance == null)
            {
                //インスタンスを探し出し、参照する
                mInstance = FindObjectOfType<GameStatus>();
            }
            return mInstance;
        }
    }

    public enum STATE
    {
        NONE,       //何もない状態
        TITLE,      //タイトルの状態
        MENU,       //メニューの状態
        START,      //スタートの状態
        RUN,        //ゲーム中の状態
        TIMEUP      //タイムアップ状態
    }

    public STATE state
    {
        get;
        set;
    }


	// Use this for initialization
	virtual protected void Start () {
		
	}
	
	// Update is called once per frame
	virtual protected void Update () {
        switch(state)
        {
            case STATE.TITLE:
                //Debug.Log("ゲームの状態はTITLE");
                break;
            case STATE.MENU:
                //Debug.Log("ゲームの状態はMENU");
                break;
            case STATE.START:
                //Debug.Log("ゲームの状態はSTART");
                break;
            case STATE.RUN:
                //Debug.Log("ゲームの状態はRUN");
                break;
            case STATE.TIMEUP:
                //Debug.Log("ゲームの状態はTIMEUP");
                break;
        }
		
	}
}

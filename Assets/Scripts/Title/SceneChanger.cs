using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : GameStatus {

    Level level;
    ButtonSE buttonSe;

	// Use this for initialization
	override protected void Start () {
        base.Start();
        GameStatus.instance.state = GameStatus.STATE.TITLE;
        level = FindObjectOfType<Level>();
        buttonSe = FindObjectOfType<ButtonSE>();
	}
	
	// Update is called once per frame
	override protected void Update () {

        base.Update();

        //もし画面のどこかをタッチしたら、インスペクタで設定したシーンに移る
        if(Input.GetMouseButtonDown(0))
        {
            //タイトルから始める場合はモード、レベル共に 1 にしておく
            /*  ゲームオーバーになる度にモードまで１に戻る問題 */
            Level.MyMode = 1;
            Level.MyLevel = 1;
            Debug.Log("モードは" + Level.MyMode);

            //SE
            buttonSe.ClickSe();
            
            //シーンをメニューへ
            SceneManager.LoadScene("Menu");
        }
		
	}
}

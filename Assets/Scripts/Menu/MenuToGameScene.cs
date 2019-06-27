using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToGameScene : MonoBehaviour {

    private Level level;

    ButtonSE buttonSe;

    private void Start()
    {

    }

    public void ToGameSceneButtonClicked()
    {
        level = FindObjectOfType<Level>();

        buttonSe = FindObjectOfType<ButtonSE>();
        buttonSe.ClickSe();

        //メニューからはじめる場合はレベルを１にしておく
        //(MyMode)に変更はなし
        //レベルに基づいてパラメータをセットする

        level.SetParameter();
        Debug.Log("SetParameter関数　起動");

        //レベルの初期化はゲームオーバー時（Result.cs)にて
        //initParameter();にてやってくれる
        //（レベルを１にするのみで、難易度（Mode)を変更はさせない

        //ゲームシーンへ
        SceneManager.LoadScene("GameScene");
    }
}

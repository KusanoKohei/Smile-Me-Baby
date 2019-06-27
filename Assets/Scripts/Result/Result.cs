using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

    ResultActivateButton resultActivateButton;
    ResultActivateSprite resultActivateSprite;
    Level level;

    public int nowlevel;

    private GameObject scoreText;
    private GameObject resultText;
    private GameObject sceneChangeText;
    private GameObject resultBoard;

    private ResultVoiceScript voice;

    //しきい値
    private static int threshold;
    public static int MyThreshold{ get{ return threshold;} set{ threshold = value;}}

    // Use this for initialization
    private void Start () {
        scoreText = GameObject.Find("ScoreText");
        resultText = GameObject.Find("ResultText");
        resultActivateButton = GameObject.FindObjectOfType<ResultActivateButton>();
        resultActivateSprite = GameObject.FindObjectOfType<ResultActivateSprite>();        
        level = FindObjectOfType<Level>();
        voice = FindObjectOfType<ResultVoiceScript>();

        //始めのうちは女性の画像、スプライトをオフにする
        //女性・セリフの画像を表示
        resultActivateSprite.WomanSprite.SetActive(false);
        resultActivateSprite.SerifBlowoff.SetActive(false);
        resultActivateSprite.ClearSprite.SetActive(false);

        nowlevel = Level.MyLevel;

        StartCoroutine("ResultAnnouncement");

    }

    IEnumerator ResultAnnouncement()
    {
        //staticなScoreのblowoffCounterを参照して、スコアを表示
        this.scoreText.GetComponent<Text>().text = "消した吹き出しの数は : " + Score.blowoffCounter + "こ";
        //二秒待つ
        yield return new WaitForSeconds(2.0f);

        //結果の善し悪しを表示
        //スコアが、しきい値以上の場合は
        if (Score.blowoffCounter >= Result.MyThreshold)
        {

            if (Level.MyLevel == 3)
            {
                //クリア用のスプライトを表示
                resultActivateSprite.WomanSprite.SetActive(true);
                resultActivateSprite.SerifBlowoff.SetActive(true);
                //メッセージ                
                this.resultText.GetComponent<Text>().text = "　いつもありがとう！\n　がんばりやさんの\n　パパと一緒になれて\n　よかったわ";
                level.initParameter();

                //三秒待つ
                yield return new WaitForSeconds(3.0f);
                resultActivateSprite.WomanSprite.SetActive(false);      //女性のスプライトをoff
                resultActivateSprite.SerifBlowoff.SetActive(false);      //セリフ用の吹き出しをon
                resultActivateSprite.ResultBoard.SetActive(false);      //ボードをoff
                this.scoreText.GetComponent<Text>().text ="";
                this.resultText.GetComponent<Text>().text = "";


                resultActivateSprite.BabySprite.SetActive(true);
                resultActivateSprite.ClearSprite.SetActive(true);       //クリア用のスプライトをon
                voice.LaughVoice(voice.laugh);


                //メッセージ                
                //this.resultText.GetComponent<Text>().text = "Thank you for Playing !";

                //二秒待つ
                yield return new WaitForSeconds(2.0f);

                //タイトルボタンを表示
                resultActivateButton.TitleButton.SetActive(true);

                //タイトルへシーン遷移
                //SceneManager.LoadScene("Title");
            }
            else
            {
                this.LevelUp();

                //女性・セリフの画像を表示
                resultActivateSprite.WomanSprite.SetActive(true);
                resultActivateSprite.SerifBlowoff.SetActive(true);
                //メッセージ
                this.resultText.GetComponent<Text>().text = "ありがとう！\n また今度もよろしくね♪";
                
                //一秒待つ
                yield return new WaitForSeconds(1.0f);
                resultActivateButton.NextLevelButton.SetActive(true);
            }
        }
        else if (Score.blowoffCounter < Result.MyThreshold)
        {
            //女性・セリフの画像を表示
            resultActivateSprite.WomanSprite.SetActive(true);
            resultActivateSprite.SerifBlowoff.SetActive(true);
            //メッセージ
            this.resultText.GetComponent<Text>().text = "たくさん泣いて\n大変だったね……\nまた今度お願いね";

            //レベルを初期化する
            level.initParameter();

            //一秒待つ
            yield return new WaitForSeconds(3.0f);
            resultActivateSprite.GameOverSprite.SetActive(true);

            //三秒待つ
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Title");
            //resultActivateButton.TitleButton.SetActive(true);
        }
    }

    private void LevelUp()
    {
        if (Level.MyLevel <3)
        {
             Level.MyLevel ++;
             //レベルをセットする
             level.SetParameter();
        }
        else if (Level.MyLevel == 3)
        {
             //パラメータ初期化
             level.initParameter();
        }
    }
}

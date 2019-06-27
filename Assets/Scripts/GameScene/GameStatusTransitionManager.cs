using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusTransitionManager : GameStatus {

    private Image countSpriteRenderer;
    private RectTransform spriteSize;       //スプライトサイズを変更するための変数
    private Text thresholdText;

    [SerializeField]
    private Sprite stage1;
    [SerializeField]
    private Sprite stage2;
    [SerializeField]
    private Sprite lastStage;

    [SerializeField]
    private Sprite count_3;
    [SerializeField]
    private Sprite count_2;
    [SerializeField]
    private Sprite count_1;
    [SerializeField]
    private Sprite startBar;
    [SerializeField]
    private Sprite timeup;
    

    private Text mText;

	// Use this for initialization
	override protected void Start () {
        state = STATE.START;
        
        //スプライト描画用変数
        countSpriteRenderer = this.GetComponent<Image>();
        //スプライトのサイズを変更するための変数
        spriteSize = this.GetComponent<RectTransform>();

        //しきい値表示用変数
        thresholdText = GameObject.Find("ThresholdText").GetComponent<Text>();

        StartCoroutine("StartCountDown");

    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();  //親クラスのメソッドを呼ぶ
	}

    IEnumerator StartCountDown()
    {
        //STAGEspriteのためにスプライトサイズを変更
        spriteSize.sizeDelta = new Vector2(700,300);

        if (Level.MyLevel<=1)
        {
            countSpriteRenderer.sprite = stage1;
        }
        else if(Level.MyLevel==2)
        {
            countSpriteRenderer.sprite = stage2;
        }
        else if(Level.MyLevel>=3)
        {
            countSpriteRenderer.sprite = lastStage;
        }

        //しきい値のテキストを表示（アクティブ）
        thresholdText.gameObject.SetActive(true);


        //一秒待つ
        yield return new WaitForSeconds(2.0f);
        //カウントダウン用にスプライトサイズを変更
        spriteSize.sizeDelta = new Vector2(300, 300);

        //GUIの表示を3にする
        countSpriteRenderer.sprite = count_3;
        //縦横崩さないためにネイティブサイズに
        countSpriteRenderer.SetNativeSize();
        //一秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を2にする
        countSpriteRenderer.sprite = count_2;
        //一秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を1にする
        countSpriteRenderer.sprite = count_1;

        //一秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を START! にする
        countSpriteRenderer.sprite = startBar;
        //縦横崩さないためにネイティブサイズに
        countSpriteRenderer.SetNativeSize();
        //ゲームの状態をゲーム中にする
        state = STATE.RUN;


        //一秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIに何も表示しない
        countSpriteRenderer.enabled = false;
        //しきい値のテキストを非表示（非アクティブ）
        thresholdText.gameObject.SetActive(false);

    }


    IEnumerator Timeup()
    {

        //TIME UP ! と表示する
        countSpriteRenderer.enabled = true;
        countSpriteRenderer.sprite = timeup;
        countSpriteRenderer.SetNativeSize();

        //三秒待つ
        yield return new WaitForSeconds(3.0f);

        //ゲーム状態をリザルトへ移す
        SceneManager.LoadScene("Result");

    }
}

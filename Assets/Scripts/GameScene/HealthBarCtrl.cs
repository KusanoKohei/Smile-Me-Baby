using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCtrl : MonoBehaviour {

    private Player player;  //プレイヤークラスの変数

    private StressCtrl stressCtrl;  //ストレスクラスを当て込む変数

    public Image healthBarGage;


    // Use this for initialization
    void Start () {
        //プレイヤーを認識させるためにタグから情報を取得
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //ストレスの値を認識させるためにゲームオブジェクトから情報を取得
        stressCtrl = GameObject.FindObjectOfType<StressCtrl>();

        //ゲージの初期化
        this.initParameter();
    }
	
	// Update is called once per frame
	void Update () {
        
        //ゲームの状態がゲーム中でなければ生成しない
        if (GameStatus.instance.state != GameStatus.STATE.RUN)
        {
            return;
        }
        

        healthBarGage.fillAmount = stressCtrl.MyCurrentStress / stressCtrl.MyMaxStress;
    }


    //ヘルスバーを初期化するファンクション
    private void initParameter()
    {
        healthBarGage = GameObject.Find("HealthBarGage").GetComponent<Image>();
        healthBarGage.fillAmount = 0;
    }
}

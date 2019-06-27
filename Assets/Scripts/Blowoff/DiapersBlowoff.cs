using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiapersBlowoff : MonoBehaviour,IDropHandler{

    private Hand hand;

    private Diapers diapers;

    private Item item;

    private Score score;

    private SEscript se;

    private StressCtrl stressCtrl;


    void Start()
    {
        hand = FindObjectOfType<Hand>();
        score = FindObjectOfType<Score>();
        se = FindObjectOfType<SEscript>();
        stressCtrl = FindObjectOfType<StressCtrl>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //ゲーム状態がゲーム中じゃないなら中止させる
        if (GameStatus.instance.state != GameStatus.STATE.RUN)
        {
            return;
        }

        Item gotItem = hand.GetGrabbingItem();
        if (gotItem is Diapers)        //is はクラスの肩を調べてくれる便利なもの　2019 6/10
        { 
            gotItem.useItem(GameObject.FindObjectOfType<StressCtrl>());
            //吹き出しを一個消したカウントをする
            Score.blowoffCounter++;


            if (Score.blowoffCounter % 10 == 0 && Score.blowoffCounter != 0)
            {
                //十の倍数効果音再生
                se.TenSe();
                stressCtrl.CareTen();
            }
            else if (Score.blowoffCounter % 5 == 0 && Score.blowoffCounter % 10 != 0)
            {
                //五の倍数の効果音の再生
                se.FiveSe();
                stressCtrl.CareFive();
            }
            else
            {
                //通常効果音再生
                se.KirakiraSe();
            }

        }

        //Handにもともと持っていたアイテムを返す
        //こうしないとスロットからアイテムが消失し、空白になってしまう
        hand.SetGrabbingItem(gotItem);
    }
}

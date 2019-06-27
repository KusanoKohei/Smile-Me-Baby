using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateBlowoff : MonoBehaviour{

    [SerializeField]
    private GameObject appetiteBlowoff;
    [SerializeField]
    private GameObject diapersBlowoff;
    [SerializeField]
    private GameObject toysBlowoff;
    [SerializeField]
    private GameObject sleepBlowoff;

    private Player player;

    private Item item;

    private Slot slot;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //初期では食欲の吹き出しは消えている
        appetiteBlowoff.SetActive(false);
        diapersBlowoff.SetActive(false);
        toysBlowoff.SetActive(false);
        sleepBlowoff.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (player.MyAppetite >= player.MyMaxAppetite) appetiteBlowoff.SetActive(true);         //食欲が最大値に達したなら吹き出しが現れる
        else if (player.MyAppetite < player.MyMaxAppetite) appetiteBlowoff.SetActive(false);    //食欲が解消されたなら、吹き出しが消える

        if (player.MyDiapers >= player.MyMaxDiapers) diapersBlowoff.SetActive(true);         //おむつが最大値に達したなら吹き出しが現れる
        else if (player.MyDiapers < player.MyMaxDiapers) diapersBlowoff.SetActive(false);    //おむつが解消されたなら、吹き出しが消える

        if (player.MyToys >= player.MyMaxToys) toysBlowoff.SetActive(true);         //おもちゃが最大値に達したなら吹き出しが現れる
        else if (player.MyToys < player.MyMaxToys) toysBlowoff.SetActive(false);    //おもちゃが解消されたなら、吹き出しが消える

        if (player.MySleep >= player.MyMaxSleep) sleepBlowoff.SetActive(true);         //睡眠欲が最大値に達したなら吹き出しが現れる
        else if (player.MySleep < player.MyMaxSleep) sleepBlowoff.SetActive(false);    //睡眠欲が解消されたなら、吹き出しが消える
    }
}

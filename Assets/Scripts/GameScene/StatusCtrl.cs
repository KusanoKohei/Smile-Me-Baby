using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCtrl : MonoBehaviour {

    public enum STATUS
    {
        IDLE,
        GRIZZLE,
        CRYING,
        SMILING
    }

    STATUS status = STATUS.IDLE;
    public bool statusIdle;
    public bool statusGrizzle;
    public bool statusCrying;


    private Player player;
    private StressCtrl stressCtrl;
    private SpriteRenderer spriteChanger;
    //private Animator playerAnimator;

    [SerializeField]
    private Sprite idle;
    [SerializeField]
    private Sprite grizzle;
    [SerializeField]
    private Sprite crying;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        stressCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<StressCtrl>();
        //this.playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //赤ちゃんの立ち絵を変えるための実体化
        spriteChanger = gameObject.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update () {

        //ステータスの遷移&初期化フェイズ
        switch (status)
        {

            case STATUS.IDLE:

                statusIdle = true;
                statusGrizzle = false;
                statusCrying = false;

                spriteChanger.sprite = idle;
                

                if (stressCtrl.MyCurrentStress>90)
                {
                    status = STATUS.GRIZZLE;
                }

                if(stressCtrl.MyCurrentStress>200)
                {
                    status = STATUS.CRYING;
                }
                break;


            case STATUS.GRIZZLE:

                statusIdle = false;
                statusGrizzle = true;
                statusCrying = false;

                spriteChanger.sprite = grizzle;


                if (stressCtrl.MyCurrentStress<90)
                {
                    status = STATUS.IDLE;
                }

                if (stressCtrl.MyCurrentStress>200)
                {
                    status = STATUS.CRYING;
                }                

                break;


            case STATUS.CRYING:

                statusIdle = false;
                statusGrizzle = false;
                statusCrying = true;

                spriteChanger.sprite = crying;
                

                if(stressCtrl.MyCurrentStress<90)
                {
                    status = STATUS.IDLE;
                }
                
                if(stressCtrl.MyCurrentStress>90&&stressCtrl.MyCurrentStress<200)
                {
                    status = STATUS.GRIZZLE;
                }
                break;

        }	
	}
}

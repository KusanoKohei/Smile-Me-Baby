using UnityEngine;

public class StressCtrl : MonoBehaviour {

    //時間計測用の変数
    private float delta;

    //パラメータを変動させる間隔
    private static float span;
    public static float MySpan{ get{ return span;} set{ span = value;}}

    //欲求が加算される値
    private static float addPressure;
    public static float MyAddPressure{ get{ return addPressure;} set{ addPressure = value;}}

    //プレイヤークラスを当て込む変数
    Player player;

    private Score score;

    //ストレス限界数値
    private float maxStress;
    public float MyMaxStress{ get{ return maxStress;} private set{ maxStress = value;}}

    //ストレスの合計値
    private float currentStress;
    public float MyCurrentStress { get { return currentStress; } private set { currentStress = value; } }


    //ランダムな値を入れる変数
    private int num;


    // Use this for initialization
    virtual protected void Start () {
        //プレイヤーを覚えてもらう
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        
        //ゲームの状態がゲーム中でなければ生成しない
        if (GameStatus.instance.state != GameStatus.STATE.RUN)
        {
            return;
        }
        

        //時間経過を変数に当て込む
        this.delta += Time.deltaTime;
        

        //一定時間ごとにパラメータを変動させる
        if (this.delta > StressCtrl.MySpan)
        {
            //this.num = Random.Range(1, 5);
            //（特定の値がMAXだったときの）再抽選関数
            chusen(0);
            this.delta = 0;
        }

        Pressure();

        SumStress();
    }

    //赤ちゃんに与えるストレスをランダムに与える
    void Pressure()
    {
        if (this.num == 1)
        {
            if (player.MyAppetite <= player.MyMaxAppetite)    //食欲が最大食欲以下の限りは繰り返す
            {
                ChargeAppetite();   //食欲
                                    //Debug.Log("現在の食欲は"+player.MyAppetite);
            }
        }
        else if (this.num == 2)
        {
            if (player.MyDiapers <= player.MyMaxDiapers)       //おむつ欲求が最大おむつ欲求以下の限りは繰り返す
            {
                ChargeDiapers();    //おむつ
                                    //Debug.Log("現在のおむつ欲求は" + player.MyDiapers);
            }
        }
        else if (this.num == 3)
        {
            if (player.MyToys <= player.MyMaxToys)               //おもちゃ欲求が最大おもちゃ欲求以下の限りは繰り返す
            {
                ChargeToys();       //おもちゃ
                                    //Debug.Log("現在のおもちゃ欲求は" + player.MyToys);
            }
        }
        else if (this.num == 4)
        {
            if (player.MySleep <= player.MyMaxSleep)             //睡眠欲が最大睡眠欲以下の限りは繰り返す
            {
                ChargeSleep();      //眠気
                                    //Debug.Log("現在の睡眠欲は" + player.MySleep);
            }
        }
        
    }

    public void SumStress()
    {
        MyMaxStress = 400;
        MyCurrentStress = (player.MyAppetite + player. MyDiapers + player.MyToys + player.MySleep);

        //Debug.Log("トータルストレスは" + MyCurrentStress);

        //トータルの最大ストレスを400までに抑える
        if (MyCurrentStress >= MyMaxStress)
        {
            MyCurrentStress = 400;
        }

        //トータルの最小ストレスを0以下にはしない
        if (MyCurrentStress <= 0)
        {
            MyCurrentStress = 0;
        }
    }

    public void ChargeAppetite()   //食欲を増減させるファンクション
    {
        player.MyAppetite+=StressCtrl.MyAddPressure;
        if (player.MyAppetite <= 0) player.MyAppetite = 0;
        else if (player.MyAppetite > player.MyMaxAppetite) player.MyAppetite = player.MyMaxAppetite;
    }
    public void ChargeDiapers()     //おむつ欲求を増減させるファンクション
    {
        player.MyDiapers+=StressCtrl.MyAddPressure;
        if (player.MyDiapers <= 0) player.MyDiapers = 0;
        else if (player.MyDiapers > player.MyMaxDiapers) player.MyDiapers = player.MyMaxDiapers;
    }
    public void ChargeToys()        //おもちゃ欲求を増減させるファンクション
    {
        player.MyToys+=StressCtrl.MyAddPressure;
        if (player.MyToys <= 0) player.MyToys = 0;
        else if (player.MyToys > player.MyMaxToys) player.MyToys = player.MyMaxDiapers;
    }
    public void ChargeSleep()       //睡眠欲求を増減させるファンクション
    {
        player.MySleep+=StressCtrl.MyAddPressure;
        if (player.MySleep <= 0) player.MySleep = 0;
        else if (player.MySleep > player.MyMaxSleep) player.MySleep = player.MyMaxSleep;
    }

    

    public void CareAppetite(float delta)
    {
        float testAppetite = player.MyAppetite - delta;  //溜まった食欲からreliefAppetite分引く。
        if (testAppetite <= 0) player.MyAppetite = 0;   //MyAppetiteが0以下にならないようにする
        else if (testAppetite > player.MyMaxAppetite) testAppetite = player.MyMaxAppetite; //MyAppetiteが上限値を超えないようにする
        else player.MyAppetite = testAppetite;          //MyAppetiteが上限以下下限以上の場合は、MyAppetiteはtestAppetite
    }

    public void CareDiapers(float delta)
    {
        float testDiapers = player.MyDiapers - delta;  //溜まった食欲からreliefAppetite分引く。
        if (testDiapers <= 0) player.MyDiapers = 0;
        else if (testDiapers > player.MyMaxDiapers) player.MyDiapers = player.MyMaxDiapers;
        else player.MyDiapers = testDiapers;
    }

    public void CareToys(float delta)
    {
        float testToys = player.MyToys - delta;  //溜まった食欲からreliefAppetite分引く。
        if (testToys <= 0) player.MyToys = 0;
        else if (testToys > player.MyMaxToys) player.MyToys = player.MyMaxToys;
        else player.MyToys = testToys;
    }

    public void CareSleep(float delta)
    {
        float testSleep = player.MySleep - delta;  //溜まった食欲からreliefAppetite分引く。
        if (testSleep <= 0) player.MySleep = 0;
        else if (testSleep > player.MyMaxSleep) player.MySleep = player.MyMaxSleep;
        else player.MySleep = testSleep;
    }

    public void CareFive()
    {
        player.MyAppetite=player.MyAppetite/2;
        player.MyDiapers= player.MyDiapers/2;
        player.MyToys= player.MyToys/2;
        player.MySleep= player.MySleep / 2;
    }

    public void CareTen()
    {
        player.MyAppetite =0;
        player.MyDiapers =0;
        player.MyToys =0;
        player.MySleep =0;
    }

    public void chusen(int count)    //再抽選関数
    {
        //一つの関数に一つの機能
        this.num = Random.Range(1, 5);

        /*
        if (count > 20)
        {
            return;
        }
        */

        if(player.MyAppetite==player.MyMaxAppetite
            &&player.MyDiapers==player.MyMaxDiapers
            &&player.MyToys==player.MyMaxToys
            && player.MySleep == player.MyMaxSleep)
        {
            return;
        }

        if (num == 1&&player.MyAppetite==player.MyMaxAppetite)
        {
            //Debug.Log("Apptite");
            chusen(count++);      //再起呼び出し
            return;         //再抽選行ったらこいつは止める
        }
        else if(num==2&&player.MyDiapers==player.MyMaxDiapers)
        {
            //Debug.Log("おむつ");
            chusen(count++);
            return;
        }
        else if(num==3&&player.MyToys==player.MyMaxToys)
        {
            //Debug.Log("おもちゃ");
            chusen(count++);
            return;
        }
        else if(num==4&&player.MySleep==player.MyMaxSleep)
        {
            //Debug.Log("眠気");
            chusen(count++);
            return;
        }        
        else
        {
            //Debug.Log(" else");
            //何もしない
        }
    }
}

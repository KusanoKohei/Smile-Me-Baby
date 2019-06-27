using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private static int mode;
    public static int MyMode{ get{ return mode;} set{ mode = value;}}

    private static int level;
    public static int MyLevel{ get{ return level;} set{ level = value;}}


    public void SetParameter()
    {
        if (Level.MyMode > 3) MyMode = 3;
        if (Level.MyLevel > 3) MyLevel = 3;


        //モードとレベルごとのパラメータ設定
        if (Level.MyMode == 1)
        {
            if (Level.MyLevel == 1)
            {
                Result.MyThreshold = 12;
                StressCtrl.MySpan = 3.0f;
                StressCtrl.MyAddPressure = 1.0f;
            }
            else if (Level.MyLevel == 2)
            {
                Result.MyThreshold = 18;
                StressCtrl.MySpan = 2.5f;
                StressCtrl.MyAddPressure = 1.3f;
            }
            else if (Level.MyLevel == 3)
            {
                Result.MyThreshold = 25;
                StressCtrl.MySpan = 2.0f;
                StressCtrl.MyAddPressure = 1.8f;
            }

            Debug.Log("レベルは" + Level.MyLevel);
            Debug.Log("しきい値は" + Result.MyThreshold);
            Debug.Log("スパンは" + StressCtrl.MySpan);
            Debug.Log("増幅量は" + StressCtrl.MyAddPressure);
        }

        if(Level.MyMode==2)
        {
            if (Level.MyLevel == 1)
            {
                Result.MyThreshold = 20;
                StressCtrl.MySpan = 2.5f;
                StressCtrl.MyAddPressure = 1.4f;
            }
            else if (Level.MyLevel == 2)
            {
                Result.MyThreshold = 30;
                StressCtrl.MySpan = 1.5f;
                StressCtrl.MyAddPressure = 1.8f;
            }
            else if (Level.MyLevel == 3)
            {
                Result.MyThreshold = 40;
                StressCtrl.MySpan = 1.0f;
                StressCtrl.MyAddPressure = 2.4f;
            }

            Debug.Log("レベルは" + Level.MyLevel);
            Debug.Log("しきい値は" + Result.MyThreshold);
            Debug.Log("スパンは" + StressCtrl.MySpan);
            Debug.Log("増幅量は" + StressCtrl.MyAddPressure);
        }

        if(Level.MyMode==3)
        {
            if (Level.MyLevel == 1)
            {
                Result.MyThreshold = 32;
                StressCtrl.MySpan = 1.5f;
                StressCtrl.MyAddPressure = 2.0f;
            }
            else if (Level.MyLevel == 2)
            {
                Result.MyThreshold = 40;
                StressCtrl.MySpan = 1.0f;
                StressCtrl.MyAddPressure = 2.5f;
            }
            else if (Level.MyLevel == 3)
            {
                Result.MyThreshold = 45;
                StressCtrl.MySpan = 0.5f;
                StressCtrl.MyAddPressure = 3.0f;
            }

            Debug.Log("レベルは" + Level.MyLevel);
            Debug.Log("しきい値は" + Result.MyThreshold);
            Debug.Log("スパンは" + StressCtrl.MySpan);
            Debug.Log("増幅量は" + StressCtrl.MyAddPressure);
        }
    }


    public void initParameter()
    {
        Level.MyLevel = 1;
        Debug.Log("initParameter関数　起動");
        /*
        Result.MyThreshold = 8;
        StressCtrl.MySpan = 4.0f;
        StressCtrl.MyAddPressure = 0.6f;

        Debug.Log("レベルは"+Level.MyLevel);
        Debug.Log("しきい値は" + Result.MyThreshold);
        Debug.Log("スパンは" + StressCtrl.MySpan);
        Debug.Log("増幅量は" + StressCtrl.MyAddPressure);
        */
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispMsg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GUIStyle msgWnd;

    private void OnGUI()
    {
        //基準となる画面の幅
        const float screenWidth = 1136;

        //基準サイズに対するウィンドウサイズと座標
        const float msgwWidth = 800;
        const float msgwHeight = 600;
        const float msgwPosX = (screenWidth - msgwWidth) / 2;
        const float msgwPosY = 50;

        //画面の幅から1ピクセルを算出
        float factorSize = Screen.width / screenWidth;

        float msgwX;
        float msgwY;
        float msgwW = msgwWidth * factorSize;
        float msgwH = msgwHeight * factorSize;

        //フォントのスタイル
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = (int)(30 * factorSize);

        //ウィンドウ
        msgwX = msgwPosX * factorSize;
        msgwY = msgwPosY * factorSize;
        GUI.Box(new Rect(msgwX, msgwY, msgwW, msgwH), "ウィンドウ", msgWnd);

        //メッセージ用
        myStyle.normal.textColor = Color.black;

        msgwX = msgwPosX * factorSize;
        msgwY = msgwPosY * factorSize;
        GUI.Label(new Rect(msgwX, msgwY, msgwW, msgwH), "メッセージ", myStyle);
    }

    public static string dispMsg;

    public static void dispMessage(string msg)
    {
        dispMsg = msg;  //メッセージ代入
    }
}

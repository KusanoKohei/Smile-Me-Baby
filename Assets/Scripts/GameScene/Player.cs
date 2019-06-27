using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//⑧動作チェックの為、キャラクターがクリックされた時に攻撃力を表示するようにする
//　IPointerClickHandlerを付け加え、Alt+ Enter で関数を作る
using UnityEngine.EventSystems;

public class Player : MonoBehaviour{

    //①とりあえずアイテムを装備してほしいのでアイテムを宣言
    //⑭複数のアイテムを持てるようにするためにItemのリスト型ににする
    private List<Item> items = new List<Item>();

    //ストレスの種類を設定
    private float appetite; //食欲
    public float MyAppetite { get { return appetite; } set { appetite = value; } }
    private float maxAppetite;
    public float MyMaxAppetite { get { return maxAppetite; } set { maxAppetite = value; } }

    private float diapers;    //おむつ
    public float MyDiapers { get { return diapers; } set { diapers = value; } }
    private float maxDiapers;
    public float MyMaxDiapers { get { return maxDiapers; } set { maxDiapers = value; } }

    private float toys;     //おもちゃ
    public float MyToys { get { return toys; } set { toys = value; } }
    private float maxToys;
    public float MyMaxToys { get { return maxToys; } set { maxToys = value; } }

    private float sleep;    //睡眠欲
    public float MySleep { get { return sleep; } set { sleep = value; } }
    private float maxSleep;
    public float MyMaxSleep { get { return maxSleep; } set { maxSleep = value; } }


    StressCtrl stressCtrl;      //StressCtrlクラスを使うために実体化する為の変数


    //⑬Handクラスを宣言し、実体化
    private Hand hand;


    private void Start()
    {
        //ストレスの初期設定
        appetite = 0;
        maxAppetite = 100;

        diapers = 0;
        maxDiapers = 100;

        toys = 0;
        maxToys = 100;

        sleep = 0;
        maxSleep = 100;

        //Handオブジェクトを検索
        hand = FindObjectOfType<Hand>();

        //StressCtrlを参照
        stressCtrl = GetComponent<StressCtrl>();
    }


    //②外部から変更されたくないので、カプセル化（カプセル化のショートカットキーは ctrl + .)
    //⑮MyItem→MyItemsにする際、右クリックで[名前の変更]で一括変換を
    public List<Item> MyItems { get { return items; } private set { items = value; } }


    //⑨このままPlayerをクリックしても関数は動作しない。
    //  なぜならPlayerはUIのImageではなく、Sprite Rendererであり、
    //  Sprite Rendererはコライダーが搭載していないからで、
    //  コライダーをつけ、MainCameraから光線を飛ばす必要がある
    //　やり方は、Main Camera → [Add Component] →　Physics2DRaycaster　と
    //  Playerに [Add Component] → BoxCollider2Dなどをつける


    //③外部から変更したいときは、SetItem()関数から
    public void SetItem(Item item)
    {
        //⑰外部からアイテムをセットされるように頼まれた時にnullチェック
        //  リストにはnullも入る
        if (item != null) MyItems.Add(item);

    }

    public void Removeitem(Item item)
    {
        if (item != null) MyItems.Remove(item);
    }
}

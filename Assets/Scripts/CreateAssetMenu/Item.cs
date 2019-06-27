using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//④アセットメニューからアイテムを作れる
[CreateAssetMenu(fileName ="Items",menuName ="Items/item")]

//①変化させない初期設定の為
public class Item : ScriptableObject {

    //③アイテムの性質はインスペクタ上で定めたい為
    [SerializeField]
    //②アイテムの名前を入れるために文字列を
    private string itemName;
    [SerializeField]
    //②スプライトを入れたいので Spriteクラス
    private Sprite itemImage;

    //③カプセル化
    public string MyItemName { get { return itemName; } }
    public Sprite MyItemImage { get { return itemImage; } }

    void Start()
    {

    }

    public virtual void useItem(StressCtrl stressCtrl)
    {

    }


}

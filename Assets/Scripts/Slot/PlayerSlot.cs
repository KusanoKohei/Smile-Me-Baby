using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSlot : Slot{ //①Slot.csを継承　必要に応じて上書きする

    //②Playerの装備アイテムを保持するスロットなので、Playerを知ってもらう
    private Player player;

    //③Playerの初期化はstart()関数で行う。それ以外変更したくないのでカプセル化する
    public Player MyPlayer{ get{ return player;} private set{ player = value;}}


    // Use this for initialization
    //⑤継承元のSlot.csのstart()関数を上書きするために、proteced override voidにする
    protected override void Start () {

        //⑥継承元のSlot.csのstart()関数が上書きされ消えてしまうのを防ぐため
        //  継承元のstart()関数を実行しろという意味
        base.Start();

        //④Playerが複数人いる場合、この方法は良くない。普通はタグを使って探し出す
        //MyPlayer = FindObjectOfType<Player>();
        MyPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //⑥Slot.csのOnDrop()関数を継承し、上書きする
        //⑦ドロップのタイミングでPlayerのアイテムを変更する
        //⑫不要になったのでOnDrop()関数は消した

    //⑤アイテムをセットする関数
    public override void SetItem(Item item)
    {
        //⑩プレイヤーから古いアイテムを持たせたり取り上げる
        //  Removeitem()関数が呼ばれるのはアイテムが入れ替わるタイミング
        //  MyItemが古いアイテムに相当
        MyPlayer.Removeitem(MyItem);
        //⑪新しいアイテムを持たせる　引数のitemが新しいアイテムに相当
        MyPlayer.SetItem(item);

        MyItem = item;

        //⑦nullチェック
        if (item != null)
        {
            //⑨nullでないならば、不透明に　Color.whiteでも同じ動作をするらしい
            itemImage.color = new Color(1, 1, 1, 1);
            //⑥SetItem()の引数でnullが入ることがある
            //　そのときItem.MyItemImageは例外を出す。なので追々nullチェックを入れる。
            //  ItemクラスのitemImageにアクセス。当初、private にしていたので、Item.csでカプセル化
            itemImage.sprite = item.MyItemImage;
        }
        else
        {
            //⑧nullの時に描画を透明にする
            itemImage.color = new Color(0, 0, 0, 0);
        }
    }
}

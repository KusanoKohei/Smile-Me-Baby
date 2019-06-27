using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour {

    //①スロットを一つ一つ作るのはこのグリッドなので、インスペクタ上でスロットのプレハブを登録できるようにする
    [SerializeField]
    private GameObject slotPrefab;

    //②グリッド上に表示するスロット数を決める
    private int slotNumber = 4;

    //⑥Slot.cs Item.csを作り、スロットにアイテムをセットできるようになった後、
    //　普通はユーザデータからアイテムデータを持ってくるだろうが、
    //　今回は分かりやすく、アイテムの初期データをインスペクタ上で設定することにする
    //　すべての所持アイテムの配列である
    [SerializeField]
    private Item[] allItems; 

    // Use this for initialization
    void Start () {
        //③開始と同時にスロットを作ってもらう
        for(int i=0; i<slotNumber; i++)
        {
            //④プレハブのインスタンスを作り、それをslotObjと名付ける。
            //　スロットの親はグリッドなので、第二引数はthis.transform
            GameObject slotObj = Instantiate(slotPrefab, this.transform);
            /* object reference not set to an instance of an object.
             * オブジェクト参照がオブジェクトインスタンスに設定されていません。
             * と出て、アイテムが白マスひとつとポーション2枠しか設置されなかった。
             * SlotGrid.csのslotPrefabにはインスペクタビューからslot.csをアタッチしたが、
             * slot.csをアタッチしたPrefab>SlotのitemImageはインスペクタビューから、ItemImageを、
             * "ヒエラルキービューのItemImageゲームオブジェクト"をアタッチしたからだった
             * Prefab>ItemImage.PrefabをItemImageにアタッチしたら、無事表示された。
             * 次にslotPrefab=20としていたのに21枠表示され、先頭にポーションが出ていたのは、
             * SlotGrid以下のSlotとItemImageゲームオブジェクトが残っていたため、
             * またPrefab>ItemImageのSourceImageにポーションがセットされていたからだ。
             * SlotGrid以下のプレハブ化したゲームオブジェクトは消去し、SourceImageは無表示のものに置き換えた
             */


            //⑤ここまでならアイテムを持たないスロットが作られるだけなので、
            //  このタイミングで表示させる
            Slot slot = slotObj.GetComponent<Slot>();

            //⑧オーバーレンジしていないかチェック
            if (i < allItems.Length)
            {
                //⑦allItemsの要素を全て開始と同時に表示する。スロットにアイテムを与える
                slot.SetItem(allItems[i]);
            }
            else
            {
                //⑨空のスロットにはnullを入れておく
                slot.SetItem(null);
            }
        }
	}

}

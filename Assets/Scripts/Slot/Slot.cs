using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//②Imageクラスを作るためにUIの名前空間を作る
using UnityEngine.UI;
//⑩ドラッグ＆ドロップを実装するために
using UnityEngine.EventSystems;

//⑩ドラッグ＆ドロップを実装するために。Alt+Enterで関数化しておこう。
public class Slot : MonoBehaviour,IBeginDragHandler,IDragHandler,IDropHandler,IEndDragHandler {

    //①アイテムを一つ保持できるようにする
    private Item item;

    //③アイテムのアイコンを表示させるオブジェクトはスロットの子として作ってあるので、
    //　インスペクタで定められるように
    [SerializeField]
    //②アイテム表示、非表示の前に宣言
    protected Image itemImage;

    //⑫複製したアイコンをdragginObj、複製元をitemImageObj、最前面に複製するために、親オブジェクトはcanvas
    private GameObject draggingObj;
    [SerializeField]
    private GameObject itemImageObj;
    private Transform canvasTransform;

    //⑱Hand.csを作ったのちに、Handクラスの関数を作るため、まずhandを定義する
    private Hand hand;

    //④itemをカプセル化
    public Item MyItem{ get { return item; } protected set { item = value; } }


    //⑫開始と同時にcanvasTransformを初期化
    //㉗PlayerSlot()関数ではSlot.csを継承しているが、継承元のここのstart()関数も呼び出してほしい。
    //　そのために上書き可能にするために proteted virtual voidにする
    protected virtual void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;

        //⑲Handクラスのhandも初期化(Handのゲームオブジェクトを作って、Hand.csをアタッチしておく）
        hand = FindObjectOfType<Hand>();

        //㉖アイテムがセットされていなかったら透明にする
        if (MyItem == null) itemImage.color = new Color(0, 0, 0, 0);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //⑪中身がnullのときは実行されないようにする
        if (MyItem == null) return;

        //⑫アイテムのイメージを複製
        draggingObj = Instantiate(itemImageObj, canvasTransform);

        //⑬複製を最前面に配置
        draggingObj.transform.SetAsLastSibling();

        //⑭複製元の色を暗くする
        itemImage.color = Color.gray;

        //⑮複製がレイキャストをブロックしないようにする
        //まずSlot.prefabを開き、インスペクタ上でitemImageObjからItemImage(ヒエラルキーから）を登録
        //itemImageObjの宣言の上にSerializeFieldを忘れないように
        //Slot.prefabの子、ItemImage.prefabにCanvasGroupをAddComponent
        //BlocksRaycastsのチェックを外す


        //㉔仲介人にアイテムを渡す　これを忘れると、ハンドのアイテムは常にnull
        hand.SetGrabbingItem(MyItem);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //⑪中身がnullのときは実行されないようにする
        if (MyItem == null) return;

        //⑯複製したポインターを追従するようにする
        //複製する位置＝ポインターの位置
        //⑲の後にInput.mousePositionを、handを追従してもらうように書き直す
        //ハンドがアイコンを運んでいるように見えるが、ハンドはポインタを追従しているので実際は一緒
        //㉕スマホなど指でタッチしていると複製したオブジェクトが見づらいので、少し位置をずらす。
        draggingObj.transform.position
            = hand.transform.position + new Vector3(20, 20, 0) ;
    }


    //⑤アイテムをセットする関数
    public virtual void SetItem(Item item)
    {
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


    //㉘上書きできるようにするために、public virtual void
    public void OnDrop(PointerEventData eventData)
    {
        //㉓空のスロットをドラッグしても、アイテムが交換されないようにする
        //  仲介人がアイテムを持っていなかったら早期return
        //  しかしslotがハンドにアイテムを持っているかどうか知るすべがないので、
        //  Handクラスにpublic bool isHavingItem()関数を作る
        if (!hand.IsHavingItem()) return;


        //⑳仲介人からアイテムを受け取る
        Item gotItem = hand.GetGrabbingItem();

        //㉑元々持っていたアイテムを仲介人に渡す
        hand.SetGrabbingItem(MyItem);
        //㉑ドロップされたアイテムをMyItemにセットしなければならない
        SetItem(gotItem);
    }


    //OnDropが先に呼ばれる
    //スロット以外でドロップされたらOnDrop()は呼ばれず、OnEndDrag()のみ実行される
    public void OnEndDrag(PointerEventData eventData)
    {
        //⑰ドラッグが終了した時、複製したアイコンを破壊する。これでアイコンの増殖が起こらなくなる
        Destroy(draggingObj);

        //㉒OnEndDrag()関数を呼ぶのはドラッグの始点となるスロット　
        //ドラッグ終点で仲介人が持っていたアイテムを仲介人から受け取る
        //OnDrop()関数が呼ばれていなかったら、BeginDrag()を呼び出した関数が渡したアイテムが戻される。
        //スロット以外の場所でドロップしたら、元の場所で戻される
        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
    }
}

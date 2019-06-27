using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    //②運ぶアイテムをしまう変数
    private Item grabbingItem;

	// Update is called once per frame
	void Update () {
        //①ポインターを追いかけてほしいため
        this.transform.position = Input.mousePosition;
	}

    //③アイテムを受け渡す関数
    //ただ単にアイテムを渡すのではなく、渡したらnullにすることが肝心
    public Item GetGrabbingItem()
    {
        Item oldItem = grabbingItem;
        grabbingItem = null;
        return oldItem;
    }

    //④アイテムをハンドに渡す関数
    public void SetGrabbingItem(Item item)
    {
        grabbingItem = item;
        //パーティクルを再生
        //GetComponent<ParticleSystem>().Play();
    }

    //⑤自身がアイテムを持っているかの判定
    //nullのときにfalseを返す　　!=等しくなければtrue 等しければfalse
    public bool IsHavingItem()
    {
        return grabbingItem != null;
    }
}

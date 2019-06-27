using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalButton : MonoBehaviour {

    [SerializeField]
    private Sprite unpushedNormalButton;
    [SerializeField]
    private Sprite pushedNormalButton;

    ButtonSE buttonSe;

    // Use this for initialization
    void Start () {
        buttonSe = FindObjectOfType<ButtonSE>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Level.MyMode == 2)
        {
            //もしモードが１ならば、ボタンを pushedEasyButtonに
            this.gameObject.GetComponent<Image>().sprite = pushedNormalButton;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = unpushedNormalButton;
        }
    }

    public void NormalButtonClicked()
    {
        Level.MyMode = 2;
        Debug.Log("現在のモードは" + Level.MyMode);
        buttonSe.ClickSe();
    }
}

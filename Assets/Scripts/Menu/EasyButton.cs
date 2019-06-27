using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EasyButton : MonoBehaviour {

    [SerializeField]
    private Sprite unpushedEasyButton;
    [SerializeField]
    private Sprite pushedEasyButton;

    ButtonSE buttonSe;


	// Use this for initialization
	void Start () {
        buttonSe = FindObjectOfType<ButtonSE>();
	}

    private void Update()
    {
        if (Level.MyMode == 1)
        {
            //もしモードが１ならば、ボタンを pushedEasyButtonに
            this.gameObject.GetComponent<Image>().sprite = pushedEasyButton;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = unpushedEasyButton;
        }
    }

    public void EasyButtonClicked()
    {
        Level.MyMode = 1;
        Debug.Log("現在のモードは"+ Level.MyMode);
        buttonSe.ClickSe();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour {

    [SerializeField]
    private Sprite unpushedDifficultButton;
    [SerializeField]
    private Sprite pushedDifficultButton;

    ButtonSE buttonSe;

    // Use this for initialization
    void Start () {
        buttonSe = FindObjectOfType<ButtonSE>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Level.MyMode == 3)
        {
            //もしモードが１ならば、ボタンを pushedEasyButtonに
            this.gameObject.GetComponent<Image>().sprite = pushedDifficultButton;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = unpushedDifficultButton;
        }
    }

    public void DifficultButtonClicked()
    {
        Level.MyMode = 3;
        Debug.Log("現在のモードは"+Level.MyMode);
        buttonSe.ClickSe();
    }
}

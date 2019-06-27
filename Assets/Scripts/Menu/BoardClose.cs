using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//これは原則 CloseButtonにアタッチされている

public class BoardClose : MonoBehaviour {

    private MenuActivateButton menuActivateButton;

    ButtonSE buttonSe;


    private MenuToCredit menuToCredit;
    private MenuToSetting menuToSetting;
    private MenuToHowToPlay menuToHowToPlay;

    // Use this for initialization
    void Start () {
        menuActivateButton = FindObjectOfType<MenuActivateButton>();
        menuToCredit = FindObjectOfType<MenuToCredit>();
        menuToSetting = FindObjectOfType<MenuToSetting>();
        menuToHowToPlay = FindObjectOfType<MenuToHowToPlay>();

        //menuActivateButton.CloseButton.transform.position = new Vector3(540, 0);
    }

    public void CloseButtonClicked()
    {
        //クリック音再生
        buttonSe = FindObjectOfType<ButtonSE>();
        buttonSe.ClickSe();

        //クレジットボードを見ていた状態で CloseButtonを押したなら、
        if (menuToCredit.creditBoard)
        {
            //クレジットボードと『とじるボタン』を非表示に
            menuActivateButton.CreditBoard.SetActive(false);
            menuActivateButton.CloseButton.SetActive(false);

            //はじめる、あそびかた、せってい、クレジットボタンが表示に
            menuActivateButton.MenuBoard.SetActive(true);
            menuActivateButton.GameStartButton.SetActive(true);
            menuActivateButton.HowToPlayButton.SetActive(true);
            menuActivateButton.SettingButton.SetActive(true);
            menuActivateButton.CreditButton.SetActive(true);

            //念の為に、せっていボードと、あそびかたボードを非表示に
            menuActivateButton.SettingBoard.SetActive(false);
            menuActivateButton.HowToPlayBoard.SetActive(false);

            //クレジットボタンを押されていないことに
            menuToCredit.creditBoard = false;
        }

        //せっていボードを見ていた状態で CloseButtonを押したなら、
        if(menuToSetting.settingBoard)
        {
            //せっていボードと『とじるボタン』を非表示に
            menuActivateButton.SettingBoard.SetActive(false);
            menuActivateButton.EasyButton.SetActive(false);
            menuActivateButton.NormalButton.SetActive(false);
            menuActivateButton.DifficultButton.SetActive(false);
            menuActivateButton.CloseButton.SetActive(false);

            //はじめる、あそびかた、せってい、クレジットボタンが表示に
            menuActivateButton.MenuBoard.SetActive(true);
            menuActivateButton.GameStartButton.SetActive(true);
            menuActivateButton.HowToPlayButton.SetActive(true);
            menuActivateButton.SettingButton.SetActive(true);
            menuActivateButton.CreditButton.SetActive(true);

            //念の為に、クレジットボードと、あそびかたボードを非表示に
            menuActivateButton.CreditBoard.SetActive(false);
            menuActivateButton.HowToPlayBoard.SetActive(false);

            //せっていボタンが押されていないことに
            menuToSetting.settingBoard = false;
        }

        //あそびかたボードを見ていた状態で CloseButtonを押したなら、
        if (menuToHowToPlay.howToPlayBoard)
        {

            //あそびかたボードと『とじるボタン』を非表示に
            menuActivateButton.HowToPlayBoard.SetActive(false);
            menuActivateButton.CloseButton.SetActive(false);

            //はじめる、あそびかた、せってい、クレジットボタンが表示に
            menuActivateButton.MenuBoard.SetActive(true);
            menuActivateButton.GameStartButton.SetActive(true);
            menuActivateButton.HowToPlayButton.SetActive(true);
            menuActivateButton.SettingButton.SetActive(true);
            menuActivateButton.CreditButton.SetActive(true);

            //念の為に、クレジットボードとせっていボードとを非表示に
            menuActivateButton.CreditBoard.SetActive(false);
            menuActivateButton.SettingBoard.SetActive(false);

            //せっていボタンが押されていないことに
            menuToHowToPlay.howToPlayBoard = false;
        }
    }
}

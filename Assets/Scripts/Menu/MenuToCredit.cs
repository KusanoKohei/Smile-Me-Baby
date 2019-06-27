using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToCredit : MonoBehaviour {

    private MenuActivateButton menuActivateButton;

    ButtonSE buttonSe;


    public bool creditBoard;

    private void Start()
    {
        menuActivateButton = FindObjectOfType<MenuActivateButton>();
        creditBoard = false;
    }

    public void CreditButtonClicked()
    {
        //クリック音再生
        buttonSe = FindObjectOfType<ButtonSE>();
        buttonSe.ClickSe();

        menuActivateButton.CreditBoard.SetActive(true);
        menuActivateButton.CloseButton.SetActive(true);

        menuActivateButton.MenuBoard.SetActive(false);
        menuActivateButton.GameStartButton.SetActive(false);
        menuActivateButton.HowToPlayButton.SetActive(false);
        menuActivateButton.SettingButton.SetActive(false);
        menuActivateButton.CreditButton.SetActive(false);

        menuActivateButton.SettingBoard.SetActive(false);
        menuActivateButton.HowToPlayBoard.SetActive(false);

        creditBoard = true;
    }
}

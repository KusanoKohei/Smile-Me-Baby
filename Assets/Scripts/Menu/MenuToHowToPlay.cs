using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToHowToPlay : MonoBehaviour {

    private MenuActivateButton menuActivateButton;

    ButtonSE buttonSe;

    public bool howToPlayBoard;

    private void Start()
    {
        menuActivateButton = FindObjectOfType<MenuActivateButton>();
        howToPlayBoard = false;
    }

    public void HowToPlayButtonClicked()
    {
        //クリック音再生
        buttonSe = FindObjectOfType<ButtonSE>();
        buttonSe.ClickSe();


        menuActivateButton.HowToPlayBoard.SetActive(true);
        menuActivateButton.CloseButton.SetActive(true);

        menuActivateButton.MenuBoard.SetActive(false);
        menuActivateButton.GameStartButton.SetActive(false);
        menuActivateButton.HowToPlayButton.SetActive(false);
        menuActivateButton.SettingButton.SetActive(false);
        menuActivateButton.CreditButton.SetActive(false);

        menuActivateButton.SettingBoard.SetActive(false);
        menuActivateButton.CreditBoard.SetActive(false);

        howToPlayBoard = true;
    }
}

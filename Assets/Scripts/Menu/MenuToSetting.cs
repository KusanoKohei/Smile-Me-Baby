using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToSetting : MonoBehaviour {

    private MenuActivateButton menuActivateButton;

    ButtonSE buttonSe;

    public bool settingBoard;

    private void Start()
    {
        menuActivateButton = FindObjectOfType<MenuActivateButton>();
        settingBoard = false;
    }

    public void SettingButtonClicked()
    {
        //クリック音再生
        buttonSe = FindObjectOfType<ButtonSE>();
        buttonSe.ClickSe();

        menuActivateButton.SettingBoard.SetActive(true);
        menuActivateButton.EasyButton.SetActive(true);
        menuActivateButton.NormalButton.SetActive(true);
        menuActivateButton.DifficultButton.SetActive(true);
        menuActivateButton.CloseButton.SetActive(true);

        menuActivateButton.MenuBoard.SetActive(false);
        menuActivateButton.GameStartButton.SetActive(false);
        menuActivateButton.HowToPlayButton.SetActive(false);
        menuActivateButton.SettingButton.SetActive(false);
        menuActivateButton.CreditButton.SetActive(false);
        menuActivateButton.CreditBoard.SetActive(false);

        menuActivateButton.CreditBoard.SetActive(false);
        menuActivateButton.HowToPlayBoard.SetActive(false);

        settingBoard = true;
    }
}


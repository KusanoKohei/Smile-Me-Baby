using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivateButton : MonoBehaviour {

    [SerializeField]
    private GameObject gameStartButton;
    public GameObject GameStartButton { get { return gameStartButton; } set { gameStartButton = value; } }

    [SerializeField]
    private GameObject howToPlayButton;
    public GameObject HowToPlayButton{ get{ return howToPlayButton;} set{ howToPlayButton = value;}}

    [SerializeField]
    private GameObject settingButton;
    public GameObject SettingButton{ get{ return settingButton;} set{ settingButton = value;}}

    [SerializeField]
    private GameObject creditButton;
    public GameObject CreditButton{ get{ return creditButton;} set{ creditButton = value;}}

    [SerializeField]
    private GameObject closeButton;
    public GameObject CloseButton{ get{ return closeButton;} set{ closeButton = value;}}

    [SerializeField]
    private GameObject menuBoard;
    public GameObject MenuBoard{ get{ return menuBoard;} set{ menuBoard = value;}}

    [SerializeField]
    private GameObject creditBoard;
    public GameObject CreditBoard{ get{ return creditBoard;} set{ creditBoard = value;}}

    [SerializeField]
    private GameObject settingBoard;
    public GameObject SettingBoard { get { return settingBoard; } set { settingBoard = value; }}

    [SerializeField]
    private GameObject howToPlayBoard;
    public GameObject HowToPlayBoard{ get{ return howToPlayBoard;} set{ howToPlayBoard = value;}}

    [SerializeField]
    private GameObject easyButton;
    public GameObject EasyButton{ get{ return easyButton;} set{ easyButton = value;}}

    [SerializeField]
    private GameObject normalButton;
    public GameObject NormalButton { get { return normalButton; } set { normalButton = value; } }

    [SerializeField]
    private GameObject difficultButton;
    public GameObject DifficultButton { get { return difficultButton; } set { difficultButton = value; } }



    // Use this for initialization
    void Start () {
        this.MenuBoard.SetActive(true);
        this.GameStartButton.SetActive(true);
        this.HowToPlayButton.SetActive(true);
        this.SettingButton.SetActive(true);
        this.CreditButton.SetActive(true);

        this.CloseButton.SetActive(false);
        this.CreditBoard.SetActive(false);
        this.SettingBoard.SetActive(false);
        this.HowToPlayBoard.SetActive(false);

        this.EasyButton.SetActive(false);
        this.NormalButton.SetActive(false);
        this.DifficultButton.SetActive(false);
    }
}

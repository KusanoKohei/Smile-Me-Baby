using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultActivateSprite : MonoBehaviour {

    [SerializeField]
    private GameObject womanSprite;
    public GameObject WomanSprite{ get{ return womanSprite;} set{ womanSprite = value;}}

    [SerializeField]
    private GameObject serifBlowoff;
    public GameObject SerifBlowoff{ get{ return serifBlowoff;} set{ serifBlowoff = value;}}

    [SerializeField]
    private GameObject clearSprite;
    public GameObject ClearSprite{ get{ return clearSprite;} set{ clearSprite = value;}}

    [SerializeField]
    private GameObject gameOverSprite;
    public GameObject GameOverSprite{ get{ return gameOverSprite;} set { gameOverSprite = value; }}

    [SerializeField]
    private GameObject resultBoard;
    public GameObject ResultBoard{ get{ return resultBoard;} set{ resultBoard = value;}}

    [SerializeField]
    private GameObject babySprite;
    public GameObject BabySprite{ get{ return babySprite;} set{ babySprite = value;}}




    // Use this for initialization
    void Start () {
        this.WomanSprite.SetActive(false);
        this.SerifBlowoff.SetActive(false);
        this.ClearSprite.SetActive(false);
        this.gameOverSprite.SetActive(false);
        this.ResultBoard.SetActive(true);
        this.BabySprite.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

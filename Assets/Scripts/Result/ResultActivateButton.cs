using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultActivateButton : MonoBehaviour {

    [SerializeField]
    private GameObject titleButton;
    public GameObject TitleButton{ get{ return titleButton;} set{ titleButton = value;}}

    [SerializeField]
    private GameObject nextLevelButton;
    public GameObject NextLevelButton{ get{ return nextLevelButton;} set{ nextLevelButton = value;}}



    // Use this for initialization
    void Start () {
        this.TitleButton.SetActive(false);
        this.NextLevelButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

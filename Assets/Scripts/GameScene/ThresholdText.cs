using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThresholdText : MonoBehaviour {


	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text="けす ふきだし" + Result.MyThreshold+"こ いじょう"; 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

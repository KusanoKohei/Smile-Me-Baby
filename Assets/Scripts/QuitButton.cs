using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    public bool DontDestroyEnabled = true;

    private static QuitButton instance = null;
    public static QuitButton Instance
    {
        get { return instance; }
    }


    // Use this for initialization
    void Awake ()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        //Sceneを遷移してもオブジェクトが消えないようにする
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}

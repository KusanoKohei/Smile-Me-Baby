using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundScript : MonoBehaviour {

    public bool DontDestroyEnabled = true;

    private static MainSoundScript instance = null;
    public static MainSoundScript Instance{
        get{ return instance;}
    }


    void Awake () {

        this.gameObject.GetComponent<AudioSource>().volume = 0.5f;

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
            //Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this.gameObject);
    }

    public static void DeleteInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}

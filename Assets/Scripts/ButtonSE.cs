using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//これを記述しておくとこのコンポ―ネントを追加した際に
//一緒にAudioSourceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

public class ButtonSE : MonoBehaviour {

    public bool DontDestroyEnabled = true;

    private static ButtonSE instance = null;
    public static ButtonSE Instance
    {
        get { return instance; }
    }


    public AudioClip onDrop;  //吹き出しが消えたときの音

    private AudioSource mAudio;


    // Use this for initialization
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        //Sceneを遷移してもオブジェクトが消えないようにする
        DontDestroyOnLoad(this.gameObject);

        mAudio = GetComponent<AudioSource>();
        mAudio.volume = 0.5f;
    }

    public void ClickSe()
    {
        PlaySe(onDrop);
    }

    void PlaySe(AudioClip clip)
    {
        mAudio.PlayOneShot(clip);
    }


    //再生を止めたいときはこの関数を呼び出してオブジェクトを破壊する
    public static void DeleteSEobjectInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}

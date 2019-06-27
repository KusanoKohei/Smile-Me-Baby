using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//これを記述しておくとこのコンポ―ネントを追加した際に
//一緒にAudioSourceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

public class SEscript : MonoBehaviour {

    public AudioClip kirakira;  //吹き出しが消えたときの音
    public AudioClip fiveSe;    //5の倍数のときの音
    public AudioClip tenSe;       //10の倍数のときの音

    private AudioSource mAudio;
    private Score score;


	// Use this for initialization
	void Start () {
        mAudio = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
	}

    public void KirakiraSe()
    {
        PlaySe(kirakira);
    }

    public void FiveSe()
    {
        PlaySe(fiveSe);
        mAudio.volume = 0.5f;
    }

    public void TenSe()
    {
        PlaySe(tenSe);
        mAudio.volume = 0.6f;
    }

    void PlaySe(AudioClip clip)
    {
        mAudio.PlayOneShot(clip);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Score.blowoffCounter % 10 == 0&&Score.blowoffCounter!=0)
        {
            TenSe();
        }
        */
	}
}

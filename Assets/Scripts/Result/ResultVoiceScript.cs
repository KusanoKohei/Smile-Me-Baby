using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//これを記述しておくとこのコンポーネントを追加した際に
//一緒にAudioSorceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

public class ResultVoiceScript : MonoBehaviour
{
    private static VoiceScript instance = null;
    public static VoiceScript Instance
    {
        get { return instance; }
    }

    public AudioClip laugh;

    public AudioSource mAudio;

    private void Start()
    {
        mAudio = GetComponent<AudioSource>();
    }


    public void LaughVoice(AudioClip clip)
    {
        mAudio.PlayOneShot(clip);
    }
}

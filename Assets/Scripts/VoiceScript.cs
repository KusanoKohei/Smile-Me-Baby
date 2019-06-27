using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//これを記述しておくとこのコンポーネントを追加した際に
//一緒にAudioSorceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

public class VoiceScript : MonoBehaviour
{
    StatusCtrl status;

    //不滅オブジェクトから除外
    //public bool DontDestoryEnabled = true;

    private static VoiceScript instance = null;
    public static VoiceScript Instance
    {
        get { return instance; }
    }
    
    public AudioClip laugh;
    public AudioClip grizzle;
    public AudioClip crying;

    public AudioSource mAudio;

    public float timeleft;

    // Use this for initialization
    void Awake()
    {
        //最初に声が出るまで何秒か空ける
        timeleft = 5.0f;

        mAudio = GetComponent<AudioSource>();
        status = FindObjectOfType<StatusCtrl>();

        /*
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
        */
    }

    private void Update()
    {

        if (status.statusIdle)  //状態がIdleなら
        {
            timeleft -= Time.deltaTime;
            //一定時間経過ごとに声を出す
            if (timeleft<=0.0f)
            {
                mAudio.PlayOneShot(laugh);
                timeleft = 4.0f;
            }
        }

        if (status.statusGrizzle)
        {
            timeleft -= Time.deltaTime;

            if(timeleft<=0.0f)
            {
                mAudio.volume = 0.6f;
                mAudio.PlayOneShot(grizzle);
                timeleft = 3.5f;
            }
        }

        if (status.statusCrying)
        {
            timeleft -= Time.deltaTime;

            if(timeleft<=0.0f)
            {
                mAudio.volume = 0.6f;
                mAudio.PlayOneShot(crying);
                timeleft = 3.0f;
            }
        }
    }
}

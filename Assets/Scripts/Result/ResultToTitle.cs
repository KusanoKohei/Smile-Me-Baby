using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultToTitle : MonoBehaviour {

    Level level;

    public void TitleButtonClicked()
    {
        level = FindObjectOfType<Level>();

        MainSoundScript.DeleteInstance();
        ButtonSE.DeleteSEobjectInstance();
        level.initParameter();
        SceneManager.LoadScene("Title");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneToMenu : MonoBehaviour {

    Level level=null;


    public void GameSceneTitleButtonClicked()
    {
        level = FindObjectOfType<Level>();

        //MainSoundScript.DeleteInstance();
        ButtonSE.DeleteSEobjectInstance();
        //level.initParameter();
        SceneManager.LoadScene("Menu");
    }

}

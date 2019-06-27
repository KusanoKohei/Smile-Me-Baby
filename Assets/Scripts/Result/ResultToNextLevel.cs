using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultToNextLevel : MonoBehaviour {

    public void NextLevelButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

}

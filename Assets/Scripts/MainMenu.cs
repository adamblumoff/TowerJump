using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void LoadScene(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

}

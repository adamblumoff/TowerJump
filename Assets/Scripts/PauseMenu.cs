using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    bool paused = false;
    public string pauseMenuSceneName = "PauseMenu";

    public void PausedGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;

            SceneManager.UnloadSceneAsync(pauseMenuSceneName);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
        }
    }

        public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}

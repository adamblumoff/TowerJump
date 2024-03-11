using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel; //Canvas for pause menu
    private bool paused = false; 
    public void TogglePause()
    {
        // This will toggle the active state of the pause menu canvas
        PauseMenuPanel.SetActive(!PauseMenuPanel.activeSelf);

        // If the pause menu is now active, we should pause the game
        if (PauseMenuPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else // If it's not active, we should resume the game
        {
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        // Deactivate the pause menu UI panel to hide it
        PauseMenuPanel.SetActive(false);
        // Resume the game by setting the time scale back to normal
        Time.timeScale = 1f;
        // Optionally, you might want to set 'paused' to false here if you use it to check the game's pause state elsewhere
        paused = false;
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

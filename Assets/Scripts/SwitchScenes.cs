using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScenes : MonoBehaviour
{
    [HideInInspector]
    public bool gameIsPaused = false;

    public GameObject UI;

    public GameObject pauseUI;

    public virtual void Start()
    {            
        
    }

    public void ToggleButtons()
    {
        Button[] buttons = UI.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = !buttons[i].enabled;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void RestartGame()
    {
        if (gameIsPaused)
            Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

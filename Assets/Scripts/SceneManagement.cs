using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class SceneManagement : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSelectedLevel()
    {
        EventSystem eventSystem = EventSystem.current;
        string buttonName = eventSystem.currentSelectedGameObject.name;
        SceneManager.LoadScene(buttonName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

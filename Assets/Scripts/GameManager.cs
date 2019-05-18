using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int starCount = 0;
    public List<LevelInfo> levels = new List<LevelInfo>();

    void Start()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
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

    public LevelInfo GetLevelInList(string levelName)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelName == levelName)
                return levels[i];
        }
        return null;
    }
}

public class LevelInfo
{
    public string levelName;
    public int starsReceived;
}
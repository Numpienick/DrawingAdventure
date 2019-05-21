using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : SceneManagement
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

        AddLevelToList("Level1", 0, 0);
    }    

    public void AddLevelToList(string levelName, int starsReceived, int starsRequired)
    {
        levels.Add(new LevelInfo
        {
            levelName = levelName,
            starsReceived = starsReceived,
            starsRequired = starsRequired
        });
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
    public int starsRequired;
}

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
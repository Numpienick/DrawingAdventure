using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : SceneManagement
{
    public static GameManager instance;
    public List<LevelInfo> levels { get; private set; }
    public int starCount = 0;
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

    public void AddLevelToList(string levelName, int starsWon, int starsRequired)
    {
        LevelInfo tempLevel = new LevelInfo
        {
            LevelName = levelName,
            StarsWon = starsWon,
            StarsRequired = starsRequired
        };
        levels.Add(tempLevel);
    }

    public LevelInfo GetLevelInList(string levelName)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].LevelName == levelName)
                return levels[i];
        }
        return null;
    }
}
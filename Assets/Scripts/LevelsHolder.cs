using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelsHolder : MonoBehaviour
{
    void Start()
    {
        Debug.Log(GameManager.instance.starCount);
        List<LevelButton> levelButtons = new List<LevelButton>();

        int i = 0;
        foreach (Transform child in transform)
        {
            levelButtons.Add(child.GetComponent<LevelButton>());
            //For level 2
            if (i == 1)
            {
                levelButtons[i].ActivateButton(i + 1);
                GameManager.instance.AddLevelToList(levelButtons[i].name, 0, i + 1);
            }
            //For all levels after level 2
            else if (i > 0)
            {
                levelButtons[i].ActivateButton(i + 2);
                GameManager.instance.AddLevelToList(levelButtons[i].name, 0, i + 2);
            }
            i++;
        }
    }

    public void LoadSelectedLevel()
    {
        EventSystem eventSystem = EventSystem.current;
        string buttonName = eventSystem.currentSelectedGameObject.name;
        SceneManager.LoadScene(buttonName);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public void ActivateButton(int starsRequired)
    {
        if (GameManager.instance.starCount >= starsRequired)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public void ActivateButton(int starsRequired)
    {
        if (GameManager.instance.starCount >= starsRequired)
        {
            Debug.Log("stars required: " + starsRequired);
            GetComponent<Button>().interactable = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUIManager : SceneManagement
{
    public void Finished(string currentLevelName, int starsWon)
    {
        gameObject.SetActive(true);
        Player player = FindObjectOfType<Player>();
        Transform holderObj = transform.Find("Holder");
        List<Image> children = new List<Image>();

        foreach (Image img in holderObj.Find("Stars").GetComponentsInChildren<Image>())
        {
            children.Add(img);
        }

        for (int i = 0; i < starsWon; i++)
        {
            children[i].sprite = player.star.GetComponentInChildren<Image>().sprite;
        }

        int nextLevelInt;
        int.TryParse(new string(currentLevelName.Replace("Level", string.Empty).ToCharArray()), out nextLevelInt);
        nextLevelInt += 1;

        LevelInfo nextLevel = GameManager.instance.GetLevelInList(string.Format("Level{0}", nextLevelInt));
        if (GameManager.instance.starCount < nextLevel.starsRequired)
        {
            holderObj.Find("Next Level").GetComponent<Button>().interactable = false;
        }
    }
}

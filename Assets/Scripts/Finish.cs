using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public GameObject finishUI;
    public bool dynamicRB = false;

    public void Start()
    {
        finishUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            List<Image> children = new List<Image>();
            finishUI.SetActive(true);
            foreach (Image img in finishUI.transform.Find("Holder").Find("Stars").GetComponentsInChildren<Image>())
            {
                children.Add(img);
            }

            int starsWon = player.stars.Count;
            for (int i = 0; i < starsWon; i++)
            {
                children[i].sprite = player.star.GetComponentInChildren<Image>().sprite;
            }

            string thisLevelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            LevelInfo thisLevel = GameManager.instance.GetLevelInList(thisLevelName);

            if (thisLevel == null)
            {
                GameManager.instance.levels.Add(new LevelInfo
                {
                    levelName = thisLevelName,
                    starsReceived = starsWon
                });
                GameManager.instance.starCount += starsWon;
            }
            else if (thisLevel.starsReceived < starsWon)
            {
                LevelInfo thisLevelInGameManager = GameManager.instance.GetLevelInList(thisLevelName);
                GameManager.instance.starCount += (starsWon - thisLevelInGameManager.starsReceived);
                thisLevelInGameManager.starsReceived = starsWon;
            }
        }
    }
}

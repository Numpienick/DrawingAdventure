using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public bool dynamicRB = false;

    FinishUIManager finishUI;

    private void Start()
    {
        finishUI = FindObjectOfType<FinishUIManager>();
        finishUI.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            string currentLevelName = SceneManager.GetActiveScene().name;
            int starsWon = player.stars.Count;

            LevelInfo thisLevel = GameManager.instance.GetLevelInList(currentLevelName);

            if (thisLevel.starsReceived < starsWon || starsWon == 0)
            {
                GameManager.instance.starCount += (starsWon - thisLevel.starsReceived);
                thisLevel.starsReceived = starsWon;
            }
            finishUI.Finished(currentLevelName, starsWon);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : GameManager
{
    public GameObject finishUI;

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

            for (int i = 0; i < player.stars.Count; i++)
            {
                children[i].sprite = player.star.GetComponentInChildren<Image>().sprite;
            }

            ToggleButtons();
        }
    }
}

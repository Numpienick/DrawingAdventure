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
            finishUI.SetActive(true);
            ToggleButtons();
        }
    }
}

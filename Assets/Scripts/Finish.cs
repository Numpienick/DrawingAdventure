using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : SwitchScenes
{
    public GameObject finishUI;

    public override void Start()
    {
        base.Start();
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
    // Update is called once per frame
    void Update()
    {

    }
}

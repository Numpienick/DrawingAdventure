using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : SwitchScenes
{
    private float ink;

    public float currentInk = 100;
    public float maxInk = 50;

    private float minX, maxX, minY, maxY;

    private int maxStars = 3;

    private Rigidbody2D rb;

    public Slider inkBar;


    public GameObject border;


    public override void Start()
    {
        base.Start();
        string levelCount = "";
        string currentLevelName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < currentLevelName.Length; i++)
        {
            if (char.IsDigit(currentLevelName[i]))
                levelCount += currentLevelName[i];
        }
        inkBar.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + levelCount);

        rb = GetComponent<Rigidbody2D>();

        if (pauseUI)
            pauseUI.SetActive(false);

        currentInk = maxInk;

        ///This places borders around the level, but I found out that this isn't actually needed
        /*Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        for (int i = 0; i < 4; ++i)
        {
            GameObject p = Instantiate(border);
            p.name = "Border " + i.ToString();
            p.transform.position = -planes[i].normal * planes[i].distance;
            p.transform.rotation = Quaternion.FromToRotation(Vector3.left, planes[i].normal);
        }*/
        ///
    }

    void Update()
    {
        inkBar.value = CalculateInk();

        //If amount of ink is under a certain treshold, reduce the amount of stars that the player can achieve for passing the level
        if (maxStars > 1 && currentInk <= (maxInk / 3 * maxStars - 1))
        {
            maxStars = maxStars - 1;
        }
    }

    float CalculateInk()
    {
        return currentInk / maxInk;
    }

    public void DrainInk(float value)
    {
        currentInk -= value;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        ToggleButtons();
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        ToggleButtons();
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void PlayGame()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
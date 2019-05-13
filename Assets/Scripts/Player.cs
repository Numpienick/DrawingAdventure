using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float currentInk = 100;

    public float maxInk = 50;
    public Slider inkBar;
    public GameObject border;

    float ink;
    float minX, maxX, minY, maxY;
    int maxStars = 3;

    Rigidbody2D rb;

    public void Start()
    {
        string levelCount = "";
        string currentLevelName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < currentLevelName.Length; i++)
        {
            if (char.IsDigit(currentLevelName[i]))
                levelCount += currentLevelName[i];
        }
        inkBar.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + levelCount);

        rb = GetComponent<Rigidbody2D>();

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

    public void PlayGame()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
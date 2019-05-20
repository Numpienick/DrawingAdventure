using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float currentInk = 100;

    public float maxInk = 50;
    public Slider inkBar;
    public GameObject star;

    public List<GameObject> stars = new List<GameObject>();

    float ink;
    float minX, maxX, minY, maxY;
    int maxStars = 3;
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentInk = maxInk;

        SpawnStars();

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

        //If the amount of ink is under a certain treshold, 
        //reduce the amount of stars that the player can achieve for passing the level
        if (maxStars > 1 && currentInk <= ((maxInk / 3) * (maxStars - 1)))
        {
            maxStars = maxStars - 1;
            RemoveStars();
        }
    }

    public float CalculateInk()
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
        Finish finish = FindObjectOfType<Finish>();

        if (finish.dynamicRB == true)
            finish.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void SpawnStars()
    {
        Transform drainBar = GameObject.Find("Drain Bar").transform;
        float xOffset = 300;
        for (int i = 0; i < maxStars; i++)
        {
            GameObject starObject = Instantiate(star, new Vector3(drainBar.position.x + xOffset, drainBar.position.y, transform.position.z), Quaternion.identity, drainBar);
            stars.Add(starObject);
            xOffset += 50;
        }
    }

    void RemoveStars()
    {
        Destroy(stars[maxStars]);
        stars.RemoveAt(maxStars);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLine : MonoBehaviour
{
    private LineCreator lineCreator;

    private void Start()
    {
        lineCreator = FindObjectOfType<LineCreator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("collided");
        //if (collision.transform.tag == "Line")
           // lineCreator.activeLine = null;
    }
}

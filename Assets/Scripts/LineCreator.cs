using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    private Player player;

    public LayerMask mask;

    Vector3 touchPos;

    [HideInInspector]
    public Line activeLine;

    int j = 0;

    bool firstLine = false;
    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
#if UNITY_EDITOR
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
        /*if (Input.GetMouseButtonDown(0)/*(Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("shot ray");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 100, mask);
            if (hit.collider != null)
            {
                Debug.Log("Something Hit");               
            }
            //if (Physics2D.Raycast(raycast, out raycastHit, 100, mask, QueryTriggerInteraction.Collide))
        }*/

        /*if (Input.GetMouseButton(0))
        {
            Obstruction();
            if (Obstruction() == true)
            {
                activeLine = null;
            }
        }*/
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
#else
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
#endif
            if (player.currentInk > 0 && activeLine == null && Obstruction() == false)
            {
                GameObject lineGO = Instantiate(linePrefab);
                lineGO.name = linePrefab.name + j;
                j++;
                activeLine = lineGO.GetComponent<Line>();
            }
        }


        if (activeLine != null)
        {
            activeLine.UpdateLine(touchPos);
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0) || player.currentInk <= 0)
        {
#else
        if (Input.touchCount == 0 || player.currentInk <= 0)
        {
#endif
            if (activeLine != null)
            {
                if (firstLine == false)
                    player.PlayGame();

                firstLine = true;
                DisableLine();
            }
        }
    }

    bool Obstruction()
    {
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero, 100, mask);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DisableLine()
    {
        activeLine.rb.bodyType = RigidbodyType2D.Dynamic;
        foreach (Collider2D collider in activeLine.colliders)
        {
            collider.gameObject.layer = 9;
            collider.isTrigger = false;
        }
        activeLine = null;
    }
}

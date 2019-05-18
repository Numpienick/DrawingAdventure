using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineCreator : MonoBehaviour
{
    [HideInInspector]
    public Line activeLine;
    public GameObject linePrefab;
    public LayerMask mask;

    int j = 0;
    bool firstLine = false;
    private Player player;
    Vector3 touchPos;
    Touch touch;
    
    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
#if UNITY_EDITOR
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
#else
        touch = Input.GetTouch(0);
        touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        if (touch.phase == TouchPhase.Began)
        {
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
#if UNITY_EDITOR
            if (Input.GetMouseButtonUp(0) || player.currentInk <= 0)
            {
#else
            if (touch.phase == TouchPhase.Ended || player.currentInk <= 0)
            {
#endif
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

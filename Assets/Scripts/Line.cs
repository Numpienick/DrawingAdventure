using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask layerMask;
    public LineRenderer lineRenderer;
    public List<Collider2D> colliders = new List<Collider2D>();

    int i = 0;
    Player player;
    List<Vector2> points;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    public void UpdateLine(Vector2 touchPos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(touchPos);
            return;
        }

        if (Vector2.Distance(points.Last(), touchPos) > .1f && AllowedToSpawn(touchPos) == true)
            SetPoint(touchPos);
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        if (player != null && i > 0)
            player.DrainInk(Vector2.Distance(points[i - 1], points.Last()));
        i++;

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            CreateCollider();
        }
    }

    bool AllowedToSpawn(Vector2 touchPos)
    {
        Vector2 lastPos = new Vector2(points.Last().x, points.Last().y);
        RaycastHit2D hit = Physics2D.Linecast(lastPos, new Vector2(touchPos.x, touchPos.y), layerMask);

        if (hit.collider != null)
        {
            Debug.DrawLine(lastPos, new Vector2(touchPos.x, touchPos.y), Color.red, 5f);
            return false;
        }
        else
        {
            Debug.DrawLine(lastPos, new Vector2(touchPos.x, touchPos.y), Color.red, 5f);
            return true;
        }

    }

    //Creates a Boxcollider between the latest point and the next to latest point of the line
    public void CreateCollider()
    {
        Vector2 startPoint = points[points.LastIndexOf(points.Last()) - 1];
        Vector2 endPoint = points.Last();
        BoxCollider2D lineCollider = new GameObject("LineCollider").AddComponent<BoxCollider2D>();

        lineCollider.isTrigger = true;

        lineCollider.transform.parent = lineRenderer.transform;

        float lineWidth = lineRenderer.endWidth;

        float lineLength = Vector2.Distance(startPoint, endPoint);

        lineCollider.size = new Vector2(lineLength, lineWidth);

        Vector2 midPoint = (startPoint + endPoint) / 2;

        lineCollider.transform.position = midPoint;

        float angle = Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x));

        angle *= Mathf.Rad2Deg;

        lineCollider.transform.Rotate(0, 0, angle);

        colliders.Add(lineCollider);
    }
}

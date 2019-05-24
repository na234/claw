using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    float x;
    float y;
    Vector2 dist;
    public bool drag = false;
    bool trigger = false;
    public GameObject connectedObject = null;
    Collider2D col2D;
    Collider2D[] result;

    void Awake()
    {
        col2D = GetComponent<Collider2D>();
        result = new Collider2D[1];
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        if (!drag)
        {
            OverlapCount();
        }
    }

    void OnMouseDown()
    {
        drag = true;
    }
    void OnMouseUp()
    {
        drag = false;
        dist = transform.position - Input.mousePosition;
    }
    void OnMouseDrag()
    {
        if (trigger)
        {
            return;
        }
        transform.root.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10f));
    }
    void OverlapCount()
    {
        int count = col2D.OverlapCollider(new ContactFilter2D(), result);
        Debug.Log("Overlap=" + count);
        if (count > 0)
        {
            if (connectedObject == null)
            {
                Debug.Log(result[0].name);
                Vector3 pos = this.transform.root.position;
                pos.y -= 10f;
                result[0].transform.root.position = pos;
                connectedObject = result[0].gameObject;
            }
        }
        else
        {
            connectedObject = null;
        }
    }
}
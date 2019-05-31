using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 dist;
    public bool drag = false;
    public GameObject aboveObject = null;
    Collider2D col2D;
    Collider2D[] result = new Collider2D[1];

    void Start()
    {
        col2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10f));
        if (!drag && aboveObject != null)
        {
            Vector3 pos = aboveObject.transform.position;
            pos.y -= 35f;
            transform.root.position = pos;
        }
    }

    void OnMouseDown()
    {
        drag = true;
        dist = transform.root.position - mousePosition;
    }
    void OnMouseUp()
    {
        drag = false;
    }
    void OnMouseDrag()
    {
        transform.root.position = mousePosition + dist;
        OverlapCount();
    }
    void OverlapCount()
    {
        int count = col2D.OverlapCollider(new ContactFilter2D(), result);
        Debug.Log("Overlap=" + count);
        if (count > 0)
        {
            Debug.Log(result[0].name);
            aboveObject = result[0].transform.root.gameObject;
        }
        else
        {
            aboveObject = null;
        }
    }
}
using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    float x;
    float y;
    public bool drag = false;
    bool trigger = false;
    public GameObject connectedObject;

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
    }

    void OnMouseUp()
    {
        drag = false;
    }
    void OnMouseDrag()
    {
        drag = true;
        if (trigger)
        {
            return;
        }
        transform.root.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10f));
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!drag)
        {
            return;
        }
        //other.transform.root.position = new Vector3(transform.root.position.x, transform.root.position.y - 10f, 10f);
        transform.root.position = new Vector3(other.transform.root.position.x, other.transform.root.position.y - 10f, 10f);
        connectedObject = other.transform.gameObject;
    }
    void OnTriggerEnter2D()
    {
        //trigger = true;
    }
    void OnTriggerExit2D()
    {
        trigger = false;
        connectedObject = null;
    }
}
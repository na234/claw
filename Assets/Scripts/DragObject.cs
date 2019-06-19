using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    float x;
    float y;
    public bool drag = false;
    bool trigger = false;
    public GameObject connectedObject;
    public GameObject parentObject;

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        if ( parentObject != null ) {
            Vector3 pos = parentObject.transform.position;
            transform.position = new Vector3(pos.x, pos.y+5, pos.z);
        }
    }

    void OnMouseUp()
    {
        drag = false;
        if ( trigger ) {
            if ( connectedObject.transform.position.y > transform.position.y ) {
                parentObject = connectedObject;
            }
        }

    }
    void OnMouseDrag()
    {
        drag = true;
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
        trigger = true;
    }
    void OnTriggerExit2D()
    {
        trigger = false;
        connectedObject = null;
        parentObject = null;
    }
}
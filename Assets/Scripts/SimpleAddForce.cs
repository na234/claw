using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100.0f, 0f));
    }
}

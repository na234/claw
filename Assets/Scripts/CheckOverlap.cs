using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverlap : MonoBehaviour
{

    Collider2D col2D;
    Collider2D[] result;

    void Awake()
    {
        col2D = GetComponent<Collider2D>();
        result = new Collider2D[10];
    }

    void OnEnable()
    {
    }

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        OverlapCount();
    }

    void OverlapCount()
    {
        int count = col2D.OverlapCollider(new ContactFilter2D(), result);
        Debug.Log("Overlap=" + count);
        foreach (var r in result)
        {
            if (r != null) Debug.Log(r.name);
        }
    }

}
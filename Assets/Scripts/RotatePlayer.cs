using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePlayer : MonoBehaviour
{
    GameObject player;
    InputField inputField;

    void Start()
    {
        player = GameObject.Find("Player");
        inputField = GetComponentInChildren<InputField>();
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        {
            float angle;
            float.TryParse(inputField.text, out angle);
            player.transform.Rotate(0, 0, -angle);
        }
    }
}

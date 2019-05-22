using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayerVertical : MonoBehaviour
{
    public Camera mainCamera;
    GameObject player;
    InputField inputField;
    bool reverce = false;
    Vector3 leftBottom;
    Vector3 rightTop;

    void Start()
    {
        player = GameObject.Find("Player");
        inputField = GetComponentInChildren<InputField>();
        leftBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        rightTop = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }
    void Update()
    {
        Vector3 pos = player.transform.position;
        //if (Input.GetKey(KeyCode.Space))
        {
            float value;
            float.TryParse(inputField.text, out value);
            if (rightTop.y < pos.y)
            {
                reverce = true;
            }
            else if (pos.y < leftBottom.y)
            {
                reverce = false;
            }
            if (reverce)
            {
                value *= -1f;
            }
            pos.y += value;
            player.transform.position = pos;
        }
    }
}

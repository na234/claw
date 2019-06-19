using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer: MonoBehaviour
{
    Camera mainCamera;
    GameObject player;
    InputField inputField;
    Vector3 leftBottom;
    Vector3 rightTop;

    void Start()
    {
        mainCamera = Camera.main;
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
            player.transform.Translate(value, 0, 0);
            pos = player.transform.position;
            if (pos.x < leftBottom.x)
            {
                pos.x = leftBottom.x;
            }
            else if (rightTop.x < pos.x)
            {
                pos.x = rightTop.x;
            }
            if (pos.y < leftBottom.y)
            {
                pos.y = leftBottom.y;
            }
            else if (rightTop.y < pos.y)
            {
                pos.y = rightTop.y;
            }
            player.transform.position = pos;
        }
    }
}

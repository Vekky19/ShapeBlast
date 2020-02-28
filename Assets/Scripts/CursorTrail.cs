using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    Transform cursor;

    void Start()
    {
        cursor = GetComponent<Transform>();
    }

    void Update()
    {
        cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = new Vector3(cursor.position.x, cursor.position.y, 0);
    }
}

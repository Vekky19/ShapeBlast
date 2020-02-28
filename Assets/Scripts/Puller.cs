using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    public float speed;
    public Transform target;

    Vector3 rotation;

    void Start()
    {
        rotation = new Vector3(0,0,1);
    }

    void FixedUpdate()
    {
        transform.RotateAround(target.position, rotation, speed);
    }
}

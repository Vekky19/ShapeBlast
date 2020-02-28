using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJuice : MonoBehaviour
{
    Transform Shape;
    bool shrink;

    Vector3 shapeScale;

    void Start()
    {
        Shape = GetComponent<Transform>();
        shrink = false;

        shapeScale = Shape.transform.localScale;
    }

    private void OnMouseEnter()
    {
        GrowShape();
        shrink = true;
    }

    void GrowShape()
    {
        Shape.transform.localScale = new Vector3(shapeScale.x + 1, shapeScale.y + 1, shapeScale.z);
    }

    void Update()
    {
        if (shrink == true)
        {
            if (Shape.transform.localScale.x > shapeScale.x)
            {
                Shape.transform.localScale = new Vector3(Shape.transform.localScale.x - 0.05f, Shape.transform.localScale.y, Shape.transform.localScale.z);
            }
            if (Shape.transform.localScale.y > shapeScale.y)
            {
                Shape.transform.localScale = new Vector3(Shape.transform.localScale.x, Shape.transform.localScale.y - 0.05f, Shape.transform.localScale.z);
            }
        }
    }
}

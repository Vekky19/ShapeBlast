using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject noclickability;
    public bool isActive;

    private void Start()
    {
        isActive = false;
    }

    public void ChangeActive()
    {
        isActive = !isActive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Square")
        {
            collision.GetComponent<ShapeScript>().DestroyShape();
        }
        if (collision.tag == "Circle")
        {
            collision.GetComponent<ShapeScript>().DestroyShape();
        }
        if (collision.tag == "Triangle")
        {
            collision.GetComponent<ShapeScript>().DestroyShape();
        }
        if (collision.tag == "Pentagon")
        {
            collision.GetComponent<ShapeScript>().DestroyShape();
        }
        if (collision.tag == "SquareProj")
        {
            collision.GetComponent<ShapeScript>().DestroyShape();
        }
    }

    void Update()
    {
        if (isActive == false)
        {
            noclickability.transform.position = new Vector3(0, -10, 0);
        }
        else if (isActive == true)
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    Transform Bouncer;
    SpriteRenderer sprite;

    float ogX, ogY;

    private void Start()
    {
        Bouncer = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        ogX = Bouncer.transform.localScale.x;
        ogY = Bouncer.transform.localScale.y;
    }

    void GrowPad(Color shapeColor)
    {
        Bouncer.transform.localScale = new Vector3(Bouncer.localScale.x, Bouncer.localScale.y + 1, Bouncer.localScale.z);
        sprite.color = shapeColor;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GrowPad(collision.gameObject.GetComponent<SpriteRenderer>().color);
    }

    private void Update()
    {
        //if (Bouncer.transform.localScale.x > ogX)
        //{
        //    Bouncer.transform.localScale = new Vector3(Bouncer.transform.localScale.x - 0.15f, Bouncer.transform.localScale.y, Bouncer.transform.localScale.z);
        //}
        if (Bouncer.transform.localScale.y > ogY)
        {
            Bouncer.transform.localScale = new Vector3(Bouncer.transform.localScale.x, Bouncer.transform.localScale.y - 0.15f, Bouncer.transform.localScale.z);
        }
    }
}

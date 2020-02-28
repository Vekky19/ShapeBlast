using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    Color ShapeColor;

    bool canBreakCombo;
    Transform firePoint;
    public GameObject squarePrefab;

    AudioSource soundSource;
    public AudioClip[] destroySounds;

    private void Start()
    {
        Destroy(this.gameObject, 10);
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = destroySounds[Random.Range(0, destroySounds.Length)];

        firePoint = GetComponentInChildren<Transform>();

        canBreakCombo = true;


        if (this.tag == "Square")
        {
            ShapeColor = new Color(0,122,255,255);
        }
        if (this.tag == "Circle")
        {
            ShapeColor = new Color(255,146,0,255);
        }
        if (this.tag == "Triangle")
        {
            ShapeColor = new Color(255,0,0,255);
        }
        if (this.tag == "Pentagon")
        {
            ShapeColor = new Color(255, 0, 255, 255);
        }
        if (this.tag == "SquareProj")
        {
            ShapeColor = new Color(0, 0, 255, 255);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ParticleOnClick.Instance.PlayEffect(this.transform, ShapeColor);
            ScoreHandler.Instance.AddScore(1, ShapeColor);
            soundSource.Play();
            if (soundSource.isPlaying)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                this.gameObject.GetComponent<TrailRenderer>().enabled = false;

                ScoreHandler.Instance.combo += 1;
                ScoreHandler.Instance.comboText.text = "x" + ScoreHandler.Instance.combo.ToString();

                canBreakCombo = false;
            }
            else
            {
                Destroy(this.gameObject);
            }

            if (this.tag == "Square")
            {
                SpawnProj();
            }
        }
    }

    void SpawnProj()
    {
        Vector2 square2pos = new Vector2(firePoint.position.x, firePoint.position.y + 1);
        GameObject square1 = Instantiate(squarePrefab, firePoint.position, firePoint.rotation);
        GameObject square2 = Instantiate(squarePrefab, square2pos, firePoint.rotation);

        square1.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
        square2.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
    }

    public void DestroyShape()
    {
        ParticleOnClick.Instance.PlayEffect(this.transform, ShapeColor);
        ScoreHandler.Instance.AddScore(1, ShapeColor);
        soundSource.Play();
        if (soundSource.isPlaying)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;

            ScoreHandler.Instance.combo += 1;
            ScoreHandler.Instance.comboText.text = "x" + ScoreHandler.Instance.combo.ToString();

            canBreakCombo = false;
        }
        else
        {
            if (this.tag == "Square")
            {
                SpawnProj();
            }

            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (this.gameObject.transform.position.y < -5.5f && canBreakCombo == true)
        {
            Destroy(this.gameObject);
            if (canBreakCombo == true)
            {
                ScoreHandler.Instance.BreakCombo();
            }
            ScoreHandler.Instance.comboText.text = "x" + ScoreHandler.Instance.combo.ToString();
        }
    }
}

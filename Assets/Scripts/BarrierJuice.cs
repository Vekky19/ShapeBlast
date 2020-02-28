using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierJuice : MonoBehaviour
{
    public SpriteRenderer sprite;
    public AudioClip[] collisionSounds;

    AudioSource soundSource;

    Color color;

    public float value;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = new Color(255, 255, 255, 255);

        soundSource = GetComponent<AudioSource>();

        value = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundSource.clip = collisionSounds[Random.Range(0, collisionSounds.Length)];
        soundSource.Play();
    }

    void GetColor()
    {
        sprite.color = ScoreHandler.Instance.temp;
        value = 0;
    }

    void Update()
    {
        value += 0.25f * Time.deltaTime;
        
        if (ScoreHandler.Instance.changeColor == true)
        {
            GetColor();
        }
        sprite.color = Color.Lerp(sprite.color, Color.white, value);
    }
}

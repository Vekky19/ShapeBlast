using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;
    public Text scoreText;
    public Text comboText;
    int score;

    public int combo;
    bool shrinkCombo;
    float value;
    public AudioSource ComboBreak;

    public Color temp;
    public bool changeColor;

    bool shrink;

    public ParticleSystem clickFX;
    public Transform Cursor;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        score = 0;
        shrink = false;
        scoreText.text = "0";

        temp = Color.black;
        changeColor = false;

        combo = 0;
        shrinkCombo = false;
        value = 0;
        comboText.text = "x" + combo.ToString();
        ComboBreak = GetComponent<AudioSource>();
    }

    private void MouseClickFX()
    {
        ParticleSystem fx = Instantiate(clickFX, Cursor.position, Cursor.rotation);
        Destroy(fx, 2);
    }

    public void ChangeColor(Color color)
    {
        changeColor = true;
        temp = color;
        //if (temp == color)
        //{
        //    temp = color;
        //    changeColor = false;
        //}
        //else
        //{
        //    temp = color;
        //    changeColor = true;
        //}
    }

    public void AddScore(int amount, Color color)
    {
        ChangeColor(color);
        score += amount + combo;
        scoreText.text = score.ToString();
        scoreText.color = temp;
        GrowText();
        shrink = true;
    }

    void GrowText()
    {
        scoreText.transform.localScale = new Vector3(scoreText.transform.localScale.x + 3, scoreText.transform.localScale.y + 3, scoreText.transform.localScale.z);
    }


    public void BreakCombo()
    {
        if (combo != 0)
        {
            combo = 0;
            ComboBreak.Play();

            comboText.transform.localScale = new Vector3(comboText.transform.localScale.x + 3, comboText.transform.localScale.y + 3, comboText.transform.localScale.z);
            shrinkCombo = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClickFX();
        }

        if (shrink == true)
        {
            if (scoreText.transform.localScale.x > 2.5)
            {
                scoreText.transform.localScale = new Vector3(scoreText.transform.localScale.x - 0.15f, scoreText.transform.localScale.y, scoreText.transform.localScale.z);
            }
            if (scoreText.transform.localScale.y > 2.5)
            {
                scoreText.transform.localScale = new Vector3(scoreText.transform.localScale.x, scoreText.transform.localScale.y - 0.15f, scoreText.transform.localScale.z);
            }
        }

        if (shrinkCombo == true)
        {
            if (comboText.transform.localScale.x > 2.5)
            {
                comboText.transform.localScale = new Vector3(comboText.transform.localScale.x - 0.15f, comboText.transform.localScale.y, comboText.transform.localScale.z);
            }
            if (comboText.transform.localScale.y > 2.5)
            {
                comboText.transform.localScale = new Vector3(comboText.transform.localScale.x, comboText.transform.localScale.y - 0.15f, comboText.transform.localScale.z);
            }
        }

    }

    private void LateUpdate()
    {
        changeColor = false;
    }
}

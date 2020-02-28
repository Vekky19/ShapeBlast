using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SloMotion : MonoBehaviour
{
    public float value;
    public Slider slomoBar;

    public float timescaleValue;

    bool isActive;

    void Start()
    {
        value = 1;
        isActive = false;
        timescaleValue = 1;
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            if (value != 0)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }

        if (isActive == true)
        {
            Time.timeScale = 0.5f;
            value -= 1 * Time.deltaTime;
            if (value <= 0)
            {
                value = 0;
                isActive = false;
            }
        }
        else
        {
            Time.timeScale = timescaleValue;
            if (value < 1)
            {
                value += 0.1f * Time.deltaTime;
            }
        }

        slomoBar.value = value;
    }
}

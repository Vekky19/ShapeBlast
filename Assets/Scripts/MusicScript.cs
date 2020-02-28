using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public AudioSource music;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeVolume()
    {
        music.volume = slider.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler
{
    AudioSource sound;
    
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }

}

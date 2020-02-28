using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnClick : MonoBehaviour
{
    public static ParticleOnClick Instance;
    public ParticleSystem particles;

    void Start()
    {
        Instance = this;
    }

    public void PlayEffect(Transform target, Color color)
    {
        particles.transform.position = target.position;
        particles.startColor = color;
        particles.Play();
    }

}

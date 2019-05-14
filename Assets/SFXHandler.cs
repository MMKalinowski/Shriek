using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public AudioClip[] music;
    AudioSource src;

    public enum Clip
    {
        Laser,
        Jump,
        Shriek,
        Death,
    }

    private void Awake()
    {
        src = gameObject.GetComponent<AudioSource>();
        src.loop = false;
    }

    public void Play(Clip track)
    {
        if (src)
        {
            src.clip = music[(int)track];
            src.Play();
        }
    }
}

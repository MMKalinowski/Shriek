using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    public AudioClip[] music;
    private int current = 0;

    AudioSource src;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("boss"))
        {
            current = 1;
        }
        else
        {
            current = 0;
        }

        src = gameObject.GetComponent<AudioSource>();
        if (src)
        {
            if(src.isPlaying)
                src.Stop();

            src.clip = music[current];
            src.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("boss"))
        {
            current = 1;
        }
        else
        {
            current = 0;
        }

        if (src)
        {
            if(!src.clip.Equals(music[current]))
                src.clip = music[current];

            if (!src.isPlaying)
            {
                src.Play();
            }

            if(current > 0)
            {
                src.reverbZoneMix = 1.1f;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sounds;
    
    //Singleton Audio Manager
    public static AudioManager inst = null;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        /*
        else if (inst != this)
        {
            Destroy(gameObject);
        }*/
    }

    public void AudioPlay(AudioClip audioClip)
    {
        sounds.clip = audioClip;
        sounds.Play();
    }
}

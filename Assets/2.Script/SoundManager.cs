using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip1;
    public AudioClip soundClip2;
    public AudioClip soundClip3;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.Play();
    }

    public void Stage1()
    {
        audioSource.clip = soundClip1;
    }
    public void Stage2()
    {
        audioSource.clip = soundClip2;
    }
    public void Stage3()
    {
        audioSource.clip = soundClip3;
    }


}

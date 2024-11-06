using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioMixer masterMixer;
    public Slider audioSlider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

}

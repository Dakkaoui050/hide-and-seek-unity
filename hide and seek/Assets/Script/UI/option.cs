using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        DontDestroyOnLoad(audioSource);
        // Set the initial value of the volume slider to match the current volume of the audio source
        volumeSlider.value = audioSource.volume;
    }

    public void SetVolume()
    {
        // Set the volume of the audio source to the value of the volume slider
        audioSource.volume = volumeSlider.value;
    }
}

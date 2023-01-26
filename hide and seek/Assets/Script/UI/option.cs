using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class option : MonoBehaviour
{
    //music setting
    public AudioSource audioSource;
    public Slider volumeSlider;

    //
    public Toggle fullscreenTog, vsyncTog;

    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;
    private int selectedResolution;

    private void Awake()
    {
         DontDestroyOnLoad(audioSource);
         DontDestroyOnLoad(resDropdown);
       
    }

    void Start()
    {
       
        // Set the initial value of the volume slider 
        volumeSlider.value = audioSource.volume;

        // size de screen
        fullscreenTog.isOn = Screen.fullScreen;

        List<string> options = new List<string>();

        resDropdown.ClearOptions();

        //vSync setting
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }


        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetVolume()
    {
        // Set the volume of the audio source to the value of the volume slider
        audioSource.volume = volumeSlider.value;
    }

    public void SetResolution(int resolutionIndex)
    {
        
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
   

   
    public void setFullscreen(bool FullS)
    {
        Screen.fullScreen = FullS;
    }

    public void ApplyGraphics()
    {
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        
    }


}

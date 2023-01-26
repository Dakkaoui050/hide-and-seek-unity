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

    //Screen Setting 
    public Toggle fullscreenTog, vsyncTog;

    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;
    private int selectedResolution;
    public  int currentResIndex = 0;

    //Mouse sensitivity 
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public Slider sensitivityXSlider;
    public Slider sensitivityYSlider;

    public TMP_Text sensitivityXValue;
    public TMP_Text sensitivityYValue;

   

    void Start()
    {
         //mouse sensitivity for the X and Y
        sensitivityXSlider.value = sensitivityX;
        sensitivityYSlider.value = sensitivityY;
        sensitivityXSlider.onValueChanged.AddListener(ChangeSensitivityX);
        sensitivityYSlider.onValueChanged.AddListener(ChangeSensitivityY);

        // Set the initial value of the volume slider 
        volumeSlider.value = audioSource.volume;

        //screen Setting
        fullscreenTog.isOn = Screen.fullScreen;

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
           
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            { 
                resDropdown.ClearOptions();
                currentResIndex = i;
            } 
           
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue(); 
      

        //vSync setting
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivityX;
        float y = Input.GetAxis("Mouse Y") * sensitivityY;

        transform.Rotate(-y, x, 0);
    }
    void ChangeSensitivityX(float newSensitivityX)
    {
        sensitivityX = newSensitivityX;
        sensitivityXValue.text = newSensitivityX.ToString();
    }

    void ChangeSensitivityY(float newSensitivityY)
    {
        sensitivityY = newSensitivityY;
        sensitivityYValue.text = newSensitivityY.ToString();
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
        //Vsync on and off funtion
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

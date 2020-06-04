using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    //Reference to the audio mixer
    public AudioMixer audioMixer;

    //Reference to the resolutionDropdown
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private void Start()
    {
        //Infos about what resolutions we have
        //List of all the resolutions
        resolutions = Screen.resolutions;

        //clear all options
        resolutionDropdown.ClearOptions();

        //Array of resolutions in List of Strings
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //Default options we have on the dropdown
        //Add list to ResolutionOptions
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        //get height and width with the resolutionIndex
        Resolution resolution = resolutions[resolutionIndex];


        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Master Volume
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Unity set automaticly the QualityIndex to the chosen element
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Toggle for fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

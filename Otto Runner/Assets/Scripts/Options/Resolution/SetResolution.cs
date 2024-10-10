using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    Resolution[] resolutions;

    [SerializeField] TMP_Dropdown resolutionDropDown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> listResolutions = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; 
            listResolutions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(listResolutions);

        // Cargar la resolución guardada
        int savedResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);
        resolutionDropDown.value = savedResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        // Aplicar la resolución guardada
        SetResolutionGame(savedResolutionIndex);
    }

    public void SetResolutionGame (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        // Guardar la resolución seleccionada en PlayerPrefs
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class VolumePreLoad : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        // Cargar el volumen guardado
        float savedVolume = PlayerPrefs.GetFloat("gameVolume", 1f); // Valor por defecto de 0.75 (75% del volumen)
        SetVolume(savedVolume);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("gameVolume", volume); // Guardar el valor del volumen en PlayerPrefs
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SetFullScreen : MonoBehaviour
{
    [SerializeField] Toggle screenToggle;

    private void Start()
    {
        // Cargar el valor guardado de pantalla completa
        bool isFullScreen = PlayerPrefs.GetInt("isFullScreen", 1) == 1;

        screenToggle.isOn = isFullScreen;

        // Aplicar el estado de pantalla completa guardado
        Screen.fullScreen = isFullScreen;
    }

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        // Guardar el valor de pantalla completa en PlayerPrefs
        PlayerPrefs.SetInt("isFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using TMPro;

public class RestartTextManager : MonoBehaviour
{
    public TMP_Text restartText; 

    void Start()
    {
        if (restartText != null)
        {
            restartText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("El campo 'restartText' no está asignado en el Inspector.");
        }
    }

    public void ShowRestartText()
    {
        if (restartText != null)
        {
            restartText.gameObject.SetActive(true);
        }
    }

    public void HideRestartText()
    {
        if (restartText != null)
        {
            restartText.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Asegúrate de incluir esta línea para usar los botones

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    private bool inPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        inPause = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);

        // Reproducir sonido de clic al abrir el menú de pausa
        MenuMusicManager.instance.PlaySFX(MenuMusicManager.instance.clickSound);
    }

    public void Resume()
    {
        inPause = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);

        // Reproducir sonido de clic al reanudar el juego
        MenuMusicManager.instance.PlaySFX(MenuMusicManager.instance.clickSound);
    }

    public void Restart()
    {
        inPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reproducir sonido de clic al reiniciar
        MenuMusicManager.instance.PlaySFX(MenuMusicManager.instance.clickSound);
    }

    public void Exit()
    {
        Debug.Log("salir");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        // Reproducir sonido de clic al salir
        MenuMusicManager.instance.PlaySFX(MenuMusicManager.instance.clickSound);
    }
}

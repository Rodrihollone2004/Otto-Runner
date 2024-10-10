using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip clickSound;

    public static MenuMusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Iniciar la música del menú si estamos en una escena de menú
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Options")
        {
            PlayMusic(menuMusic);
        }
        else if (SceneManager.GetActiveScene().name == "Game")
        {
            PlayMusic(gameMusic);
        }

        // Asignar SFX a los botones actuales en la escena
        AssignButtonListeners();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cambiar la música según la escena
        if (scene.name == "Menu" || scene.name == "Options")
        {
            PlayMusic(menuMusic);
        }
        else if (scene.name == "Game")
        {
            PlayMusic(gameMusic);
        }

        // Asignar SFX a los botones nuevamente cuando cargue una nueva escena
        AssignButtonListeners();
    }

    private void PlayMusic(AudioClip clip)
    {
        if (music != null && clip != null)
        {
            if (music.clip != clip)
            {
                music.clip = clip;
                music.loop = true;
                music.Play();
            }
        }
        else
        {
            Debug.LogError("Music or AudioClip is not assigned in the inspector!");
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFX != null && clip != null)
        {
            SFX.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("SFX or clip is not assigned!");
        }
    }

    // Asignar los listeners a todos los botones en la escena
    private void AssignButtonListeners()
    {
        // Busca todos los botones en la escena actual
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            // Limpiar listeners anteriores
            button.onClick.RemoveAllListeners();

            // Agregar el efecto de sonido a todos los botones
            button.onClick.AddListener(() => PlaySFX(clickSound));
        }
    }

    // Método para activar el menú de pausa
    public void TogglePauseMenu(bool isActive)
    {
        // Aquí puedes activar/desactivar tu menú de pausa
        // También asegúrate de volver a asignar los listeners de los botones del menú de pausa
        AssignButtonListeners();
    }
}

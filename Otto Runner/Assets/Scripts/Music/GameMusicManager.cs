using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameMusic;

    void Start()
    {
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}

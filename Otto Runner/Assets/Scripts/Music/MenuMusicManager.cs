using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuMusic;

    void Start()
    {
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}

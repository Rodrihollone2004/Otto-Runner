using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;
    public AudioClip gameMusic;
    public AudioClip jump;
    public AudioClip collision;
    public AudioClip crawling;

    void Start()
    {
        music.clip = gameMusic;
        music.loop = true;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}

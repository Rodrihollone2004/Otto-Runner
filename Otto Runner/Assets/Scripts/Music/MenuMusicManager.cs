using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;
    public AudioClip menuMusic;
    public AudioClip clickSound;

    void Start()
    {
        music.clip = menuMusic;
        music.loop = true;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}

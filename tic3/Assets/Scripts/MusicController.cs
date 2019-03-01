using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource music;

    private bool isPlaying = true;

    private void Start()
    {
        music.loop = true;
        music.volume = 0.1f;
        music.Play();
    }

    private void Update()
    {
        if (Input.GetKeyUp("m"))
        {
            ToggleMusic();
        }
    }

    private void ToggleMusic()
    {
        if (isPlaying)
        {
            music.mute = true;
        }
        else
        {
            music.mute = false;
        }
        isPlaying = !isPlaying;
    }
}

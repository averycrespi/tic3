using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public AudioSource music;
    public Button muteButton;
    public Text muteText;

    private bool isPlaying = true;

    private void Start()
    {
        music.loop = true;
        music.volume = 0.5f;
        music.Play();
        muteButton.onClick.AddListener(ToggleMusic);
    }

    private void ToggleMusic()
    {
        if (isPlaying)
        {
            music.mute = true;
            muteText.text = "Unmute";
        }
        else
        {
            music.mute = false;
            muteText.text = "Mute";
        }
        isPlaying = !isPlaying;
    }
}

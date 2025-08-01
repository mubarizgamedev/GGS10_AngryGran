using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    public void ResumeMusic()
    {
        musicAudioSource.Play();
    }
}

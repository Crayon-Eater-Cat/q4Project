using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log(level) * 20);
    }
    public void SetGameMusicVolume(float level)
    {
        audioMixer.SetFloat("musicGameVolume", Mathf.Log(level) * 20);

    }
    public void SetMenuMusicVolume(float level)
    {
        audioMixer.SetFloat("musicMenuVolume", Mathf.Log(level) * 20);

    }

}
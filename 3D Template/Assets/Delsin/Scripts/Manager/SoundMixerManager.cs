using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public float masterVolumeSlider {  get; set; }
    public float inMusicVolumeSlider { get; set; }
    public float mMusicVolumeSlider { get; set; }
    public float masterLvl;
    public float inMusicLvl;
    public float mMusicLvl;
    //public List<AudioMixer> AudioMixerList;
    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log(masterLvl) * 20);
        masterVolumeSlider = PlayerPrefs.GetFloat("masterVolume", masterLvl);
    }
    public void SetGameMusicVolume(float level)
    {
        audioMixer.SetFloat("musicGameVolume", Mathf.Log(inMusicLvl) * 20);
        inMusicVolumeSlider = PlayerPrefs.GetFloat("musicGameVolume", inMusicLvl);
    }
    public void SetMenuMusicVolume(float level)
    {
        audioMixer.SetFloat("musicMenuVolume", Mathf.Log(mMusicLvl) * 20);
        mMusicVolumeSlider = PlayerPrefs.GetFloat("musicMenuVolume", mMusicLvl);
    }
    public void SetMasterVolumeSlider(float level)
    {
        PlayerPrefs.SetFloat(masterLvl, level);
    }
}
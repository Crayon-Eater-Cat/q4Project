using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public float masterLvl;
    public float inMusicLvl;
    public float mMusicLvl;

    public Slider masterVolSlide;
    public Slider inMusicVolSlide;
    public Slider mMusicVolSlide;

    //public List<AudioMixer> AudioMixerList;
    public void SetMasterVolume(float level)
    {
        masterLvl = level;
        audioMixer.SetFloat("masterVolume", Mathf.Log(masterLvl) * 20);
        PlayerPrefs.SetFloat("masterVolume", level);
    }
    public void SetGameMusicVolume(float level)
    {
        inMusicLvl = level;
        audioMixer.SetFloat("musicGameVolume", Mathf.Log(inMusicLvl) * 20);
        PlayerPrefs.SetFloat("musicGameVolume", level);
    }
    public void SetMenuMusicVolume(float level)
    {
        mMusicLvl = level;
        audioMixer.SetFloat("musicMenuVolume", Mathf.Log(mMusicLvl) * 20);
        PlayerPrefs.SetFloat("musicMenuVolume", level);
    }
    public void Start()
    {
        masterVolSlide.value = PlayerPrefs.GetFloat("masterVolume", masterLvl);
        inMusicVolSlide.value = PlayerPrefs.GetFloat("musicGameVolume", inMusicLvl);
        mMusicVolSlide.value = PlayerPrefs.GetFloat("musicMenuVolume", mMusicLvl);
    }
}
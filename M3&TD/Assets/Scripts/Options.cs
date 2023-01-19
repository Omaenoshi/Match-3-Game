using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer musicMixer;
    public float musicVolume;
    public float soundVolume;
    public bool musicMute = false;
    public bool soundMute = false;

    public void MusicVolume(float sliderMusic)
    {
        musicMixer.SetFloat("masterMusic", sliderMusic);
        musicVolume = sliderMusic;
    }
    public void MusicMute()
    {
        if (musicMute) 
        {
            musicMixer.SetFloat("masterMusic", musicVolume);
            musicMute = false;
        }
        else 
        {
            musicMixer.SetFloat("masterMusic", 0);
            musicMute = true;
        }
    }
    public void SoundVolume(float sliderMusic)
    {
        musicMixer.SetFloat("masterSound", sliderMusic);
        soundVolume = sliderMusic;
    }
    public void SoundMute()
    {
        if (soundMute) 
        {
            musicMixer.SetFloat("masterSound", soundVolume);
            musicMute = false;
        }
        else 
        {
            musicMixer.SetFloat("masterSound", 0);
            musicMute = true;
        }
    }
}
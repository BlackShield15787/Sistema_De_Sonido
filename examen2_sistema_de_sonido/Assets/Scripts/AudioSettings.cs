using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings audioSettings;

    [Header("Information - Read Only from inspector")]
    [SerializeField]
    private float musicVolume;
    [SerializeField]
    private float sfxVolume;

    float musicDefaultVolume=0.7f;
    float sfxDefaultVolume = 0.9f;

  

    string musicVolumeDataName = "music-volume";
    string sfxVolumeDataName = "sfx-volume";

    List<AudioSource> musicAudioSources;
    List<AudioSource> sfxAudioSources;
 
    private int musicAudioSourcesCount=0;
    private int sfxAudioSourcesCount = 0;

    private GameObject soundSettings;
    private bool soundActive = false;
    // todas las sentencias que vamos utilizar en el script para manegar los sliders y el volumen del juego
    private void Awake()
    {
        audioSettings = this;
        musicAudioSources = new List<AudioSource>();
        sfxAudioSources = new List<AudioSource>();
        LoadSavedSettings();
        soundSettings = GameObject.FindGameObjectWithTag("menu");

        soundSettings.SetActive(soundActive);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            soundActive = !soundActive;
            soundSettings.SetActive(soundActive); 
        }
    }

    void LoadSavedSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(musicVolumeDataName,musicDefaultVolume);
        sfxVolume = PlayerPrefs.GetFloat(sfxVolumeDataName, sfxDefaultVolume);

    }
    //va guardar los cambios que se realicen al volumen
    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat(musicVolumeDataName, musicVolume);
        SetVolumeToAudioSources(musicAudioSources, musicVolume);
    }


    public void ChangSFXVolume(float newVolume)
    {
        sfxVolume = newVolume;
        PlayerPrefs.SetFloat(sfxVolumeDataName, sfxVolume);
        SetVolumeToAudioSources(sfxAudioSources, sfxVolume);
    }
    //modifica el volumen de los Tracks utilizados
    void SetVolumeToAudioSources(List<AudioSource> audioSources, float volume)
    {
        foreach (AudioSource a in audioSources)
        {
            a.volume = volume;
        }
    } //establece un volumen predeterminado para todo

    
    public float GetMusicVolume()
    {
        return musicVolume;
    }
    public float GetSFXVolume()
    {
        return sfxVolume;
    }
    //les pone el volumen a los tracks
    public void AddMeToMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Add(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }

    public void RemoveMeFromMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Remove(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }
    public void AddMeToSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Add(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }

    public void RemoveMeFromSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Remove(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }
    //añade y quita los audios necesarios dependiendo de cual se nesecite


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtilities 
{
    public static AudioSource audioSource;
    public static Dictionary<string, AudioClip> tracks = new Dictionary<string, AudioClip>();
public static void SetAudioSource(AudioSource source)
    {
        audioSource = source;
    }

    public static void AddTrack(string trackTitle,AudioClip trackClip)
    {
        tracks.Add(trackTitle, trackClip); //sirve parab añadir mas Tracks al project
    }
    public static void PlayTrack(string trackTitle)
    {
        if (tracks.ContainsKey(trackTitle))
        {
            audioSource.clip = tracks[trackTitle];
            audioSource.Play();
        }
        else
        {
            Debug.Log($"Traack:{trackTitle} does not");
        }
    }// inicia el track dependiendo de cual hayas elegido en el project
}

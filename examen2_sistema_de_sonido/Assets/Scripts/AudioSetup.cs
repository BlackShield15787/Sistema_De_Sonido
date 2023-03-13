using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetup : MonoBehaviour
{
    [SerializeField] private AudioTracks[] tracks;
    [SerializeField] private AudioSource mainSource;
    public string trackname;

    void Start()
    {
        AudioUtilities.SetAudioSource(mainSource);

        foreach(var item in tracks)
        {
            AudioUtilities.AddTrack(item.trackTitle, item.trackClip);

        }
        AudioUtilities.PlayTrack(trackname); // este codigo cambia el Track desde la pestaña de project 
    }
}

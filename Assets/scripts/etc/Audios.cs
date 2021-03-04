using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Audios : MonoBehaviour
{
    public AudioClip entryAudio;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = entryAudio;
        audio.Play();
        //entryAudio.PlayOneShot(AudioClip audioClip, Float volumeScale);
            //vorallem soundeffekte(kurzer clip + volume)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

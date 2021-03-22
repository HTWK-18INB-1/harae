using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    public AudioSource[] sounds;
    private AudioSource entryaudio;
    private AudioSource sound2;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        entryaudio=sounds[0];
        sound2 = sounds[1];
        entryaudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            entryaudio.Stop();
            sound2.Play();
        }
    }
}

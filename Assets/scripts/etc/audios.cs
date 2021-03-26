using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    public AudioSource[] sounds;
    private AudioSource sound1;
    private AudioSource sound2;

    private bool firstStart = true;

    GameObject light;
    LightGuide lightScript;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        sound1 = sounds[0];
        sound2 = sounds[1];

        light = GameObject.Find("helpLight");
        lightScript = light.GetComponent<LightGuide>();
    }

    // Update is called once per frame
    void Update()
    {
       if(lightScript.isFinished && firstStart){
            sound1.Play();
            sound2.Stop();
            firstStart = false;
        }
    }
}

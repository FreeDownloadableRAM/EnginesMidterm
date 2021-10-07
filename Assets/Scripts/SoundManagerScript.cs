using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Collided;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        /*
        audioSrc = GetComponent<AudioSource>();
        
        musicSound = Audio.Load<AudioClip>("The Champion of Hope");

        audioSrc.PlayOneShot(musicSound);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy and player collided



    }

    //PlaySound
    public static void PlaySound(string clip)
    {
        //DO NOTHING 
    }
}

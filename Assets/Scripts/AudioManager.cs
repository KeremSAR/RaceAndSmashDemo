using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource Audio_True;
    private AudioSource Audio_Wrong;
    private AudioSource diving;
    private AudioSource ipbırakma;
    private AudioSource explosion;

    public AudioClip  True;
    public AudioClip wrong;
    public AudioClip divingClip;
    public AudioClip iPBırakmaClip;
    public AudioClip explodeClip;




    public void Start()
    {
        Audio_True = GetComponent<AudioSource>();
        Audio_Wrong = GetComponent<AudioSource>();
        diving = GetComponent<AudioSource>();
        ipbırakma = GetComponent<AudioSource>();
        explosion = GetComponent<AudioSource>();
    }

    public void TrueSound()
    {
        if (AudioListener.pause == false)
        {
            Audio_True.PlayOneShot(True);
        }


    }

    public void WrongSound()
    {
        if (AudioListener.pause == false)
        {
            Audio_Wrong.PlayOneShot(wrong);
        }

    }

    public void DivingSound()
    {
        if (AudioListener.pause == false)
        {
            diving.PlayOneShot(divingClip); 
        } 
    }

    public void İpBırakma()
    { 
        if (AudioListener.pause == false)
        {
            ipbırakma.PlayOneShot(iPBırakmaClip);
        }


    }

    public void Explode()
    {
        if (AudioListener.pause == false)
        {
            explosion.PlayOneShot(explodeClip);
        }

    }




}
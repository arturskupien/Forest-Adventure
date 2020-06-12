using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFollow : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetButtonDown("Mute") && !audioSource.mute)
        {
            audioSource.mute = true;
        }
        else if (Input.GetButtonDown("Mute") && audioSource.mute)
        {
            audioSource.mute = false;
        }
    }


}

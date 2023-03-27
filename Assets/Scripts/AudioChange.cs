using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChange : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] int musicID = 0;

    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*myAudioSource.clip = audioClips[musicID];
        myAudioSource.Play();*/
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioChange : MonoBehaviour
{
    [SerializeField] AudioClip [] audioClips;

    private AudioSource myAudioSource;
    private int musicID = 0;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        // load & set pref value for volume
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        myAudioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        // change de music avec les scenes
        SetNewClip(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetNewClip(int clipID)
    {
        if ((0 < clipID) && (clipID < audioClips.Length))
        {
            if (clipID != musicID)
            {
                musicID = clipID;
                myAudioSource.clip = audioClips[clipID];
                myAudioSource.Play();
            }
        }
    }
}
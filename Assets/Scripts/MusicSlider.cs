using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    // https://www.youtube.com/watch?v=V_Bf__ynKLE
    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixMode audioMixMode;

    private AudioSource audioSource;

    public void OnChangeSlider(float f_value)
    {
        // Debug.Log($"{f_value.ToString("N4")}");

        switch (audioMixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                audioSource.volume = f_value;
                break;
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat("Volume", f_value * 100 - 80); // -80 < Volume < 20
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                mixer.SetFloat("Volume", Mathf.Log10(f_value) * 20); // formule calcul dB
                break;
        }

        // persistence du volume dans le registre...
        PlayerPrefs.SetFloat("Volume", f_value);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        // load & set default value
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        mixer.SetFloat("Volume", Mathf.Log10(volume * 20)); // same name in mixer object

        // Mettre le slider à jour
        GetComponent<Slider>().value = volume; // Value dans unity
    }

    private void Awake()
    {
        // On va chercher le BackgroundAudio, dans Start pb de réf
        audioSource = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
    }
}

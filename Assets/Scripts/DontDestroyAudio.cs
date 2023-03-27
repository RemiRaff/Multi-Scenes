using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        // audio object kept between scenes
        DontDestroyOnLoad(transform.gameObject);
    }
}

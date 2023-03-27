using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // audio object kept between scenes
        DontDestroyOnLoad(transform.gameObject);
    }
}

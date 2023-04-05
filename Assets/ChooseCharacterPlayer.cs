using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterPlayer : MonoBehaviour
{
    [SerializeField] GameObject androidPlayer;
    [SerializeField] GameObject mouseKeysPlayer;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        Instantiate(androidPlayer);
#else
        Instantiate(mouseKeysPlayer);
#endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor; // EditorApplication non reconnu si absent
#endif

public class StartingUIHandler : MonoBehaviour
{
    [SerializeField] GameObject _startMenu; // menu present dans la start scene
    [SerializeField] GameObject _scenesMenu; // prefab

    private GameObject monMenu;

    private void Start()
    {
        // instantiation du prefab
        monMenu = Instantiate(_scenesMenu);
        monMenu.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // quit unity editor player
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    // Update is called once per frame
    public void New()
    {
        _startMenu.SetActive(false);
        monMenu.SetActive(true);
    }
}

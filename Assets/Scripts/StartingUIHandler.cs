using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor; // EditorApplication non reconnu si absent
#endif

public class StartingUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
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
        SceneManager.LoadScene(1);
    }
}

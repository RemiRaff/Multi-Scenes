using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transtionTime = 1f;

    public void LoadNextScene(int sceneID)
    {
        StartCoroutine(LoadLLevel(sceneID));
    }

    IEnumerator LoadLLevel(int sceneID)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transtionTime);

        SceneManager.LoadScene(sceneID);
    }
}

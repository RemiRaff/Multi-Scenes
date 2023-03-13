using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneUIHandler : MonoBehaviour
{
    public void FFButton()
    {
        SceneManager.LoadScene(1);
    }

    public void A1Button()
    {
        SceneManager.LoadScene(2);
    }

    public void A2Button()
    {
        SceneManager.LoadScene(3);
    }
}

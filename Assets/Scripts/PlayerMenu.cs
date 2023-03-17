using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] GameObject menuScene;

    private bool isDisplayed;
    private GameObject monMenu;

    private void Start()
    {
        isDisplayed = false;
        monMenu = Instantiate(menuScene);
        monMenu.SetActive(false);
    }

    public void NavMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (isDisplayed)
            {
                Cursor.lockState = CursorLockMode.Locked;
                isDisplayed = false; // détruire le menu
                monMenu.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                isDisplayed = true; // affiche le menu
                monMenu.SetActive(true);
                monMenu.GetComponent<SceneUIHandler>().SetPlayerTrans(transform.position, transform.rotation);
            }
        }
    }
}

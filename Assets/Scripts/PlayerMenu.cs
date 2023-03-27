using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] GameObject menuScene; // prefab
    [SerializeField] PlayerLook _playerLook;

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
                isDisplayed = false; // cacher le menu
                monMenu.SetActive(false);
                _playerLook.enabled = true;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                _playerLook.enabled = false;
                isDisplayed = true; // affiche le menu
                monMenu.SetActive(true);
                Cursor.visible = true;
                monMenu.GetComponent<SceneUIHandler>().SetPlayerTrans(transform.position, transform.rotation);
            }
        }
    }
}

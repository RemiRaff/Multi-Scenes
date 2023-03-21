using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor; // EditorApplication non reconnu si absent
#endif

public class StartingUIHandler : MonoBehaviour
{
    [SerializeField] GameObject _startMenu; // menu present dans la start scene
    [SerializeField] GameObject _scenesMenu; // prefab

    [SerializeField] PlayerData _pData;

    SceneLoader _sceneLoader; // prefab

    private GameObject monMenu;

    private void Start()
    {
        // instantiation du prefab
        monMenu = Instantiate(_scenesMenu);
        monMenu.SetActive(false);

        // on récupère le SceneManager
        _sceneLoader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
    }

    public static void Exit()
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

    public void Load()
    {
        // le player existe, on charge ses infos
        if (File.Exists(Application.persistentDataPath + "/SManData.json"))
        {
            string jsonStr = File.ReadAllText(Application.persistentDataPath + "/SManData.json");
            Data p = JsonUtility.FromJson<Data>(jsonStr);

            _pData._sceneID = p._sceneID;
            _pData._playerPos = new Vector3(p._transPosX, p._transPosY, p._transPosZ);
            _pData._playerRot = new Quaternion(p._transRotX, p._transRotY, p._transRotZ, p._transRotW);
            _pData._toUpdate = true;

            // charger la bonne scene
            _sceneLoader.LoadNextScene(p._sceneID);

            // initialiser le player
        }
        else // sinon on charge une scène par défaut
            _sceneLoader.LoadNextScene(1);
    }
}

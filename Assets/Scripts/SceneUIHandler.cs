using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUIHandler : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    private Vector3 transfPos;
    private Quaternion transfRot;

    private void Start()
    {
        // on récupère le SceneManager
        _sceneLoader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
    }

    public void FFButton()
    {
        _sceneLoader.LoadNextScene(1);
    }

    public void A1Button()
    {
        _sceneLoader.LoadNextScene(2);
    }

    public void A2Button()
    {
        _sceneLoader.LoadNextScene(3);
    }

    public void SetPlayerTrans(Vector3 plPos, Quaternion plRot)
    {
        transfPos = plPos;
        transfRot = plRot;
    }

    public void Exit()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;

        if (sceneID == 0)
            // exit start menu
            StartingUIHandler.Exit();
        else
        {
            // Sauvegarder la position du joueur
            Data p = new Data();
            p._sceneID = sceneID;
            p._transPosX = transfPos.x;
            p._transPosY = transfPos.y;
            p._transPosZ = transfPos.z;
            p._transRotX = transfRot.x;
            p._transRotY = transfRot.y;
            p._transRotZ = transfRot.z;
            p._transRotW = transfRot.w;

            // Ecrire le json
            string jsonFile = JsonUtility.ToJson(p);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/SManData.json", jsonFile);

            // Exit
            StartingUIHandler.Exit();
        }
    }
}

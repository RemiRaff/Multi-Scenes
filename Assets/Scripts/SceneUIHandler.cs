using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneUIHandler : MonoBehaviour
{
    private float transfPosX;
    private float transfPosY;
    private float transfPosZ;

    private float transfRotX;
    private float transfRotY;
    private float transfRotZ;

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

    public void SetPlayerTrans(float px, float rx, float py, float ry, float pz, float rz)
    {
        transfPosX = px;
        transfPosY = py;
        transfPosZ = pz;

        transfRotX = rx;
        transfRotY = ry;
        transfRotZ = rz;
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
            p._transPosX = transfPosX;
            p._transPosY = transfPosY;
            p._transPosZ = transfPosZ;
            p._transRotX = transfRotX;
            p._transRotY = transfRotY;
            p._transRotZ = transfRotZ;

            // Ecrire le json
            string jsonFile = JsonUtility.ToJson(p);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/SManData.json", jsonFile);

            // Exit
            StartingUIHandler.Exit();
        }
    }
}

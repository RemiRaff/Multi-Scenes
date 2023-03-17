using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object/Player Data")]

public class PlayerData : ScriptableObject
{
    // https://www.youtube.com/watch?v=pZ-iG4XUE7E
    public int _sceneID;
    public Vector3 _playerPos;
    public Quaternion _playerRot;
    public bool _toUpdate;
}

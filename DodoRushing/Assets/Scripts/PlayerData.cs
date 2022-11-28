using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "CREATE PLAYER DATA")]
public class PlayerData : ScriptableObject
{
    public int gravityForce;
    public int speedMovement;
    public int jumpForce;
    public float height;
}

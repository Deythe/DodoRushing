using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "CREATE PLAYER DATA")]
public class PlayerData : ScriptableObject
{
    public float gravity;
    public int speedMovement;
    public float dashForce;
    public int jumpForce;
    public float height;
    public float cooldownDash;
    public float durationDash;
}

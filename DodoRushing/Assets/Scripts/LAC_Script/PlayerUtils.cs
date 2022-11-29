using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerUtils 
{
    public delegate void DeathDelegate();
    public static DeathDelegate deathEvent;
    public static void CallDeath()
    {
        Debug.Log("Player death");
        deathEvent?.Invoke();
    }
}

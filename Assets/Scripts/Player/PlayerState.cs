using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    /*
    Currently keeps track of whether or not player is dead.
     */
    public static bool Dead;
    public static bool Paused;
    private PlayerLook _look;

    void Awake(){
        Dead = false;
        Paused = false;
        _look = GetComponentInChildren<PlayerLook>();
    }
    void Update(){
        _look.enabled = (!Paused);
    }
    public void KillPlayer(){
        Dead = true;
    }
    public bool isDead(){
        return Dead;
    }
}

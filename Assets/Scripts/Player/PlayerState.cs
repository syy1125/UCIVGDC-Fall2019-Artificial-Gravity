using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    /*
    Currently keeps track of whether or not player is dead.
     */
    private bool Dead = false;

    void Update(){
    }
    public void KillPlayer(){
        Dead = true;
    }
    public bool isDead(){
        return Dead;
    }
}

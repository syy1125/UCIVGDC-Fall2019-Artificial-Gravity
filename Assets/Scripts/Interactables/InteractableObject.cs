using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    /*
        Generic interactable thing that doesn't have any special animation requirements.
     */
   
    public override void OnInteract(){
        DefaultInteract();
    }
    
}

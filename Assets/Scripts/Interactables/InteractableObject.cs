using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    /*
        Generic interactable thing that doesn't have any special animation requirements.
     */
    private Animator MyAnimator;
    public string InteractAnimation;
    void Awake()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
    }    
    public override void OnInteract(){
        if(MyAnimator != null && InteractAnimation != ""){
            if(RepeatTimer > 0)
                return;
            DefaultInteract();
            if(Disabled)
                return;
            MyAnimator.Play(InteractAnimation);
        } else {
            DefaultInteract();
        }
        
    }
    
}

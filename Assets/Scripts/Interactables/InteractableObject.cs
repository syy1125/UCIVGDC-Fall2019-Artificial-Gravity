using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    
    private Animator MyAnimator;
    private string InteractAnimation = "On Interact"; //Should correspond with a state on the Animator
    void Awake()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
    }    
    public override void OnInteract(){
        if(MyAnimator != null){
            if(RepeatTimer > 0)
                return;
            DefaultInteract();
            if(Locked)
                return;
            MyAnimator.Play(InteractAnimation);
        } else {
            DefaultInteract();
        }
        
    }
    
}

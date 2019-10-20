using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    //This is a standard interactable but it deals with button animation
    private Animator MyAnimator;
    void Awake()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
    }

    

    public override void OnInteract(){
        if(Disabled)
            return;
        if(RepeatTimer > 0)
            return;
        MyAnimator.Play("Button Press");
        DefaultInteract();
    }
}

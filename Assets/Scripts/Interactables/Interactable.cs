using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType{
    Repeatable,
    OnlyOnce,
    Toggle
}
public abstract class Interactable : PuzzleElement
{
    /*
        This class will be used for objects the player can interact 
        with ("Press E to pull lever/press button/lift rubble, etc)

        Interact Type:
        Repeatable--Send activateOthers() once per interaction
        OnlyOnce--Send activateOthers() only once
        Toggle--Swap between sending activateOthers() and deactivateOthers()
     */
    public bool Disabled = false;
    public InteractType Interaction = InteractType.Repeatable;
    public string Tooltip="";
    public float RepeatDelay = 0.3f;  //object can only be interacted with every 0.3 seconds
    protected float RepeatTimer = 0;
    protected bool FirstUsage = true;


    void Update(){
        if(RepeatTimer > 0){
            RepeatTimer -= Time.deltaTime;
        } 
    }
    public abstract void OnInteract(); //Children decides interaction
    public void DefaultInteract(){
        if(Disabled)
            return;
        if(RepeatTimer > 0)
            return;

        RepeatTimer = RepeatDelay;
        switch(Interaction){
            case InteractType.Repeatable:
                ActivateOthers();
                FirstUsage = false;
                break;
            case InteractType.OnlyOnce:
                if(FirstUsage){
                    ActivateOthers();
                    FirstUsage = false;
                }
                break;
            case InteractType.Toggle:
                ToggleOthers();
                FirstUsage = false;
                break;
        }
    }
}

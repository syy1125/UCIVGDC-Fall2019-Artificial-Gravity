﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType{
    Repeatable,
    OnlyOnce,
    Toggle
}
public class Interactable : PuzzleElement
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
    private bool FirstUsage = true;

    public void OnInteract(){
        if(Disabled)
            return;
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

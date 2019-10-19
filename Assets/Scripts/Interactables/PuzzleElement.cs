﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivationType
{
    Standard,
    OnlyActivate,
    OnlyDeactivate
}
public delegate void PuzzleElementEventHandler();
public class PuzzleElement : MonoBehaviour
{
    /*
    Parent Class for puzzle objects that have a state (door open/closed, button up/down).
    Puzzle Elements can be triggered by Puzzle Elements or send triggers to Puzzle Elements.
     */
    public event PuzzleElementEventHandler ActivateEvent;

    public event PuzzleElementEventHandler DeactivateEvent;
    public event PuzzleElementEventHandler ToggleEvent;
    public int State = 0; //if an object doesn't/shouldn't have a state, you can just ignore this
    public void OnActivate(){}
        //called when an object-you-listen-to calls activateOthers
    public void OnDeactivate(){}
        //called when an object-you-listen-to calls deactivateOthers

    public void OnToggle(){}
    public void ActivateOthers(){
        //calls onActivate in all gameObjects listening to this
        if(ActivateEvent != null){
            ActivateEvent();
        }
    }
    public void DeactivateOthers(){
        //calls onDeactivate in all gameObjects listening to this
        if(DeactivateEvent != null){
            DeactivateEvent();
        }
    }
    public void ToggleOthers(){
        if(ToggleEvent != null){
            ToggleEvent();
        }
    }
}

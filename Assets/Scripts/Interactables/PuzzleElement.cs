using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivationType
{
    STANDARD,
    ONLYACTIVATE,
    ONLYDEACTIVATE
}
public delegate void PuzzleElementEventHandler();
public class PuzzleElement : MonoBehaviour
{
    /*
    Parent Class for puzzle objects that have a state (door open/closed, button up/down).
    Puzzle Elements can be triggered by Puzzle Elements or send triggers to Puzzle Elements.
     */
    public event PuzzleElementEventHandler activateEvent;

    public event PuzzleElementEventHandler deactivateEvent;
    public event PuzzleElementEventHandler toggleEvent;
    public int state = 0; //if an object doesn't/shouldn't have a state, you can just ignore this
    public void onActivate(){}
        //called when an object-you-listen-to calls activateOthers
    public void onDeactivate(){}
        //called when an object-you-listen-to calls deactivateOthers

    public void onToggle(){}
    public void activateOthers(){
        //calls onActivate in all gameObjects listening to this
        if(activateEvent != null){
            activateEvent();
        }
    }
    public void deactivateOthers(){
        //calls onDeactivate in all gameObjects listening to this
        if(deactivateEvent != null){
            deactivateEvent();
        }
    }
    public void toggleOthers(){
        if(toggleEvent != null){
            toggleEvent();
        }
    }
}

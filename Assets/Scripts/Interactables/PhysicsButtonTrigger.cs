using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsButtonTrigger : MonoBehaviour
{
    /*
        Counts when objects enter/leave the button.  Activates
        when button is empty or not empty. Please don't Destroy() objects
        that are on a button or this will probably break.
     */
    public PhysicsButton ButtonObject;
    public string[] ActivationTags = {"Player","PuzzleBox"}; //Button should detect objects with this tag

    private int ObjectCount = 0;
   
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PuzzleBox") || other.CompareTag("Player")){
            ObjectCount += 1;
            if(ObjectCount > 0){
                ButtonObject.ActivateOthers();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PuzzleBox") || other.CompareTag("Player")){
            ObjectCount -= 1;
            if(ObjectCount <= 0){
                ButtonObject.DeactivateOthers();
            }
        }
    }
}

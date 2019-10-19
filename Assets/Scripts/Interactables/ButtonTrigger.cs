using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Button ButtonObject;
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

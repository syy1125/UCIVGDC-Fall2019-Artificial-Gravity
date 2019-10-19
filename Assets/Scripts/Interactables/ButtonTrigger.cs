using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public string[] activationTags = {"Player","PuzzleBox"}; //Button should detect objects with this tag

    private int objectCount = 0;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PuzzleBox") || other.CompareTag("Player")){
            objectCount += 1;
            if(objectCount > 0){
                button.activateOthers();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PuzzleBox") || other.CompareTag("Player")){
            objectCount -= 1;
            if(objectCount <= 0){
                button.deactivateOthers();
            }
        }
    }
}

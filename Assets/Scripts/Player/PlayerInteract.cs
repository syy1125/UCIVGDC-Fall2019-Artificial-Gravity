using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    /*
        This module raycasts from the player camera and calls OnInteract()
        on any object tagged as "Interactable"
     */
    private Transform HeadTransform;
    public float InteractDistance = 2.5f;
    public KeyCode InteractKey;

    public Text TooltipText;
    void Awake()
    {
        
        HeadTransform = GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        rayCast();
    }
    public void rayCast(){
        RaycastHit hit;

        if(Physics.Raycast(HeadTransform.position,HeadTransform.forward,out hit,InteractDistance)){
            if(hit.collider.gameObject.CompareTag("Interactable")){
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if(Input.GetKeyDown(InteractKey)){
                    interactable.OnInteract();
                    TooltipText.text = interactable.Tooltip;
                } else if(interactable.Disabled){
                    TooltipText.text = "I need " + interactable.UnlockedBy;
                }
            }
        } else {
            TooltipText.text = "";
        }
    }
    void OnDrawGizmos(){
        if(!HeadTransform)
            return;
        Gizmos.color = Color.green;
        Vector3 ASDF = HeadTransform.position;

        Gizmos.DrawWireSphere(HeadTransform.position+HeadTransform.forward*InteractDistance,.05f);
        Gizmos.DrawLine(HeadTransform.position,HeadTransform.position+HeadTransform.forward*InteractDistance);
    }
}

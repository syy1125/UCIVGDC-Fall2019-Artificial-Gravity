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
    public string InteractKey = "e";

    public static string HoverText=""; //This will be read by a Text UI object

    private Interactable _lastInteractable;
    
    void Awake()
    {
        HeadTransform = GetComponentInChildren<Camera>().transform;
        _lastInteractable = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Paused)
            return;
        rayCast();
    }
    public void rayCast(){
        RaycastHit hit;

        if(Physics.Raycast(HeadTransform.position,HeadTransform.forward,out hit,InteractDistance)){
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            
            // Transfer who's glowing if applicable
            if (interactable != _lastInteractable)
            {
                if (_lastInteractable != null)
                {
                    _lastInteractable.SetGlow(false);
                }
                _lastInteractable = interactable;
                if (interactable != null)
                {
                    interactable.SetGlow(true);
                }
            }
            
            if(interactable != null){
                if(Player.KeyDown(InteractKey)){
                    interactable.OnInteract();
                } 
                HoverText = interactable.HoverText();
            } else {
                HoverText = "";
            }
        } else {
            HoverText = "";
            
            // Turn off glow if applicable
            if (_lastInteractable != null)
            {
                _lastInteractable.SetGlow(false);
                _lastInteractable = null;
            }
        }
    }
    void OnDrawGizmos(){
        if(!HeadTransform)
            return;
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(HeadTransform.position+HeadTransform.forward*InteractDistance,.05f);
        Gizmos.DrawLine(HeadTransform.position,HeadTransform.position+HeadTransform.forward*InteractDistance);
    }
}

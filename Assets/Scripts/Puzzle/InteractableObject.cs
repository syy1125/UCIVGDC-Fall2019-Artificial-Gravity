using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    
    private Animator MyAnimator;
    private string InteractAnimation = "On Interact"; //Should correspond with a state on the Animator
    public AudioClip InteractSound;
    private AudioSource _source;
    void Awake()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
        if(_source != null){
            _source.clip = InteractSound;
        }
    }    
    public override void OnInteract(){
        if(InteractSound != null && _source != null){
            _source.PlayOneShot(InteractSound);
        }
        if(MyAnimator != null){
            if(RepeatTimer > 0)
                return;
            DefaultInteract();
            if(Locked)
                return;
            MyAnimator.Play(InteractAnimation);
        } else {
            DefaultInteract();
        }
        
    }
    
}

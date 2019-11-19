using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkableObject : Interactable
{
    // Start is called before the first frame 
    [Header("Ignore these variables")]

    private ArtificialGravity _gravity;
    private ArtificialGravity _playerGravity;


    void Start()
    {
        _gravity = GetComponent<ArtificialGravity>();
        _playerGravity = Player.Instance.GetComponent<ArtificialGravity>();
        UnlockedHoverText = "Press E to Link Object";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 0){
            UnlockedHoverText = "Press E to Link Object";
        } else {
            UnlockedHoverText = "Press E to Unlink Object";
        }
    }
    public override void OnInteract(){
        _gravity.ToggleLink(_playerGravity);
        State = (State==0) ? 1 : 0;

    }
}

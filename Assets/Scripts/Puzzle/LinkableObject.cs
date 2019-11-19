using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkableObject : Interactable
{
    // Start is called before the first frame 

    private ArtificialGravity _gravity;
    private ArtificialGravity _playerGravity;

    public Color LinkedMaterialColor;
    private Color _defaultColor;
    void Start()
    {
        base.Start();
        _gravity = GetComponent<ArtificialGravity>();
        _playerGravity = Player.Instance.GetComponent<ArtificialGravity>();
        UnlockedHoverText = "Press E to Link Gravity";
        _defaultColor = GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 0){
            UnlockedHoverText = "Press E to Link Gravity";
        } else {
            UnlockedHoverText = "Press E to Unlink Gravity";
        }
    }
    public override void OnInteract(){
        _gravity.ToggleLink(_playerGravity);
        State = (State==0) ? 1 : 0;
        if(State == 0){
            if(GetComponent<Renderer>() != null){
                GetComponent<Renderer>().material.SetColor("_Color",_defaultColor);
            }
        } else {
            if(GetComponent<Renderer>() != null){
                GetComponent<Renderer>().material.SetColor("_Color",LinkedMaterialColor);
            }
        }
    }
}

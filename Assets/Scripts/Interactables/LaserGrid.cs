using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGrid : PuzzleElement
{
    public ActivationType Activation = ActivationType.Standard;
    public PuzzleElement DisabledBy;
    private GameObject Child; 
    private Light[] Lights;

    void Awake(){
        Child = GetComponentInChildren<Collider>().gameObject;
        Lights = GetComponentsInChildren<Light>();
        if(DisabledBy != null){
            DisabledBy.ActivateEvent += new PuzzleElementEventHandler(OnActivate);
            DisabledBy.DeactivateEvent += new PuzzleElementEventHandler(OnDeactivate);
            DisabledBy.ToggleEvent += new PuzzleElementEventHandler(OnToggle);
        } 
    }
    void Update(){
        //A Child is disabled because this current gameObject must be enabled to receive events.
        Child.SetActive(State==1);
        foreach(Light l in Lights){
            l.enabled = (State==1);
        }
    }
    void OnTriggerEnter(Collider collider){
        PlayerState Player = collider.GetComponent<PlayerState>();
        if(Player != null){
            Player.KillPlayer();
        }
    }
    public void OnActivate(){
        if(Activation != ActivationType.OnlyDeactivate){
            State = 0;
        }
    }
    public void OnDeactivate(){
        if(Activation != ActivationType.OnlyActivate){
            State = 1;
        }
    }
    public void OnToggle(){
        if(State == 0){
            State = 1;
        } else if(State == 1){
            State = 0;
        }
    }
}

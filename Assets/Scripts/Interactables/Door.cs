using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PuzzleElement
{
    // Start is called before the first frame update
    private Animator DoorAnimator;
    public ActivationType Activation = ActivationType.Standard;
    public PuzzleElement TriggeredBy;
    public float DoorSpeed = 1;
    private float AnimTime = 0;
    
    void Awake(){
        DoorAnimator = gameObject.GetComponent<Animator>();
        if(State==1){
            AnimTime = 1;
        } else {
            AnimTime = 0;
        }
        TriggeredBy.ActivateEvent += new PuzzleElementEventHandler(OnActivate);
        TriggeredBy.DeactivateEvent += new PuzzleElementEventHandler(OnDeactivate);
        TriggeredBy.ToggleEvent += new PuzzleElementEventHandler(OnToggle);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 0){
            if(AnimTime > 0){
                AnimTime -= Time.deltaTime*DoorSpeed;
            }
        } else if(State == 1){
            if(AnimTime < 1){
                AnimTime += Time.deltaTime*DoorSpeed;
            }
        }
        DoorAnimator.SetFloat("Time",AnimTime);
    }
    public void OnActivate(){
        if(Activation != ActivationType.OnlyDeactivate){
            State = 1;
        }
    }
    public void OnDeactivate(){
        if(Activation != ActivationType.OnlyActivate){
            State = 0;
        }
    }
    public void OnToggle(){
        if(State == 0){
            State = 1;
            OnActivate();
        } else if(State == 1){
            State = 0;
            OnDeactivate();
        }
    }
}

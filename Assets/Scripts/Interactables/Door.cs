using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PuzzleElement
{
    // Start is called before the first frame update
    private Animator animator;
    public ActivationType activationType = ActivationType.STANDARD;
    public PuzzleElement triggeredBy;
    public float doorSpeed = 1;
    private float animTime = 0;
    
    void Awake(){
        animator = gameObject.GetComponent<Animator>();
        if(state==1){
            animTime = 0;
        } else {
            animTime = 1;
        }
        triggeredBy.activateEvent += new PuzzleElementEventHandler(onActivate);
        triggeredBy.deactivateEvent += new PuzzleElementEventHandler(onDeactivate);
        triggeredBy.toggleEvent += new PuzzleElementEventHandler(onToggle);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0){
            if(animTime > 0){
                animTime -= Time.deltaTime*doorSpeed;
            }
        } else if(state == 1){
            if(animTime < 1){
                animTime += Time.deltaTime*doorSpeed;
            }
        }
        animator.SetFloat("Time",animTime);
    }
    public void onActivate(){
        if(activationType != ActivationType.ONLYDEACTIVATE){
            state = 1;
            //animator.SetFloat("DoorSpeed",1f);

        }
    }
    public void onDeactivate(){
        if(activationType != ActivationType.ONLYACTIVATE){
            state = 0;
            //animator.SetFloat("DoorSpeed",-1f);
        }
    }
    public void onToggle(){
        if(state == 0){
            state = 1;
            onActivate();
        } else if(state == 1){
            state = 0;
            onDeactivate();
        }
    }
}

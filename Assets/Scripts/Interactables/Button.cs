using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PuzzleElement
{
    // Start is called before the first frame update

    private Animator ButtonAnimator;
    private GameObject Trigger;
    private float AnimTime = 0;
    public float ButtonSpeed = 1f;
    void Awake()
    {
        ButtonAnimator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 0){
            if(AnimTime > 0){
                AnimTime -= Time.deltaTime*ButtonSpeed;
            }
        } else if(State == 1){
            if(AnimTime < 1){
                AnimTime += Time.deltaTime*ButtonSpeed;
            }
        }
        ButtonAnimator.SetFloat("Time",AnimTime);
    }
    public void ActivateOthers(){
        State = 1;
        base.ActivateOthers();
    }
    public void DeactivateOthers(){
        State = 0;
        base.DeactivateOthers();
    }
}

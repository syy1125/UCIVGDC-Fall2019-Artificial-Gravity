using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PuzzleElement
{
    // Start is called before the first frame update

    private Animator animator;
    private GameObject trigger;
    private float animTime = 0;
    public float buttonSpeed = 1f;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0){
            if(animTime > 0){
                animTime -= Time.deltaTime*buttonSpeed;
            }
        } else if(state == 1){
            if(animTime < 1){
                animTime += Time.deltaTime*buttonSpeed;
            }
        }
        animator.SetFloat("Time",animTime);
    }
    public void activateOthers(){
        state = 1;
        base.activateOthers();
    }
    public void deactivateOthers(){
        state = 0;
        base.deactivateOthers();
    }
}

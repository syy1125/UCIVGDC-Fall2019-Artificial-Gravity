using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBox : PuzzleElement
{
    // Start is called before the first frame update
    public string DismissKey = "e";

    [Header("Optional Trigger Options")]
    public PuzzleElement TriggeredBy; //i.e. A button press can open a popup box
    public PopupBox TriggerNextPopup; //Will open another popupbox (a chain of boxes is possible)
    private CanvasGroup _group;

    void Awake()
    {
        if(TriggeredBy != null){
            TriggeredBy.ActivateEvent += new PuzzleElementEventHandler(OnActivate);
        }
        _group = GetComponent<CanvasGroup>();
        if(State == 1){
            OnActivate();
        } else {
            _group.alpha = 0;
            _group.blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 1 && Input.GetKeyDown(DismissKey)){
            StartCoroutine(Dismiss());
        }
    }
    public void OnActivate(){
        State = 1;
        _group.alpha = 1;
        _group.blocksRaycasts = true;
        Player.ActivePopup = true;
    }
    public IEnumerator Dismiss(){
        State = 0;
        
        if(TriggerNextPopup != null){
            yield return null; //Prevent next popupbox from using this frame's input to close itself
            _group.alpha = 0;
            _group.blocksRaycasts = false;
            TriggerNextPopup.OnActivate();
        } else {
            _group.alpha = 0;
            _group.blocksRaycasts = false;
            Player.ActivePopup = false;
        }
    }
    public void ForceClose(){
        //Do not activate other boxes on dismissal
        State = 0;
        _group.alpha = 0;
        _group.blocksRaycasts = false;
        Player.ActivePopup = false;
    }
}

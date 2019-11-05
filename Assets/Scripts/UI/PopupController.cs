using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    /*
        This class lets you put all popupboxes into an array
        and open/close them by index.
        I am unsure if this class is necessary.
     */

    [HideInInspector]
    public PopupBox[] Boxes;
    void Awake()
    {
        Boxes = GetComponentsInChildren<PopupBox>();
    }

   
    public void OpenBox(int i){
        Boxes[i].OnActivate();
    }
    public void CloseBox(int i){
        Boxes[i].ForceClose();
    }
    public void CloseAll(){
        for(int i = 0; i < Boxes.Length; i++){
            if(Boxes[i].State == 1){
                Boxes[i].ForceClose();
            }
        }
    }
}

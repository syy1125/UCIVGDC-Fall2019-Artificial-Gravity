using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public string PauseKey;
    private CanvasGroup _canvasGroup;

    public GameObject DefaultButton;
    private EventSystem _eventSystem;
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Dead)
            return;
        if(Input.GetKeyDown(PauseKey)){
            if(!Player.Paused){
                Pause();
            } else {
                Unpause();
            }
        }
    }
    public void Pause(){
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        _eventSystem.SetSelectedGameObject(DefaultButton);
        Player.Paused = true;

    }
    public void Unpause(){
        Time.timeScale = 1;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        _eventSystem.SetSelectedGameObject(null);
        Player.Paused = false;
    }
    public void MainMenuPress(){
        _canvasGroup.interactable = false;
        Time.timeScale = 1;
        StartCoroutine(Transition.LoadLevel("Main Menu",false));
    }
}

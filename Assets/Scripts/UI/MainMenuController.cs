using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MenuState {
        MainMenu,
        SelectLevel,
        Credits
    }

    public static MenuState State;
    private bool AllowInput;
    private Canvas _mainMenuCanvas;
    private Canvas _levelSelectCanvas;
    private Canvas _creditsCanvas;
    private EventSystem _eventSystem;

    public GameObject CreditsNames;
    public GameObject CreditsRoles;
    private UIRevealer[] _names;
    private UIRevealer[] _roles;

    void Awake()
    {
        State = MenuState.MainMenu;
        AllowInput = true;
        _mainMenuCanvas = GetComponentsInChildren<Canvas>()[0];
        _levelSelectCanvas = GetComponentsInChildren<Canvas>()[1];
        _creditsCanvas = GetComponentsInChildren<Canvas>()[2];
        _eventSystem = EventSystem.current;
        _names = CreditsNames.GetComponentsInChildren<UIRevealer>();
        _roles = CreditsRoles.GetComponentsInChildren<UIRevealer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(State){
            case MenuState.MainMenu:
                _mainMenuCanvas.enabled = true;
                _levelSelectCanvas.enabled = false;
                _creditsCanvas.enabled = false;
                break;
            case MenuState.SelectLevel:
                _mainMenuCanvas.enabled = false;
                _levelSelectCanvas.enabled = true;
                _creditsCanvas.enabled = false;
                break;
            case MenuState.Credits:
                _mainMenuCanvas.enabled = false;
                _levelSelectCanvas.enabled = false;
                _creditsCanvas.enabled = true;
                break;
        }
    }

    public void LoadLevel(int levelNum){
        if(!AllowInput)
            return;
        AllowInput = false;
        Transition.Instance.StartCoroutine(Transition.LoadLevel(LevelName(levelNum)));
    }
    public void LevelSelectButtonPress(){
        if(!AllowInput)
            return;
        State = MenuState.SelectLevel;
        _eventSystem.SetSelectedGameObject(null);
    }
    public void LevelSelectBackButtonPress(){
        if(!AllowInput)
            return;
        State = MenuState.MainMenu;
        _eventSystem.SetSelectedGameObject(null);
    }
    public void CreditsButtonPress(){
        if(!AllowInput)
            return;
        State = MenuState.Credits;
        StartCoroutine(RevealCredits());
        _eventSystem.SetSelectedGameObject(null);
    }
    public void CreditsButtonBack(){
        if(!AllowInput)
            return;
        HideCredits();
        State = MenuState.MainMenu;
        _eventSystem.SetSelectedGameObject(null);

    }
    public void QuitButtonPress(){
        if(!AllowInput)
            return;
        AllowInput = false;
        Application.Quit();
    }
    public string LevelName(int levelNum){
        return "Level " + levelNum;
    }
    private IEnumerator RevealCredits(){
        yield return new WaitForSeconds(0.25f);
        for(int i = 0; i < _names.Length; i++){
            if(State != MenuState.Credits)
                break;
            _names[i].revealUI();
            _roles[i].revealUI();
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void HideCredits(){
        for(int i = 0; i < _names.Length; i++){
            _names[i].hideImmediately();
            _roles[i].hideImmediately();
        }
    }
    
}


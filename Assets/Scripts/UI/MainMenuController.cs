using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MenuState {
        MainMenu,
        Credits
    }
    public string PlaySceneName;
    public string LevelSelectSceneName;

    public static MenuState State;
    private bool AllowInput;

    void Awake()
    {
        State = MenuState.MainMenu;
        AllowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPress(){
        if(!AllowInput)
            return;
        AllowInput = false;
        StartCoroutine(Transition.LoadLevel(PlaySceneName,false));
    }
    public void LevelSelectButtonPress(){
        if(!AllowInput)
            return;
        AllowInput = false;
        StartCoroutine(Transition.LoadLevel(LevelSelectSceneName,false));
    }
    public void CreditsButtonPress(){
        if(!AllowInput)
            return;
        State = MenuState.Credits;
    }
    public void QuitButtonPress(){
        if(!AllowInput)
            return;
        AllowInput = false;
        Application.Quit();
    }
    
    
}


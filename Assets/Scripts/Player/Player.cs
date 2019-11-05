﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{


    public static Player Instance;
    private PlayerLook _playerLook;
    private PlayerMovement _playerMovement;
    private PlayerInteract _playerInteract;
    private GravitonSurge _gravitonSurge;

    public static bool Dead;
    public static bool Paused;

    public static bool ActivePopup;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Dead = false;
        Paused = false;
        ActivePopup = false;

        _playerLook = GetComponentInChildren<PlayerLook>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
        _gravitonSurge = GetComponent<GravitonSurge>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerLook.enabled = !Dead && !Paused;
    }
    
    public void KillPlayer(){
        Dead = true;
        var playerCamera = GetComponentInChildren<Camera>();
        playerCamera.transform.SetParent(null);
		playerCamera.GetComponent<PlayerLook>().enabled = false;
		gameObject.SetActive(false);
    }
    public static bool AllowInput(){
        return !Player.Paused && !Player.Dead && !Player.ActivePopup;
    }
    public static bool KeyDown(string key){
        //Query all keystrokes through this function.
        if(!AllowInput())
            return false;
        return Input.GetKeyDown(key);
    }
    public static bool KeyDown(KeyCode key){
        if(!AllowInput())
            return false;
        return Input.GetKeyDown(key);    
    }
    public static bool Key(string key){
        if(!AllowInput())
            return false;
        return Input.GetKey(key);
    }
    public static bool Key(KeyCode key){
        if(!AllowInput())
            return false;
        return Input.GetKey(key);
    }
    public static bool KeyUp(string key){
        if(!AllowInput())
            return false;
        return Input.GetKeyUp(key);
    }
    public static bool KeyUp(KeyCode key){
        if(!AllowInput())
            return false;
        return Input.GetKeyUp(key);
    }
}

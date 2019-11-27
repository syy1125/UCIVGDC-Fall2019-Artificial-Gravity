using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType{
    Repeatable,
    OnlyOnce,
    Toggle
}
public abstract class Interactable : PuzzleElement
{
    /*
        This class will be used for objects the player can interact 
        with ("Press E to pull lever/press button/lift rubble, etc)

        Interact Type:
        Repeatable--Send activateOthers() once per interaction
        OnlyOnce--Send activateOthers() only once
        Toggle--Swap between sending activateOthers() and deactivateOthers()
     */
    public bool Locked = false;
    public string UnlockedByItem; //should match item name in inventory
    public InteractType Interaction = InteractType.Repeatable;
    public string UnlockedHoverText="";
    public string LockedHoverText="";
    protected float RepeatTimer = 0;
    protected bool FirstUsage = true;
    
    private PlayerInventory Inventory => Player.Instance == null ? null : Player.Instance.Inventory;
    public EventBus SendTrigger; // Trigger this when interaction succeeds
    
    public float RepeatDelay = 0.3f;  //object can only be interacted with every 0.3 seconds
    private string DefaultUnlockedHoverText;
    private string DefaultLockedHoverText;
    public Color MaterialColor = Color.white;
    public Color OutlineColor = Color.yellow;

    private Material _outlineMaterial;

    public void Start(){
        DefaultUnlockedHoverText = "Press E to use";
        DefaultLockedHoverText = "I need " + UnlockedByItem;

        if (SendTrigger != null)
        {
            ActivateEvent += SendTrigger.Invoke;
        }
        
        var r = GetComponent<Renderer>();

        if (r != null)
        {
            _outlineMaterial = new Material(Shader.Find("Custom/Outline"));
            _outlineMaterial.mainTexture = r.sharedMaterial.mainTexture;
            _outlineMaterial.SetColor("_Color", MaterialColor);
            _outlineMaterial.SetColor("_OutlineColor", OutlineColor);

            r.material = _outlineMaterial;
        }
        
        SetGlow(false);
    }

    void Update(){
        if(RepeatTimer > 0){
            RepeatTimer -= Time.deltaTime;
        } 
    }
    public string HoverText(){
        
        if(Locked && !Inventory.HasItem(UnlockedByItem)){ //Item is not currently interactable
            if(LockedHoverText != ""){ //HoverText manually entered
                return LockedHoverText;
            }
            if(LockedHoverText == "" && UnlockedByItem == ""){ //locked and no way to unlock
                return "";
            } 
            if(LockedHoverText == ""){ //locked with possible key
                return DefaultLockedHoverText;
            } 
            return "";
        } else { //Item can be interacted with
            if(UnlockedHoverText != ""){ //HoverText manually entered
                return UnlockedHoverText;
            } else { //Use default hover text
                return DefaultUnlockedHoverText;
            }
        }
    }

    public void SetGlow(bool glow)
    {
        var r = GetComponent<Renderer>();

        if (r == null) return;
        
        var block = new MaterialPropertyBlock();
        block.SetFloat("_OutlineActive", glow ? 1 : 0);
        r.SetPropertyBlock(block);
    }
    
    public abstract void OnInteract(); //Children decides interaction
    public void DefaultInteract(){
        if(Locked){
            if(Inventory.HasItem(UnlockedByItem)){
                //Continue if player has item;
                Inventory.RemoveItem(UnlockedByItem);
                Locked = false;
            } else {
                return;
            }
        }
        if(RepeatTimer > 0)
            return;


        RepeatTimer = RepeatDelay;
        switch(Interaction){
            case InteractType.Repeatable:
                ActivateOthers();
                FirstUsage = false;
                break;
            case InteractType.OnlyOnce:
                if(FirstUsage){
                    ActivateOthers();
                    FirstUsage = false;
                }
                break;
            case InteractType.Toggle:
                ToggleOthers();
                FirstUsage = false;
                break;
        }
    }

    private void OnDestroy()
    {
        if (_outlineMaterial != null)
        {
            Destroy(_outlineMaterial);
        }
    }
}

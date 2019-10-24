using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    /*
        Each string in the Inventory array is an item.
        Items must have different names.
     */
    public static PlayerInventory Instance;


    private Dictionary<string,Sprite> ItemSprites;
    public List<string> Inventory;

    void Awake(){
        ItemSprites = new Dictionary<string,Sprite>();
        Instance = this;
    }
    public void AddSprite(string name, Sprite sprite){
        ItemSprites[name] = sprite;
    }
    public Sprite GetSprite(string name){
        if(ItemSprites.ContainsKey(name))
            return ItemSprites[name];
        else
            return null;
    }
    public Sprite GetSprite(int inventoryIndex){
        if(inventoryIndex >= 0 && inventoryIndex < Inventory.Count)
            return GetSprite(Inventory[inventoryIndex]);
        else
            return null;
    }
    public void AddItem(string name){
        Inventory.Add(name);
    }
    public void RemoveItem(string name){
        Inventory.Remove(name);
    }
    public bool HasItem(string item){
        return Inventory.Contains(item);
    }
    public void PrintInventory(){
        string result = "Inventory: ";
        for(int i = 0; i < Inventory.Count; i++){
            result += Inventory[i] + ", ";
        }
        print(result);
    }
}

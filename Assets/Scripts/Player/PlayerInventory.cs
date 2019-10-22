using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    /*
        Each string in the Inventory array is an item.
        Items must have different names.
     */
    public List<string> Inventory;

    public void AddItem(string item){
        if(!Inventory.Contains(item)){
            Inventory.Add(item);
        }
    }
    public void RemoveItem(string item){
        if(Inventory.Contains(item)){
            Inventory.Remove(item);
        }
    }
    public bool HasItem(string item){
        return Inventory.Contains(item);
    }
    public void PrintInventory(){
        string result = "Inventory: ";
        for(int i = 0; i < Inventory.Count; i++){
            result += Inventory[i] + ",";
        }
        print(result);
    }
}

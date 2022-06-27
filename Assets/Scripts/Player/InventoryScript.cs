using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    private List<GameObject> inventory;

    public InventoryScript(){
        inventory = new List<GameObject>();
    }

    public bool AddItem(GameObject obj){
        inventory.Add(obj);
        return true;
    }

    public bool RemoveItem(GameObject obj){
        return inventory.Remove(obj);
    }
}

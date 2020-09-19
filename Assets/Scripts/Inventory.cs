using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour  
{
    public GameObject item = null;

    public void Pickup(GameObject item){
        this.item = item;
    }
}

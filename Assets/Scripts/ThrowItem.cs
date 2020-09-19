using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public int XVector;
    public int YVector;

    public void Throw(){
        GameObject item = gameObject.GetComponent<Inventory>().item;
        if (item){
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(20, 20, 0);
        }
    }

    void Update ()
    {
        bool down = Input.GetKeyDown(KeyCode.Space);
        if(down)
        {
            Throw();
        }
    }
}

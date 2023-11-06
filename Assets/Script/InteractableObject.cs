using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string itemName;

    public string GetItemName()
    {
   
        return itemName;
     
    }


    public void PickUp()
    {
        Debug.Log("Pick up item");
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        
        Debug.Log("Interacting with Item2");
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IInteractable 
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractorRange;
    public int itemTypecount1;
    public int itemTypecount2;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    // Attempt to cast to specific item types
                    Item1 item1 = interactObj as Item1;
                    Item2 item2 = interactObj as Item2;
                    

                    if (item1 != null)
                    {
                        Debug.Log("Interacting with Item1");
                        itemTypecount1++;
                        Debug.Log("Item1 type count:" + itemTypecount1);
                        // Add specific actions for Item1 if needed
                    }
                    else if (item2 != null)
                    {
                        Debug.Log("Interacting with Item2");
                        // Add specific actions for Item2 if needed
                        Debug.Log("Item1 type count:" + itemTypecount2);
                        itemTypecount2++;
                        weapon.SetActive(true);
                    }
                    // Add more conditions for other item types as needed
                    else
                    {
                        Debug.LogWarning("Unknown item type");
                    }

                    interactObj.Interact();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            weapon.SetActive(false);
            Debug.Log("Weapon Dropped");
        } }
}

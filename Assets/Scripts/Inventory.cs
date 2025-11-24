using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class Inventory : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] public List<ItemObject> items = new List<ItemObject>();
    Transform worldItemsTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    // Update is called once per frame
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionitem = hit.gameObject.GetComponent<ItemObject>();
        if (collisionitem != null)
        {
            AddItemToInventory(collisionitem);
            collisionitem.gameObject.SetActive(false);
        }
    }

    // adds item to the items list
    public bool AddItemToInventory(ItemObject item) 
    { 
        if (gameManager.GetGameState() == GameManager.GameState.GAMEPLAY)
        {
            items.Add(item);
            OutputInventoryToConsole();
            return true;
        }
        return false;
    }

    // removes items, returns true if item is found and removed.
    public void RemoveItemFromInventory()
    {
        ItemObject item = items[0];
        Vector3 CurrentPosition = transform.position;
        Vector3 forward = transform.forward;

        Vector3 newPosition = CurrentPosition + forward;
        newPosition += new Vector3(0, 1, 0);
        Quaternion currentRotation = transform.rotation;
        quaternion newRotation = currentRotation * quaternion.Euler(0, 0, 180);

        GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
        newItem.SetActive(true);

        items.Remove(item);
        Destroy(item.gameObject);
        OutputInventoryToConsole();
    }

    private void OutputInventoryToConsole()
    {
        string current = "Current Inventory: \n [";
        foreach (ItemObject current_item in items)
        {
            current = (current + "(Name: " + current_item.itemName + "  Desc: " + current_item.description + "), ");
        }
        print (current + "]"); 
    }
}

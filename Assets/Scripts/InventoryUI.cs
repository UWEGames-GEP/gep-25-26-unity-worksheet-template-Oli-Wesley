using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        RefreshInventory();
    }

    // Update is called once per frame
    void RefreshInventory()
    {
        foreach (GameObject uiButton in inventoryUIButtons)
        {
            uiButton.SetActive(false);
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            InventoryUIButton uIButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
            ItemObject item = inventory.items[i];

            uIButton.gameObject.SetActive(true);
            uIButton.SetButton(item);
        }
    }

    public void onInventoryUIButton(int i)
    {
        inventory.RemoveItemFromInventory(i);
        RefreshInventory();
    }
}

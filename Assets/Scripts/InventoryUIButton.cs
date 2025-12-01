using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text text;
    // Update is called once per frame
    public void SetButton(ItemObject item)
    {
        text.text = item.itemName;
    }
}

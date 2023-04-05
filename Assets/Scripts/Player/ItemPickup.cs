using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item!=null)
        {
            ItemDeatils itemDetails = InventoryMangerr.instance.GetItemDetails(item.ItemCode);

           // Debug.Log("Item Code>>" + itemDetails.itemDescription);
        }
    }
}

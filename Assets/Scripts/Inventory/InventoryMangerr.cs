using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMangerr : SingletonScriptMonoBehaviour<InventoryMangerr>
{
    private Dictionary<int, ItemDeatils> itemDetailsDictionary;
    [SerializeField]
    private ScriptableObejctItemList itemList = null;

    public List<InventoryItem>[] inventoryList;
    [SerializeField]
    public int[] inventoryListCapacityIntArray;


    private int[] selectedInventoryItem;

    protected override void Awake()
    {
        base.Awake();
        CreateInventoryList();
        CreateItemDetailsDictionary();


        selectedInventoryItem = new int[(int)InventoryLocation.count];

        for (int i = 0; i < selectedInventoryItem.Length; i++)
        {
            selectedInventoryItem[i] = -1;
        }
    }




    public void CreateInventoryList()
    {
        inventoryList = new List<InventoryItem>[(int)InventoryLocation.count];

        for (int i = 0; i < (int) InventoryLocation.count; i++)
        {
            inventoryList[i] = new List<InventoryItem>();
        }
    }
    public void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDeatils>();

        foreach (ItemDeatils itemDetails in itemList.itemDeatils)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        inventoryListCapacityIntArray[(int)InventoryLocation.count-1] = Setting.playerInitialInventoryCapacity;
    }





   public void SwapInventoryItems(InventoryLocation inventoryLOcation,int fromItem, int toItem)
    {
        if (fromItem<inventoryList[(int )inventoryLOcation].Count && toItem < inventoryList[(int)inventoryLOcation].Count
            && fromItem!=toItem&& fromItem>=0 && toItem>=0)
        {
            InventoryItem fromInventoryItem = inventoryList[(int)inventoryLOcation][fromItem];
            InventoryItem toInventoryItem = inventoryList[(int)inventoryLOcation][toItem];

            inventoryList[(int)inventoryLOcation][toItem] = toInventoryItem;
            inventoryList[(int)inventoryLOcation][fromItem] = fromInventoryItem;


            EventHandler.CallInventoryUpdatedEvent(inventoryLOcation, inventoryList[(int)inventoryLOcation]);
        }

    }


    // Clear seledcted Inventory Item..........

    public void ClearSelectedInventoryItem(InventoryLocation inventoryLocation)
    {
        selectedInventoryItem[(int)inventoryLocation] = -1;

    }
    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject gameObejctToDelete)
    {
        AddItem(inventoryLocation, item);

        Destroy(gameObejctToDelete);
    }

    //    public void AddItem(InventoryLocation inventoryLocation, Item item)
    //{
    //    int itemCode = item.ItemCode;

    //    List<InventoryItem> inventoryListt = inventoryList[(int)inventoryLocation];

    //    int itemPosition = FindItemInventory(inventoryLocation, itemCode);

    //    if (itemPosition != -1)
    //    {
    //        AddItemAtPosition(inventoryListt, itemCode, itemPosition);
    //    }
    //    else
    //    {
    //        AddItemAtPosition(inventoryListt, itemCode);
    //    }
    //}


    public void RemoveItem(InventoryLocation inventoryLocation,int itemCode)
    {
        List<InventoryItem> inventoryListt = inventoryList[(int)inventoryLocation];

        int itemPosition = FindItemInventory(inventoryLocation, itemCode);

        if (itemPosition!=-1)
        {
            RemoveItemAtPosition(inventoryListt, itemCode, itemPosition);
        }


        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryList[(int)inventoryLocation]);
    }

    private void RemoveItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQauntity - 1;

        if (quantity > 0)
        {
            inventoryItem.itemQauntity = quantity;
            inventoryItem.itemCode = itemCode;
            inventoryList[position] = inventoryItem;
        }
        else
        {
            inventoryList.RemoveAt(position);
        }
    }

    public void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.ItemCode;

        List<InventoryItem> inventoryListt = inventoryList[(int)inventoryLocation];

        int itemPosition = FindItemInventory(inventoryLocation, itemCode);

        if (itemPosition != -1)
        {
            AddItemAtPosition(inventoryListt, itemCode, itemPosition);
        }
        else
        {
            AddItemAtPosition(inventoryListt, itemCode);
        }


        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryList[(int)inventoryLocation]);
    }
    

    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQauntity = 1;
        inventoryList.Add(inventoryItem);

//
       // DebugPrintInventoryList(inventoryList);
    }

    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQauntity + 1;
        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQauntity = quantity;
        inventoryList[position] = inventoryItem;

        Debug.ClearDeveloperConsole();

      //  DebugPrintInventoryList(inventoryList);
    }



    //public int  FindItemInventory(InventoryLocation inventoryLocation, int itemCode)
    //{
    //    List<InventoryItem> iventoryList = inventoryList[(int)inventoryLocation];

    //    for (int i = 0; i < iventoryList.Count; i++)
    //    {
    //        if (inventoryList[i].Count==itemCode)
    //        {
    //            return i;
    //        }
    //    }

    //    return -1;
    //}

    public int FindItemInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryLists = inventoryList[(int)inventoryLocation];

        for (int i = 0; i < inventoryLists.Count; i++)
        {
            if (inventoryLists[i].itemCode == itemCode)
            {
                return i;
            }
        }

        return -1;
    }

    public ItemDeatils GetItemDetails(int itemCode)
    {
        ItemDeatils itemDetails;


        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }


    public string GetItemTypeDescription(itemType itemTypes)
    {
        string itemTypeDescritption;
        switch (itemTypes)
        {
            case itemType.Breaking_tool:
                itemTypeDescritption = Setting.BreakingTool;
                break;

            case itemType.Chopping_Tool:
                itemTypeDescritption = Setting.ChoppingTool;
                break;
            case itemType.Hoing_Tool:
                itemTypeDescritption = Setting.HoeingTool;
                break;
            case itemType.Reaping_Tool:
                itemTypeDescritption = Setting.ReapingTool;
                break;
            case itemType.Watering_Tool:
                itemTypeDescritption = Setting.WateringTool;
                break;
            case itemType.Collecting_tool:
                itemTypeDescritption = Setting.CollectingTool;
                break;

            default:
                itemTypeDescritption = itemTypes.ToString();
                break;

        }

        return itemTypeDescritption;
    }


    public void SetSelectedInventoryItem(InventoryLocation inventoryLocation, int itemCode)
    {
        selectedInventoryItem[(int)inventoryLocation] = itemCode;
    }

    //private void DebugPrintInventoryList(List<InventoryItem> inventoryList)
    //{
    //    foreach (InventoryItem inventoryItem in inventoryList)
    //    {
    //        Debug.Log("Item Description:" + GetItemDetails(inventoryItem.itemCode).itemDescription + "    Item Quantity: " + inventoryItem.itemQauntity);
    //    }
    //    Debug.Log("******************************************************************************");
    //}
}

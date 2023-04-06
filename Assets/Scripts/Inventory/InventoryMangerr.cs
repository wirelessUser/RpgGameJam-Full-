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

    protected override void Awake()
    {
        base.Awake();
        CreateInventoryList();
        CreateItemDetailsDictionary();
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
    }


    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQauntity = 1;
        inventoryList.Add(inventoryItem);


        DebugPrintInventoryList(inventoryList);
    }

    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQauntity + 1;
        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQauntity = quantity;
        inventoryList[position] = inventoryItem;

        Debug.ClearDeveloperConsole();

        DebugPrintInventoryList(inventoryList);
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


    private void DebugPrintInventoryList(List<InventoryItem> inventoryList)
    {
        foreach (InventoryItem inventoryItem in inventoryList)
        {
            Debug.Log("Item Description:" + GetItemDetails(inventoryItem.itemCode).itemDescription + "    Item Quantity: " + inventoryItem.itemQauntity);
        }
        Debug.Log("******************************************************************************");
    }
}

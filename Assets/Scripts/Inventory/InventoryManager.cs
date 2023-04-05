using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour /*SingletonScriptMonoBehaviour<InventoryManager>*/
{
    private Dictionary<int, ItemDeatils> itemDetailsDictionary;
    [SerializeField]
    private ScriptableObejctItemList itemList = null;
    void Start()
    {
        CreateItemDetailsDictionary();
    }

    public void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDeatils>();

        foreach (ItemDeatils itemDetails in itemList.itemDeatils)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
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

}// End Class....

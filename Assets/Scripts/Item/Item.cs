using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [ItemCodeDescription]
    [SerializeField]
    public int _itemCode;
    private SpriteRenderer spriteRenderer;

    public int ItemCode { get => _itemCode; set => _itemCode = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (ItemCode!=0)
        {
            Init(ItemCode);
        }
    }

    private void Init(int itemCodeParam)
    {
        if (itemCodeParam != 0)
        {
            ItemCode = itemCodeParam;

            ItemDeatils itemDetails = InventoryMangerr.instance.GetItemDetails(ItemCode);

         gameObject.transform.GetChild(0).GetComponent< SpriteRenderer>().sprite = itemDetails.itemSprite;

            // If item type is reapable then add nudgeable component
            if (itemDetails.itemType == itemType.Reapable_Scenary)
            {
                gameObject.AddComponent<ItemNudge>();
            }
        }
    }
}

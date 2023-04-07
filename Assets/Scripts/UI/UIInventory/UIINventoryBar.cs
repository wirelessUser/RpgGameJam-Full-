using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIINventoryBar : MonoBehaviour
{
    private RectTransform rectTransform;

    public bool _isInventoryBarPositionBottom = true;

    [SerializeField] private Sprite blank16x16Sprite;

    [SerializeField] private UiInventorySlots1[] inventorySlot;
    public GameObject InventoryBarDraggedItem;

    public GameObject inventoryTextBoxGameObejct;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    private void Update()
    {
        SwitchInventoryBarPositionMethod();
    }
    public void ClearHighlightedInventorySlot()
    {
        if (inventorySlot.Length>0)
        {
            for (int i = 0; i < inventorySlot.Length; i++)
            {
                if (inventorySlot[i].isSelected)
                {
                    inventorySlot[i].isSelected = false;

                    inventorySlot[i].InventorySlotHighLight.color = new Color(0, 0, 0, 0);

                    InventoryMangerr.Instance.ClearSelectedInventoryItem(InventoryLocation.player);
                }
            }
        }
    }

    public void SetHighlightedInventorySlot()
    {
        if (inventorySlot.Length>0)
        {
            for (int i = 0; i < inventorySlot.Length; i++)
            {
                SetHighlightedInventorySlot(i);
            }
        }
    }

    public void SetHighlightedInventorySlot(int itemPosition)
    {
        if (inventorySlot.Length>0&& inventorySlot[itemPosition].itemDetails!=null)
        {
            if (inventorySlot[itemPosition].isSelected)
            {
                inventorySlot[itemPosition].InventorySlotHighLight.color = new Color(1f, 1f, 1f, 1f);


                InventoryMangerr.Instance.SetSelectedInventoryItem(InventoryLocation.player, inventorySlot[itemPosition].itemDetails.itemCode);
            }
        }
    }

    private void OnEnable()
    {
        EventHandler.inventoryUpdatedEvent += InventoryUpdated;

    }

    private void OnDisable()
    {
        EventHandler.inventoryUpdatedEvent -= InventoryUpdated;
    }

    public void ClearInventorySlot()
    {
        if (inventorySlot.Length>0)
        {
            for (int i = 0; i < inventorySlot.Length; i++)
            {
                inventorySlot[i].inventorySlotImage.sprite = blank16x16Sprite;
                inventorySlot[i].textmeshProGui.text = "";
                inventorySlot[i].itemDetails = null;
                inventorySlot[i].itemQuanity = 0;

                SetHighlightedInventorySlot(i);
            }
        }
    }

    private void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (inventoryLocation == InventoryLocation.player)
        {
            //ClearInventorySlot();

            if (inventorySlot.Length > 0 && inventoryList.Count > 0)
            {
                // loop through inventory slots and update with corresponding inventory list item
                for (int i = 0; i < inventorySlot.Length; i++)
                {
                    if (i < inventoryList.Count)
                    {
                        int itemCode = inventoryList[i].itemCode;

                        // ItemDetails itemDetails = InventoryManager.Instance.itemList.itemDetails.Find(x => x.itemCode == itemCode);
                        ItemDeatils itemDetails = InventoryMangerr.Instance.GetItemDetails(itemCode);

                        if (itemDetails != null)
                        {
                            // add images and details to inventory item slot
                            inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                            inventorySlot[i].textmeshProGui.text = inventoryList[i].itemQauntity.ToString();
                            inventorySlot[i].itemDetails = itemDetails;
                            inventorySlot[i].itemQuanity = inventoryList[i].itemQauntity;
                          SetHighlightedInventorySlot(i);

                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public void SwitchInventoryBarPositionMethod()
    {
        Vector3 playerViewPortPosition = Player.Instance.GetPlayerViewPortPosition();
        //Debug.Log("playerViewPortPosition>>" + playerViewPortPosition);

        if (playerViewPortPosition.y >0.3f && _isInventoryBarPositionBottom==false)
        {
            //rectTransform.pivot = new Vector2(0.5f, 0f);
            //rectTransform.anchorMin= new Vector2(0.5f, 0f);
            //rectTransform.anchorMax= new Vector2(0.5f, 0f);
            //rectTransform.anchoredPosition= new Vector2(0f, 2.5f);

            //_isInventoryBarPositionBottom = true;
        }
        else if (playerViewPortPosition.y > 0.3f && _isInventoryBarPositionBottom == true)
        {
            //rectTransform.pivot = new Vector2(0.5f, 1f);
            //rectTransform.anchorMin = new Vector2(0.5f, 1f);
            //rectTransform.anchorMax = new Vector2(0.5f, 1f);
            //rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

            //_isInventoryBarPositionBottom = false;
        }
    }
}

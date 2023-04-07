using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UiInventorySlots1 : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public Camera mianCamera;
    private Transform parentTransform;
    private GameObject draggedItem;
    public Image InventorySlotHighLight;
    public Image inventorySlotImage;
    public TextMeshProUGUI textmeshProGui;
    [SerializeField]
    private UIINventoryBar inventoryBar = null;
    [SerializeField]
    private GameObject itemPrefab;
    public ItemDeatils itemDetails;
    public int itemQuanity;
    [SerializeField] private int slotNumber = 0;

   
    private Canvas parentCanvas;
    [SerializeField] private GameObject inventoryTextBoxPrefab;

    public bool isSelected = false;

    private void Awake()
    {
        mianCamera = Camera.main;
        parentTransform = GameObject.FindGameObjectWithTag(Tags.ItemParentTranfom).transform;
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void SetSelectedItem()
    {
        inventoryBar.ClearHighlightedInventorySlot();

        isSelected = true;

        inventoryBar.SetHighlightedInventorySlot();

        InventoryMangerr.Instance.SetSelectedInventoryItem(InventoryLocation.player,itemDetails.itemCode);
    }

    public void ClearSelectedItem()
    {
        inventoryBar.ClearHighlightedInventorySlot();

        isSelected = false;

        InventoryMangerr.Instance.ClearSelectedInventoryItem(InventoryLocation.player);
    }
   public void  DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null && isSelected)
        {
            Vector3 worldPosition = mianCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mianCamera.transform.position.z));

            GameObject itemGameObjectt = Instantiate(itemPrefab, worldPosition, Quaternion.identity, parentTransform);
            Item item = itemGameObjectt.GetComponent<Item>();
            item.ItemCode = itemDetails.itemCode;

            InventoryMangerr.Instance.RemoveItem(InventoryLocation.player, item.ItemCode);


            if (InventoryMangerr.instance.FindItemInventory(InventoryLocation.player,item.ItemCode)==-1)
            {
                ClearSelectedItem();
            }
        }

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails!=null)
        {
            Player.Instance.DisbalePlayerInputAndResetMovement();


            draggedItem = Instantiate(inventoryBar.InventoryBarDraggedItem, inventoryBar.transform);


            Image draagedItemImage = draggedItem.GetComponentInChildren<Image>();

            draagedItemImage.sprite = inventorySlotImage.sprite;


            SetSelectedItem();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            draggedItem.transform.position = Input.mousePosition;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            Destroy(draggedItem);


            if (eventData.pointerCurrentRaycast.gameObject!=null&& eventData.pointerCurrentRaycast.gameObject.GetComponent<UiInventorySlots1>()!=null)
            {
                int toSlotNUmber = eventData.pointerCurrentRaycast.gameObject.GetComponent<UiInventorySlots1>().slotNumber;

                InventoryMangerr.instance.SwapInventoryItems(InventoryLocation.player, slotNumber, toSlotNUmber);
                DestroyInventoryTextBox();

                ClearSelectedItem();

            }
            else
            {
                if (itemDetails.CanBeDropped)
                {
                    DropSelectedItemAtMousePosition();
                }
            }

            Player.Instance.EnablePlayerInput();
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemQuanity>0)
        {
            Debug.Log("Isde Poinbte click");
            inventoryBar.inventoryTextBoxGameObejct = Instantiate(inventoryTextBoxPrefab, transform.position, Quaternion.identity);
          inventoryBar.inventoryTextBoxGameObejct.transform.SetParent(parentCanvas.transform, false);

            UIInventoryTextBox inventoryTextBox = inventoryBar.inventoryTextBoxGameObejct.GetComponent<UIInventoryTextBox>();

            string itemTypeDescription = InventoryMangerr.Instance.GetItemTypeDescription(itemDetails.itemType);


            inventoryTextBox.SetTextBoxText(itemDetails.itemDescription, itemTypeDescription, "-", itemDetails.gitemLongDescritpion, "", "");



            //if (inventoryBar._isInventoryBarPositionBottom)
            //{
             inventoryBar.inventoryTextBoxGameObejct.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0);
                inventoryBar.inventoryTextBoxGameObejct.transform.position = new Vector3(transform.position.x, transform.position.y+1 , transform.position.z);
            //}
            //else
            //{
            //  inventoryBar.inventoryTextBoxGameObejct.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
            //    inventoryBar.inventoryTextBoxGameObejct.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
            //}
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInventoryTextBox();
        
    }

    public void DestroyInventoryTextBox()
    {
        if (inventoryBar.inventoryTextBoxGameObejct!=null)
        {
            //Destroy(inventoryBar.inventoryTextBoxGameObejct);
            DestroyImmediate(inventoryBar.inventoryTextBoxGameObejct);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Left)
        {
            if (isSelected==true)
            {
                ClearSelectedItem();
            }
            else if(itemQuanity>0)
            {
                SetSelectedItem();
            }
        }
    }
}

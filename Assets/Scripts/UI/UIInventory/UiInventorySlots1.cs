using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UiInventorySlots1 : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
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


    private void Awake()
    {
        mianCamera = Camera.main;
        parentTransform = GameObject.FindGameObjectWithTag(Tags.ItemParentTranfom).transform;
    }

   public void  DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null)
        {
            Vector3 worldPosition = mianCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mianCamera.transform.position.z));

            GameObject itemGameObjectt = Instantiate(itemPrefab, worldPosition, Quaternion.identity, parentTransform);
            Item item = itemGameObjectt.GetComponent<Item>();
            item.ItemCode = itemDetails.itemCode;

            InventoryMangerr.Instance.RemoveItem(InventoryLocation.player, item.ItemCode);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIINventoryBar : MonoBehaviour
{
    private RectTransform rectTransform;

    private bool _isInventoryBarPositionBottom = true;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    private void Update()
    {
        SwitchInventoryBarPositionMethod();
    }


    public void SwitchInventoryBarPositionMethod()
    {
        Vector3 playerViewPortPosition = Player.Instance.GetPlayerViewPortPosition();
        Debug.Log("playerViewPortPosition>>" + playerViewPortPosition);

        if (playerViewPortPosition.y >0.3f && _isInventoryBarPositionBottom==false)
        {
            rectTransform.pivot = new Vector2(0.5f, 0f);
            rectTransform.anchorMin= new Vector2(0.5f, 0f);
            rectTransform.anchorMax= new Vector2(0.5f, 0f);
            rectTransform.anchoredPosition= new Vector2(0f, 2.5f);

            _isInventoryBarPositionBottom = true;
        }
        else if (playerViewPortPosition.y > 0.3f && _isInventoryBarPositionBottom == true)
        {
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchorMin = new Vector2(0.5f, 1f);
            rectTransform.anchorMax = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

            _isInventoryBarPositionBottom = false;
        }
    }
}

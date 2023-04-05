using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InventoryItem 
{
   

    public int itemCode;
    public int itemQauntity;

    public static implicit operator List<object>(InventoryItem v)
    {
        throw new NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObejctItemList",menuName ="scriptableObejct/Item/Item List")]
public class ScriptableObejctItemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDeatils> itemDeatils;
}

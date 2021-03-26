using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemList
{
    public string ItemName;
    public string itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public float itemPower;
    public float itemDefense;
    public float itemAttackSpeed;
    public float itemLifeSteal;
    public float itemHPInCrease;
    public elementType elementtype;
    public ItemType itemType;

    public enum elementType
    {
        Non,
        Fire,
        Ice,
        Lighting,
    }
    public enum ItemType
    {
        Weapon,
        Gear,
        Consumable,
        Quest
    }
    public ItemList(string name, string id, string desc, float power, float def, float speed, float ls,float itemHPIncre, elementType etype, ItemType type, Sprite sprite)
    {
        ItemName = name;
        itemID = id;
        itemIcon = sprite;
        itemDesc = desc;
        itemPower = power;
        itemDefense = def;
        itemAttackSpeed = speed;
        itemLifeSteal = ls;
        elementtype = etype;
        itemType = type;
        itemHPInCrease = itemHPIncre;
    }
}

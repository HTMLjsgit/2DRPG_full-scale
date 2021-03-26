using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemStatus : MonoBehaviour
{
    public string ItemName;
    public string itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public float itemPower;
    public float itemDefense;
    public float itemAttackSpeed;
    public float itemLifeSteal;
    public float itemLifeInCrease;
    public ItemList.elementType etype;
    public ItemList.ItemType ItemType;
    public Text itemNameText;

    [Header("アイテムをギアに装備してるか")]
    public bool item_gear_mode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(ItemList item)
    {
        itemNameText.text = item.ItemName;
        //ItemIconに画像をセットする。
        this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        ItemName = item.ItemName;
        itemID = item.itemID;
        itemDesc = item.itemDesc;
        itemDefense = item.itemDefense;
        itemAttackSpeed = item.itemAttackSpeed;
        itemPower = item.itemPower;
        itemIcon = item.itemIcon;
        itemLifeInCrease = item.itemHPInCrease;
        itemLifeSteal = item.itemLifeSteal;
        etype = item.elementtype;
        ItemType = item.itemType;
        itemIcon = item.itemIcon;
    }
}

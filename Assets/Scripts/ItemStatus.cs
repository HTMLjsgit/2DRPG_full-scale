using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemStatus : MonoBehaviour
{
    public string ItemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public float speed;
    public float itemPower;
    public float itemDefense;
    public float itemAttackSpeed;
    public float itemLifeSteal;
    public float itemLifeInCrease;
    public ItemList.elementType etype;
    public ItemList.ItemType ItemType;
    public Text itemNameText;
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
        
    }
}

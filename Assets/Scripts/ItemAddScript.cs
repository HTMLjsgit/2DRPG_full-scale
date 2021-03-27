using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemAddScript : MonoBehaviour
{
    [SerializeField]
    public string ItemName;
    public string itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public float speed;
    public float itemPower;
    public float itemDefense;
    public float itemAttackSpeed;
    public float itemLifeSteal;
    public float itemHPInCrease;
    public ItemList.elementType etype;
    public ItemList.ItemType ItemType;
    public bool basic_mode;
    GameObject ItemController;
    GameObject GameManager;
    public bool once = false;
    private bool once_mode = false;
    public GameObject ItemImage;
    List<ItemList> itemList = new List<ItemList>();
    ItemDatabase Item_database;
    // Start is called before the first frame update
    void Start()
    {
        ItemController = GameObject.FindGameObjectWithTag("ItemController");
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        Item_database = GameObject.FindWithTag("ItemController").GetComponent<ItemDatabase>();
        itemID += "_" + SceneManager.GetActiveScene().name; //É}ÉbÉvÇ≤Ç∆Ç…IDÇê›íËÇ≈Ç´ÇÈÇÊÇ§Ç…Ç∑ÇÈÇΩÇﬂ
        if (basic_mode)
        {
            ItemAdd_to_ItemDatabase();
        }
        itemList.Add(new ItemList(ItemName, itemID, itemDesc, itemPower, itemDefense, speed, itemLifeSteal, itemHPInCrease, etype, ItemType, itemIcon));
        ItemShow();
        //ItemImage = ItemImageGetScript.item_get.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemShow()
    {
        foreach (ItemList item in ItemController.GetComponent<ItemDatabase>().items)
        {
        }
    }
    public void ItemAdd_to_ItemDatabase()
    {
        ItemController.GetComponent<ItemDatabase>().ItemImagePrefabCreate(itemList[0]);
        if(this.gameObject.GetComponent<ItemGearImageSetScript>() != null)
        {
            ItemController.GetComponent<ItemDatabase>().GearImageSetInPrefab_item(this.gameObject);
        }
        if (once)
        {
            if(once_mode == false)
            {
                ItemController.GetComponent<ItemDatabase>().ItemAdd(ItemName, itemID, itemDesc, itemPower, itemDefense, speed, itemLifeSteal,itemHPInCrease, etype, ItemType, itemIcon);
            }
            else
            {
                once_mode = true;
            }
        }
        else
        {
            ItemController.GetComponent<ItemDatabase>().ItemAdd(ItemName, itemID, itemDesc, itemPower, itemDefense, speed, itemLifeSteal, itemHPInCrease, etype, ItemType, itemIcon);
        }
        
    }

    public void ObjectDelete()
    {
        Item_database.wanna_destroy_item_id.Add(itemID);
        Destroy(this.gameObject);
    }
}

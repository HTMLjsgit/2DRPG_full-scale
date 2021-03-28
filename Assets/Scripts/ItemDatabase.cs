using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase itemDatabase;
    public List<ItemList> items = new List<ItemList>();
    public List<string> itemName = new List<string>();
    GameObject ItemImageController;
    GameObject GameManager;
    GameManagerScript game_manager_script;
    public GameObject ItemImageAndBackground; //Please put a Prefab in here.
    public List<string> wanna_destroy_item_id;
    string SceneName;
    GameObject itemPrefab;
    GearManagerScript gearManager;
    GearsSetScript gear_set_script;

    public string[] wanna_un_use_scene_name;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameController");
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        ItemImageController = game_manager_script.ItemShowImage;
        gearManager = GameObject.FindWithTag("ItemController").GetComponent<GearManagerScript>();
        gear_set_script = GameObject.FindWithTag("ItemController").GetComponent<GearsSetScript>();
        //GameObject itemprefab = Instantiate(ItemImageController, ItemImageController.transform);
        SceneName = game_manager_script.SceneName;
        foreach (ItemList item in items)
        {
            //ロードしたときに作る
            ItemImagePrefabCreate(item);
            itemName.Add(item.ItemName);
            ItemStatus item_status = itemPrefab.GetComponent<ItemStatus>();
            ItemGearImageStatus item_gear_status = itemPrefab.GetComponent<ItemGearImageStatus>();

            if (item_status.ItemType == ItemList.ItemType.Weapon && !string.IsNullOrEmpty(gearManager.weaponID))
            {
                gearManager.ItemWeaponDescSet(gearManager.WeaponDesc, itemPrefab);
            }
            else if(item_status.ItemType == ItemList.ItemType.Gear && !string.IsNullOrEmpty(gearManager.GearID))
            {
                gearManager.ItemGearDescSet(gearManager.GearDesc, itemPrefab, true);
                //↑ここを通るとGearID文字がにセットされる
            }
        }
        gearManager.GearEquipment(gearManager.GearHead, gearManager.GearLeg, gearManager.GearBody, gearManager.GearArmLeft, gearManager.GearArmRight);
        int ret = Array.IndexOf(wanna_un_use_scene_name, SceneManager.GetActiveScene().name);
        if (ret < 0)
        {
            foreach (string wannna_destroy_id in wanna_destroy_item_id)
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("item"))
                {
                    if (wannna_destroy_id == item.GetComponent<ItemAddScript>().itemID + "_" + SceneName)
                    {
                        Destroy(item);
                    }
                }
            }
        }
        SceneManager.sceneLoaded += SceneItemLoaded;

    }
    private void Awake()
    {
        itemDatabase = this;
    }

    public void ItemAdd(string name, string id, string desc, float power, float def, float speed, float ls,float itemHPInCrease, ItemList.elementType etype, ItemList.ItemType type, Sprite sprite)
    {
        items.Add(new ItemList(name, id, desc, power, def, speed,ls, itemHPInCrease, etype, type, sprite));
        itemName.Add(name);
    }
    
    public void ItemImagePrefabCreate(ItemList item)
    {
        itemPrefab = Instantiate(ItemImageAndBackground, ItemImageController.transform);
        itemPrefab.GetComponent<ItemStatus>().Create(item);
        
    }
    public void GearImageSetInPrefab_item(GameObject ItemGearImageSet)
    {
        ItemGearImageStatus item_gear_status = itemPrefab.GetComponent<ItemGearImageStatus>();
        ItemGearImageSetScript item_gear_image_set = ItemGearImageSet.GetComponent<ItemGearImageSetScript>();
        ItemStatus item_status = itemPrefab.GetComponent<ItemStatus>();
        gear_set_script.ArmsLeft.Add(item_gear_image_set.ArmsSkinLeft);
        gear_set_script.ArmsRight.Add(item_gear_image_set.ArmsSkinRight);
        gear_set_script.Leg.Add(item_gear_image_set.LegSkin);
        gear_set_script.Body.Add(item_gear_image_set.BodySkin);
        gear_set_script.Head.Add(item_gear_image_set.HeadSkin);
        gear_set_script.GearID.Add(item_status.itemID);
        gear_set_script.GearName.Add(item_status.ItemName);
        gear_set_script.GearDefense.Add(item_status.itemDefense);
    }
    // Update is called once per frame
    void Update()
    {
 //       Debug.Log(SceneManager.GetActiveScene().name + GameObject.Find("防具") + wanna_destroy_item_id);
    }
    public void SceneItemLoaded(Scene nextScene, LoadSceneMode mode)
    {
        int ret = Array.IndexOf(wanna_un_use_scene_name, SceneManager.GetActiveScene().name);
        //Debug.Log(GameObject.FindWithTag("ItemController"));
        if (ret < 0 && GameObject.FindWithTag("ItemController") != null)
        {
            foreach (string wannna_destroy_id in wanna_destroy_item_id)
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("item"))
                {
                    if (wannna_destroy_id == item.GetComponent<ItemAddScript>().itemID + "_" + nextScene.name)
                    {
                        Destroy(item);
                    }
                }
            }
            //SceneManager.sceneLoaded -= SceneLoaded;
        }
    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameController");
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        ItemImageController = game_manager_script.ItemImage;
        GameObject itemprefab = Instantiate(ItemImageController, ItemImageController.transform);
        SceneName = game_manager_script.SceneName;
        foreach (ItemList item in items)
        {
            ItemImagePrefabCreate(item);
            itemName.Add(item.ItemName);
        }
        if (SceneName != "FightScene")
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
        SceneManager.sceneLoaded += SceneLoaded;
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
        GameObject itemprefab = Instantiate(ItemImageAndBackground, ItemImageController.transform);
        itemprefab.GetComponent<ItemStatus>().Create(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (SceneName != "FightScene")
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
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class Status
{
    public Vector2 position;
    public float HP;
    public float Defense;
    public float Attack;

}
class ObjectSave
{
    public string SceneName;
    public string SceneNameBefore;
    public List<string> SceneHistroy;
    public List<string> WannnaDestroyEnemy;
    public List<string> WannaDestroyItem;
}
class ItemSave
{
    public List<float> Attack;
    public List<float> Defense;
    public List<float> LifeSteal;
    public List<float> HPIncrease;
    public List<string> ID;
    public List<string> Name;
    public List<string> Description;
    public List<float> speed;
    public List<Sprite> sprite;
    public List<ItemList.elementType> eType;
    public List<ItemList.ItemType> iType;
    public int ItemCount;
}
public class SaveObjectScript : MonoBehaviour
{
    public List<GameObject> WannaSaveGameObject;
    public static SaveObjectScript save_object;
    GameManagerScript game_manager_script;
    PlayerStatus player;
    ItemDatabase itemDatabase;

    public List<float> AttackSave;
    public List<float> DefenseSave;
    public List<float> LifeStealSave;
    public List<float> HPIncreaseSave;
    public List<string> IDSave;
    public List<float> speedSave;
    public List<string> NameSave;
    public List<string> DescriptionSave;
    public List<Sprite> spriteSave;
    public List<ItemList.elementType> eTypeSave;
    public List<ItemList.ItemType> iTypeSave;
    // Start is called before the first frame update
    void Start()
    {
        var status = PlayerPrefsObject.GetObject<Status>("Status");
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        itemDatabase = GameObject.FindWithTag("ItemController").GetComponent<ItemDatabase>();
    }

    private void Awake()
    {
        save_object = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SceneLoaded(Scene scene, LoadSceneMode SceneMode)
    {

    }
    public void Save()
    {
        var status =
                new Status
                {
                    position = player.position,
                    HP = player.HP,
                    Defense = player.Defense,
                    Attack = player.Attack
                };

                var objectSave =
                new ObjectSave
                {
                    SceneName = game_manager_script.SceneName,
                    SceneNameBefore = game_manager_script.SceneNameBefore,
                    SceneHistroy = game_manager_script.SceneHistroy,
                    WannnaDestroyEnemy = game_manager_script.wanna_destroy_enemy,
                    WannaDestroyItem = itemDatabase.wanna_destroy_item_id
                };
                foreach (ItemList item in itemDatabase.items)
                {
                    AttackSave.Add(item.itemPower);
                    HPIncreaseSave.Add(item.itemHPInCrease);
                    DefenseSave.Add(item.itemDefense);
                    NameSave.Add(item.ItemName);
                    DescriptionSave.Add(item.itemDesc);
                    spriteSave.Add(item.itemIcon);
                    LifeStealSave.Add(item.itemLifeSteal);
                    IDSave.Add(item.itemID);
                    speedSave.Add(item.itemAttackSpeed);
                    eTypeSave.Add(item.elementtype);
                    iTypeSave.Add(item.itemType);
                }
                var itemsSave = new ItemSave
                {
                    Attack = AttackSave,
                    HPIncrease = HPIncreaseSave,
                    Defense = DefenseSave,
                    Name = NameSave,
                    Description = DescriptionSave,
                    sprite = spriteSave,
                    ID = IDSave,
                    eType = eTypeSave,
                    iType = iTypeSave,
                    ItemCount = itemDatabase.items.Count,
                    LifeSteal = LifeStealSave,
                    speed = speedSave
               };
                PlayerPrefsObject.SetObject("Status", status);
                PlayerPrefsObject.SetObject("objectSave", objectSave);
                PlayerPrefsObject.SetObject("ItemSave", itemsSave);

    }
}

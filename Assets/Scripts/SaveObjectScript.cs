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

class GearSave
{
    public string weaponID;
    public string weaponName;
    public float weaponPower;
    public float WeaponAttackSpeed;


    public string GearID;
    public string GearName;
    public float GearDefense;

    public Sprite GearHead;
    public Sprite GearLeg;
    public Sprite GearBody;
    public Sprite GearArmLeft;
    public Sprite GearArmRight;

}

class GearStatusSave
{
    public List<string> GearID;
    public List<string> GearName;
    public List<float> GearDefense;
    public List<Sprite> GearHead;
    public List<Sprite> GearLeg;
    public List<Sprite> GearBody;
    public List<Sprite> GearArmLeft;
    public List<Sprite> GearArmRight;
}
public class SaveObjectScript : MonoBehaviour
{
    public List<GameObject> WannaSaveGameObject;
    public static SaveObjectScript save_object;
    GameManagerScript game_manager_script;
    PlayerStatus player;
    ItemDatabase itemDatabase;
    GearManagerScript gear_manager_script;
    GearsSetScript gear_set_script;


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

    public List<string> GearIDSave;
    public List<string> GearNameSave;
    public List<float> GearDefenseSave;
    public List<Sprite> GearHeadSave;
    public List<Sprite> GearLegSave;
    public List<Sprite> GearBodySave;
    public List<Sprite> GearArmsRightSave;
    public List<Sprite> GearArmsLeftSave;
    // Start is called before the first frame update
    void Start()
    {
        var status = PlayerPrefsObject.GetObject<Status>("Status");
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        itemDatabase = GameObject.FindWithTag("ItemController").GetComponent<ItemDatabase>();
        gear_manager_script = GameObject.FindWithTag("ItemController").GetComponent<GearManagerScript>();
        gear_set_script = GameObject.FindWithTag("ItemController").GetComponent<GearsSetScript>();
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
                for(int i = 0; i < gear_set_script.Head.Count; i++)
                {
                        GearIDSave.Add(gear_set_script.GearID[i]);
                        GearNameSave.Add(gear_set_script.GearName[i]);
                        GearDefenseSave.Add(gear_set_script.GearDefense[i]);
                        GearHeadSave.Add(gear_set_script.Head[i]);
                        GearBodySave.Add(gear_set_script.Body[i]);
                        GearLegSave.Add(gear_set_script.Leg[i]);
                        GearArmsLeftSave.Add(gear_set_script.ArmsLeft[i]);
                        GearArmsRightSave.Add(gear_set_script.ArmsRight[i]);
                }

                var GearStatusSave =
                new GearStatusSave
                {
                    GearID = GearIDSave,
                    GearName = GearNameSave,
                    GearDefense = GearDefenseSave,
                    GearHead = GearHeadSave,
                    GearLeg = GearLegSave,
                    GearBody = GearBodySave,
                    GearArmLeft = GearArmsLeftSave,
                    GearArmRight = GearArmsRightSave
                };


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
                
                var GearSave = new GearSave
                {
                    //武器シリーズ
                    weaponID = gear_manager_script.weaponID,
                    weaponName = gear_manager_script.weaponName,
                    weaponPower = gear_manager_script.weaponPower,
                    WeaponAttackSpeed = gear_manager_script.WeaponAttackSpeed,

                    //ここはギアシリーズ
                    GearDefense = gear_manager_script.GearDefense,
                    GearID = gear_manager_script.GearID,
                    GearName = gear_manager_script.GearName,
                    
                    //ここは装備画像を入れるところ
                    GearArmLeft = gear_manager_script.GearArmLeft,
                    GearArmRight = gear_manager_script.GearArmRight,

                    GearBody = gear_manager_script.GearBody,
                    GearLeg = gear_manager_script.GearLeg,
                    GearHead = gear_manager_script.GearHead
                };
                PlayerPrefsObject.SetObject("Status", status);
                PlayerPrefsObject.SetObject("objectSave", objectSave);
                PlayerPrefsObject.SetObject("ItemSave", itemsSave);
                PlayerPrefsObject.SetObject("GearSave",GearSave);
                PlayerPrefsObject.SetObject("GearStatusSave", GearStatusSave);
    }
}

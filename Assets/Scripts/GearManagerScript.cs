using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GearManagerScript : MonoBehaviour
{
    [Header("セットしておきたいオブジェクト")]
    public GameObject Gears; //こいつでON OFF 表示を判断する
    public GameObject armLeftSkin;
    public GameObject armRightSkin;

    public GameObject headSkin;
    public GameObject bodySkin;
    public GameObject LegSkin;


    [Header("セットしていくDesc達")]
    public GameObject GearDesc;
    public GameObject WeaponDesc;

    [Header("デフォルトの装備画像")]
    public Sprite InitArmRight;
    public Sprite InitArmLeft;
    public Sprite InitHead;
    public Sprite InitBody;
    public Sprite InitLeg;



    GameObject GameManager;

    [Header("装備しているアイテム武器ステータス")]

    public string weaponID;
    public string weaponName;
    public float weaponPower;
    public float WeaponAttackSpeed;

    [Header("装備しているギアステータス")]
    public string GearID;

    public string GearName;
    public float GearDefense;

    public Sprite GearHead;
    public Sprite GearBody;
    public Sprite GearLeg;
    public Sprite GearArmLeft;
    public Sprite GearArmRight;


    Toggle gears_toggle;
    GearsSetScript gear_set_script;

    PlayerStatus player_status;
    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.FindWithTag("GameController");
        gears_toggle = Gears.GetComponent<Toggle>();
        gear_set_script = GetComponent<GearsSetScript>();
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ItemGearDescSet(GameObject desc, GameObject ItemObject, bool load = false)
    {
        //ギアの装備のDescに当てはめる

        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        //装備したときにステータスを当てはめる
        player_status.DefenseSet(item_status.itemDefense);
        player_status.AttackSpeedSet(item_status.itemAttackSpeed);
        ItemGearImageStatus item_gear_image_status = ItemObject.GetComponent<ItemGearImageStatus>();
        if (desc.transform.childCount == 0)
        {
            //もしDescに何もセットされてなかったら？(通常運転)

            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
            item_status.item_gear_mode = true;
        }
        else if (desc.transform.childCount > 0)
        {
            //もしDescに何かセットされていたら？
            GameObject desc_child = desc.transform.GetChild(0).gameObject;
            ItemGearDescRemove(desc_child);
            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
        }
        GearID = item_status.itemID;
        GearName = item_status.ItemName;
        GearDefense = item_status.itemDefense;

        if (!load == true)
        {
        }

        gears_toggle.isOn = true;

    }

    public void ItemGearDescRemove(GameObject ItemObject)
    {
        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        player_status.DefenseSet(player_status.InitDefense);
        ItemObject.transform.SetParent(null);
        ItemObject.transform.SetParent(GameManager.GetComponent<GameManagerScript>().ItemShowImage.transform);
        GearName = null;
        GearDefense = 0;
        GearID = null;

        GearHead = null;
        GearLeg = null;
        GearBody = null;
        GearArmLeft = null;
        GearArmRight = null;

        item_status.item_gear_mode = false;
    }
    public void ItemWeaponDescSet(GameObject desc, GameObject ItemObject)
    {

        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        player_status.AttackSet(item_status.itemPower);

        if (desc.transform.childCount == 0)
        {
            //もしDescに何もセットされてなかったら？(通常運転)

            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
        }
        else if(desc.transform.childCount > 0)
        {
            //もしDescに何かセットされていたら？
            GameObject desc_child = desc.transform.GetChild(0).gameObject;
            ItemWeaponDescRemove(desc_child);
            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;

        }
        weaponName = item_status.ItemName;
        weaponPower = item_status.itemPower;
        WeaponAttackSpeed = item_status.itemAttackSpeed;
        weaponID = item_status.itemID;
        item_status.item_weapon_mode = true;
    }
    public void ItemWeaponDescRemove(GameObject ItemObject)
    {

        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        player_status.AttackSet(player_status.InitAttack);

        ItemObject.transform.SetParent(null);
        ItemObject.transform.SetParent(GameManager.GetComponent<GameManagerScript>().ItemShowImage.transform);
        item_status.item_weapon_mode = false;
        weaponName = null;
        weaponPower = 0;
        WeaponAttackSpeed = 0;
        weaponID = null;
    }

    public void GearEquipment(Sprite headSkinImage,Sprite LegSkinImage, Sprite bodySkinImage, Sprite armsSkinImageLeft, Sprite armsSkinImageRight)
    {
        //ここはギアを装備する関数。
        armLeftSkin.GetComponent<Image>().sprite = armsSkinImageLeft; //腕の装備セット
        armRightSkin.GetComponent<Image>().sprite = armsSkinImageRight; //腕の装備セット

        LegSkin.GetComponent<Image>().sprite = LegSkinImage;
        bodySkin.GetComponent<Image>().sprite = bodySkinImage;
        headSkin.GetComponent<Image>().sprite = headSkinImage;

        GearHead = headSkinImage;
        GearLeg = LegSkinImage;
        GearBody = bodySkinImage;
        GearArmLeft = armsSkinImageLeft;
        GearArmRight = armsSkinImageRight;

        GearBody = bodySkinImage;

    }

    public void GearReset()
    {
        //装備をすべてリセットする関数
        //腕を外す
        armLeftSkin.GetComponent<Image>().sprite = null;
        armRightSkin.GetComponent<Image>().sprite = null;

        LegSkin.GetComponent<Image>().sprite = null;
        bodySkin.GetComponent<Image>().sprite = null;
        headSkin.GetComponent<Image>().sprite = null;
        gears_toggle.isOn = false;
    }
}

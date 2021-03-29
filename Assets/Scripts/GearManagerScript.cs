using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GearManagerScript : MonoBehaviour
{
    [Header("�Z�b�g���Ă��������I�u�W�F�N�g")]
    public GameObject Gears; //������ON OFF �\���𔻒f����
    public GameObject armLeftSkin;
    public GameObject armRightSkin;

    public GameObject headSkin;
    public GameObject bodySkin;
    public GameObject LegSkin;


    [Header("�Z�b�g���Ă���Desc�B")]
    public GameObject GearDesc;
    public GameObject WeaponDesc;

    [Header("�f�t�H���g�̑����摜")]
    public Sprite InitArmRight;
    public Sprite InitArmLeft;
    public Sprite InitHead;
    public Sprite InitBody;
    public Sprite InitLeg;



    GameObject GameManager;

    [Header("�������Ă���A�C�e������X�e�[�^�X")]

    public string weaponID;
    public string weaponName;
    public float weaponPower;
    public float WeaponAttackSpeed;

    [Header("�������Ă���M�A�X�e�[�^�X")]
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
        //�M�A�̑�����Desc�ɓ��Ă͂߂�

        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        //���������Ƃ��ɃX�e�[�^�X�𓖂Ă͂߂�
        player_status.DefenseSet(item_status.itemDefense);
        player_status.AttackSpeedSet(item_status.itemAttackSpeed);
        ItemGearImageStatus item_gear_image_status = ItemObject.GetComponent<ItemGearImageStatus>();
        if (desc.transform.childCount == 0)
        {
            //����Desc�ɉ����Z�b�g����ĂȂ�������H(�ʏ�^�])

            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
            item_status.item_gear_mode = true;
        }
        else if (desc.transform.childCount > 0)
        {
            //����Desc�ɉ����Z�b�g����Ă�����H
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
            //����Desc�ɉ����Z�b�g����ĂȂ�������H(�ʏ�^�])

            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
        }
        else if(desc.transform.childCount > 0)
        {
            //����Desc�ɉ����Z�b�g����Ă�����H
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
        //�����̓M�A�𑕔�����֐��B
        armLeftSkin.GetComponent<Image>().sprite = armsSkinImageLeft; //�r�̑����Z�b�g
        armRightSkin.GetComponent<Image>().sprite = armsSkinImageRight; //�r�̑����Z�b�g

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
        //���������ׂă��Z�b�g����֐�
        //�r���O��
        armLeftSkin.GetComponent<Image>().sprite = null;
        armRightSkin.GetComponent<Image>().sprite = null;

        LegSkin.GetComponent<Image>().sprite = null;
        bodySkin.GetComponent<Image>().sprite = null;
        headSkin.GetComponent<Image>().sprite = null;
        gears_toggle.isOn = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GearManagerScript : MonoBehaviour
{
    [Header("�Z�b�g���Ă��������I�u�W�F�N�g")]
    public GameObject arms;
    public GameObject headSkin;
    public GameObject bodySkin;
    public GameObject LegSkin;


    [Header("�Z�b�g���Ă���Desc�B")]
    public GameObject HeadDesc;
    public GameObject BodyDesc;
    public GameObject ArmDesc;
    public GameObject LegDesc;
    public GameObject WeaponDesc;

    [Header("�f�t�H���g�̑����摜")]
    public Sprite[] InitArms;
    public Sprite InitHead;
    public Sprite InitBody;
    public Sprite InitLeg;


    [Header("����𑕔����Ă邩")]

    public bool gear_mode;
    public bool weapon_gear_mode;
    GameObject GameManager;

    //public Sprite ;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(weapon_gear_mode);
    }

    public void ItemDescSet(GameObject desc, GameObject ItemObject)
    {
        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        if (!item_status.item_gear_mode)
        {
            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
            item_status.item_gear_mode = true;
        }
        else
        {
            GameObject desc_child = desc.transform.GetChild(0).gameObject;
            ItemDescRemove(desc_child);
            ItemObject.GetComponent<ItemClickEvent>().before_move_item_position = ItemObject.transform.position;
            ItemObject.transform.SetParent(desc.transform);
            ItemObject.transform.position = desc.transform.position;
            item_status.item_gear_mode = false;
        }
        weapon_gear_mode = true;

    }
    public void ItemDescRemove(GameObject ItemObject)
    {
        ItemStatus item_status = ItemObject.GetComponent<ItemStatus>();
        ItemObject.transform.SetParent(null);
        ItemObject.transform.SetParent(GameManager.GetComponent<GameManagerScript>().ItemShowImage.transform);
        item_status.item_gear_mode = false;
        Debug.Log("----------------------------------------");
        weapon_gear_mode = false;
    }

    public void GearEquipment(Sprite headSkinImage,Sprite LegSkinImage, Sprite bodySkinImage, Sprite[] armsSkinImage)
    {
        //�����̓M�A�𑕔�����֐��B
            for (int i = 0; i < arms.transform.childCount; i++)
            {
                arms.transform.GetChild(i).GetComponent<Image>().sprite = armsSkinImage[i]; //�r�̑����Z�b�g
                //�@�Ђ���@�݂��@�̏��ő���
            }

            LegSkin.GetComponent<Image>().sprite = LegSkinImage;
            bodySkin.GetComponent<Image>().sprite = bodySkinImage;
            headSkin.GetComponent<Image>().sprite = headSkinImage;
    }
    public void Gear_part_remove(GameObject part)
    {
        if(part.transform.childCount == 0)
        {
            part.GetComponent<Image>().sprite = null;
        }
        else
        {
            //arms�I�u�W�F�N�g��������(arms�I�u�W�F�N�g�ɂ����q�v�f������̂ł���Ŕ��f����)
            foreach(GameObject g in part.transform)
            {
                g.GetComponent<Image>().sprite = null;
            }
        }

    }

    public void GearReset()
    {
        //���������ׂă��Z�b�g����֐�
        foreach(GameObject g in arms.transform)
        {
            //�r���O��
            g.GetComponent<Image>().sprite = null;
        }
        LegSkin.GetComponent<Image>().sprite = null;
        bodySkin.GetComponent<Image>().sprite = null;
        headSkin.GetComponent<Image>().sprite = null;
    }
}

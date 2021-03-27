using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemClickEvent : MonoBehaviour
{
    public KeyCode key;
    ItemStatus itemStatus;
    PlayerStatus player_status;
    GearManagerScript gear_manager_script;
    public Vector2 before_move_item_position;
    ItemGearImageStatus item_gear_image_status;
    GearsSetScript gears_set_script;
    // Start is called before the first frame update
    void Start()
    {
        itemStatus = this.gameObject.GetComponent<ItemStatus>();
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        gear_manager_script = GameObject.FindWithTag("ItemController").GetComponent<GearManagerScript>();
        item_gear_image_status = GetComponent<ItemGearImageStatus>();
        gears_set_script = GameObject.FindWithTag("ItemController").GetComponent<GearsSetScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSelect()
    {

        if (Input.GetKeyDown(key))
        {
            OnClick();
        }
    }
    public void OnClick()
    {
        //アイテムがクリックされたときのイベントをかく。
        float PlayerHP = player_status.HP;
        //ここはアイテムのステータスをプレイヤーに反映させる。
        player_status.DefenseSet(itemStatus.itemDefense);
        player_status.HPset(PlayerHP + itemStatus.itemLifeInCrease);
        player_status.AttackSet(itemStatus.itemPower);

        if (itemStatus.item_weapon_mode)
        {
            gear_manager_script.ItemWeaponDescRemove(this.gameObject);
        }
        else if (itemStatus.item_weapon_mode == false)
        {

            if (itemStatus.ItemType == ItemList.ItemType.Weapon)
            {
                gear_manager_script.ItemWeaponDescSet(gear_manager_script.WeaponDesc, this.gameObject);

            }
        }

        if (itemStatus.item_gear_mode)
        {
            gear_manager_script.ItemGearDescRemove(this.gameObject);
            gear_manager_script.GearReset();
        }
        else if (itemStatus.ItemType == ItemList.ItemType.Gear && itemStatus.item_gear_mode == false)
        {
            gear_manager_script.ItemGearDescSet(gear_manager_script.GearDesc, this.gameObject);
            for(int i = 0; i < gears_set_script.GearID.Count; i++)
            {
                if(gears_set_script.GearID[i] == itemStatus.itemID)
                {
                    gear_manager_script.GearEquipment(gears_set_script.Head[i], gears_set_script.Leg[i], gears_set_script.Body[i], gears_set_script.ArmsLeft[i], gears_set_script.ArmsRight[i]);
                }
            }
        }

    }



    IEnumerator PressAnimation()
    {
        this.gameObject.GetComponent<Selectable>().animator.SetBool("Pressed", true);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<Selectable>().animator.SetBool("Pressed", false);
        yield return null;
    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        itemStatus = this.gameObject.GetComponent<ItemStatus>();
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        gear_manager_script = GameObject.FindWithTag("ItemController").GetComponent<GearManagerScript>();
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
        if (gear_manager_script.weapon_gear_mode)
        {
            gear_manager_script.ItemDescRemove(this.gameObject);
        }else if (gear_manager_script.weapon_gear_mode == false)
        {
            if (itemStatus.ItemType == ItemList.ItemType.Gear)
            {
                gear_manager_script.GearEquipment(gear_manager_script.InitHead, gear_manager_script.InitLeg, gear_manager_script.InitBody, gear_manager_script.InitArms);
            }
            else if (itemStatus.ItemType == ItemList.ItemType.Weapon)
            {
                gear_manager_script.ItemDescSet(gear_manager_script.WeaponDesc, this.gameObject);

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

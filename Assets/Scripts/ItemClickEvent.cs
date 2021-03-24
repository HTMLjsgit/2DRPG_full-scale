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
    // Start is called before the first frame update
    void Start()
    {
        itemStatus = this.gameObject.GetComponent<ItemStatus>();
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
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
        //�N���b�N���ꂽ�Ƃ��̃C�x���g�������B

        float PlayerHP = player_status.HP;
        float Defense = player_status.Defense;
        float Attack = player_status.Attack;

        //�����̓A�C�e���̃X�e�[�^�X���v���C���[�ɔ��f������B
        player_status.DefenseSet(Defense + itemStatus.itemDefense);
        player_status.HPset(PlayerHP + itemStatus.itemLifeInCrease);

    }

    

    IEnumerator PressAnimation()
    {
        this.gameObject.GetComponent<Selectable>().animator.SetBool("Pressed", true);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<Selectable>().animator.SetBool("Pressed", false);
        yield return null;
    }
}

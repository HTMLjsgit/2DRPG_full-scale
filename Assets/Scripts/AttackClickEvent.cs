using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackClickEvent : MonoBehaviour
{
    FightEnemyCreate fight_enemy_create;
    BattleManagerScript battle_manager_script;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().Select();
        fight_enemy_create = FightEnemyCreate.fight_enemy_create;
        battle_manager_script = GameObject.FindWithTag("BattleManager").GetComponent<BattleManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (battle_manager_script.operation_mode)
        {
            fight_enemy_create.gameObject.transform.GetChild(0).GetComponent<Selectable>().Select();
        }
    }
}

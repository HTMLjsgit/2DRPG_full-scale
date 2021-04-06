using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseClickEvent : MonoBehaviour
{
    BattleManagerScript battle_manager_script;
    EnemyStatus enemy_status;
    PlayerStatus player_status;
    // Start is called before the first frame update
    void Start()
    {
        battle_manager_script = GameObject.FindWithTag("BattleManager").GetComponent<BattleManagerScript>();
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickForDefense() {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemy_status = enemy.GetComponent<EnemyStatus>();
            enemy_status.AttackToPlayer();
        }
    }
}

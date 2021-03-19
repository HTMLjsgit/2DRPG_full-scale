using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_all_enemy_check_script : MonoBehaviour
{
    public static kill_all_enemy_check_script kill_all_enemy_script;
    BattleManagerScript battleManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        battleManagerScript = BattleManagerScript.battle_manager_script;
    }
    private void Awake()
    {
        kill_all_enemy_script = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        if (FightEnemyCreate.fight_enemy_create.gameObject.transform.childCount - 1 == 0)
        {
            battleManagerScript.Finish(player_die: false);
        }
    }
}

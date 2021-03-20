using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EnemyStatus : MonoBehaviour
{
    public float HP;
    public float defense;
    public float Attack;
    public string enemyName;
    public bool onSelect;
    public KeyCode get_key;
    GameObject Player;
    PlayerStatus player_status;
    BattleManagerScript battle_manager_script;
    // Start is called before the first frame update
    void Start()
    {
        battle_manager_script = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManagerScript>();
        name = enemyName;
        Player = GameObject.FindGameObjectWithTag("Player");
        player_status = Player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        onSelect = true;
        if (Input.GetKeyDown(get_key))
        {
            OnClick();
        }
    }

    public void UnSelect()
    {
        onSelect = false;
    }
    public void OnClick()
    {
        Attacked(player_status.Attack);
    }
    public void Attacked(float Attacked)
    {
        //float damage = Mathf.Max(Attacked - defense);
        if(HP > 0)
        {
            HP -= Attack + defense;
            player_status.Attacked(Attack);
            if(HP < 0)
            {
                kill_all_enemy_check_script.kill_all_enemy_script.Check();

                Destroy(this.gameObject);
            }
        }
        else
        {
            kill_all_enemy_check_script.kill_all_enemy_script.Check();

            Destroy(this.gameObject);

        }
        battle_manager_script.UserActionButtons.transform.GetChild(0).GetComponent<Button>().Select();
    }
}

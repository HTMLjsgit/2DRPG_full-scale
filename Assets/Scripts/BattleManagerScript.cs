using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManagerScript : MonoBehaviour
{
    public int Enemy_count;
    public GameObject[] enemys;
    public static BattleManagerScript battle_manager_script;
    GameManagerScript game_manager_script;
    // Start is called before the first frame update
    void Start()
    {
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManagerScript>();

        FightEnemyCreate.fight_enemy_create.Create(game_manager_script);

        Debug.Log(game_manager_script);
        foreach (Transform t in FightEnemyCreate.fight_enemy_create.GetComponentInChildren<Transform>())
        {

        }
    }
    private void Awake()
    {
        battle_manager_script = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Finish(bool player_die)
    {
        if (player_die == false)
        {
            Initialize(); //Ç±Ç±Ç≈GameManagerÇÃîzóÒÇèâä˙âª
            SceneManager.LoadScene(game_manager_script.SceneNameBefore);
        }
    }


    public void Initialize()
    {
        game_manager_script.Name.Clear();
        game_manager_script.HP.Clear();
        game_manager_script.Attack.Clear();
        game_manager_script.Image.Clear();
        game_manager_script.Defense.Clear();
    }
}

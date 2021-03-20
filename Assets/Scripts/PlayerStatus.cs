using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus player_status;
    public float BeforeHP;
    public float HP;
    public float Defense;
    public float Attack;
    public Vector2 position;
    GameObject GameManager;
    GameManagerScript game_manager_script;
    Slider sliderHP;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        SceneManager.sceneUnloaded += SceneUnLoaded;
        sliderHP = game_manager_script.slider_hp;
    }
    private void Awake()
    {
        player_status = this;
    }
    void SceneUnLoaded(Scene thisScene)
    {
        if(thisScene.name != "FightScene")
        {
            BeforeHP = HP; //戦う前のHPを保存しておく。

        }
    }
    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
    }
    public void Attacked(float Attacked)
    {
        //float damage = Mathf.Max(Attacked - defense);
        if (HP > 0)
        {
            HP -= Attacked + Defense;
            if (HP < 0)
            {
                BattleManagerScript battle_manager_script = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManagerScript>();
                battle_manager_script.Finish(player_die: true);

            }
        }
        else
        {
            BattleManagerScript battle_manager_script = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManagerScript>();
            battle_manager_script.Finish(player_die: true);
        }
        sliderHP.value = HP / 100.0f;
    }
}

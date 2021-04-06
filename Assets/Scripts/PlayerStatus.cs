using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus player_status;
    public float InitHP;
    public float InitDefense;
    public float InitAttack;

    public float BeforeHP;
    public float HP;
    public float MaxHP;
    public float Defense;
    public float Attack;
    public float AttackSpeed;
    public Vector2 position;
    GameObject GameManager;
    GameManagerScript game_manager_script;
    public Slider sliderHP;
    PlayerMoveController player_move_controller;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        player_move_controller = GetComponent<PlayerMoveController>();
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        SceneManager.sceneUnloaded += SceneUnLoaded;
        sliderHP = game_manager_script.slider_hp;
        sliderHP.value = HP / 100.0f;
        InitDefense = Defense;
        InitAttack = Attack;
        if(HP > MaxHP)
        {
            Debug.LogError("HPがMAXHPよりはるか上になっています。　下になるように設定してください");
        }
    }
    private void Awake()
    {
        player_status = this;
    }
    void SceneUnLoaded(Scene thisScene)
    {
        int ret = Array.IndexOf(game_manager_script.wanna_un_use_scene_name, thisScene.name);
        if(ret < 0)
        {
            BeforeHP = HP; //戦う前のHPを保存しておく。

        }
    }
    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
    }
    public void DefenseSet(float set)
    {
        Defense = set;
    }
    public void AttackSet(float set)
    {
        Attack = set;
    }
    public void AttackSpeedSet(float set)
    {
        AttackSpeed = set;
    }
    public void SpeedSet(float set)
    {
        player_move_controller.speed = set;
    }
    public void HPset(float set, GameObject itemObject = null)
    {
        Debug.Log(MaxHP >= set); // 100 <= 110
        int Count = 0;
        
        if (HP > 0 && MaxHP >= set)
        {
            HP = set;
        }else if(HP > 0 && HP <= MaxHP && MaxHP <= set && MaxHP != HP)
        {
            HP = MaxHP;
        }
        else if (HP > 0 && MaxHP == HP)
        {
            return;
        }
        if (itemObject != null)
        {
            //game_manager_script.BasicSelectObject(GameObject.FindWithTag("ItemImageAndBackground"));
            GameObject.FindGameObjectsWithTag("ItemImageAndBackground")[Count].GetComponent<Selectable>().Select();
            Destroy(itemObject);
        }

        sliderHP.value = HP / 100.0f;
    }
    public void Attacked(float Attacked)
    {
        //float damage = Mathf.Max(Attacked - defense);
        BattleManagerScript battle_manager_script = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManagerScript>();
        if (HP > 0)
        {
            float Damage = Defense - Attacked;
            if(Damage < 0)
            {
                HP = HP + Damage;
            }
            if (HP < 0)
            {
                sliderHP.value = 0;
                battle_manager_script.Finish(player_die: true);

            }
        }
        else
        {
            sliderHP.value = 0;
            battle_manager_script.Finish(player_die: true);
        }
        sliderHP.value = HP / 100.0f;
    }
}

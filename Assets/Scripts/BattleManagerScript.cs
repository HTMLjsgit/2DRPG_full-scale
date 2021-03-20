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
    public GameObject Canvas;
    public GameObject UserActionButtons;
    // Start is called before the first frame update
    void Start()
    {
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManagerScript>();
        FightEnemyCreate.fight_enemy_create.Create(game_manager_script);
        foreach (Transform t in FightEnemyCreate.fight_enemy_create.GetComponentInChildren<Transform>())
        {

        }
        game_manager_script.slider_hp.transform.SetParent(Canvas.transform);
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
        game_manager_script.slider_hp.transform.SetParent(game_manager_script.Canvas.transform);
        if (player_die == false)
        {
            //敵が全滅したとき。
            game_manager_script.wanna_destroy_enemy.Add(game_manager_script.EnemyFightName);
            Initialize(); //ここでGameManagerの配列を初期化
            
            SceneManager.LoadScene(game_manager_script.SceneNameBefore);
            
        }
        else
        {
            //プレイヤーが死んだとき
            Initialize(); //ここでGameManagerの配列を初期化
            SceneManager.LoadScene("GameOver"); //GameOverに飛ばす
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

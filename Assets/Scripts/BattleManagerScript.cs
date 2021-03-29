using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManagerScript : MonoBehaviour
{
    public int Enemy_count;
    public GameObject[] enemys;
    public static BattleManagerScript battle_manager_script;
    GameManagerScript game_manager_script;
    public GameObject Canvas;
    public GameObject UserActionButtons;
    GameObject Player;
    GameObject Enemy;
    PlayerStatus player_status;
    EnemyStatus enemy_status;
    // Start is called before the first frame update
    void Start()
    {
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManagerScript>();
        FightEnemyCreate.fight_enemy_create.Create(game_manager_script);
        foreach (Transform t in FightEnemyCreate.fight_enemy_create.GetComponentInChildren<Transform>())
        {

        }
        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("enemy");
        player_status = Player.GetComponent<PlayerStatus>();
        enemy_status = Enemy.GetComponent<EnemyStatus>();
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
        //�퓬���I�������(�G�����ʂ��v���C���[�����ʂ�)
        game_manager_script.slider_hp.transform.SetParent(game_manager_script.Canvas.transform);
        if (player_die == false)
        {
            //�G���S�ł����Ƃ��B
            game_manager_script.wanna_destroy_enemy.Add(game_manager_script.EnemyFightName);
            Initialize(); //������GameManager�̔z���������
            
            StartCoroutine(GameSceneMove(game_manager_script.SceneNameBefore));
            
        }
        else
        {
            //�v���C���[�����񂾂Ƃ�
            Initialize(); //������GameManager�̔z���������
            StartCoroutine(GameSceneMove("GameOver")); //GameOver�ɔ�΂�
        }

    }

    public void AutoSelect()
    {
        Debug.Log("AutoSelect�����͂���������������������������������");
        //�Z���N�g���Ă����֐�
        UserActionButtons.transform.GetChild(0).GetComponent<Button>().Select();
    }


    public void EnemyOrPlayerAttackCheck(EnemyStatus enemy_status_get)
    {
        float PlayerAttackSpeed = player_status.AttackSpeed;
        float EnemyAttackSpeed = enemy_status_get.attack_speed;
        if(PlayerAttackSpeed <= EnemyAttackSpeed)
        {
            //�����G�̍U�����s�[�g���v���C���[�̍U���X�s�[�h��葬��������
            player_status.Attacked(enemy_status_get.Attack);
        }
    }
    IEnumerator GameSceneMove(string SceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);

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

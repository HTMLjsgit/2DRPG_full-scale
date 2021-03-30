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
    Vector2 PlayerSliderPosition;
    Vector2 MoveToSliderPosition;
    public GameObject MoveToSliderObject;
    public GameObject PlayerSliderCanvas;
    // Start is called before the first frame update
    void Start()
    {
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManagerScript>();
        FightEnemyCreate.fight_enemy_create.Create(game_manager_script);
        foreach (Transform t in FightEnemyCreate.fight_enemy_create.GetComponentInChildren<Transform>())
        {

        }
        MoveToSliderPosition = MoveToSliderObject.transform.position;

        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("enemy");
        player_status = Player.GetComponent<PlayerStatus>();
        PlayerSliderCanvas = game_manager_script.SliderPlayerDefaultBox;
        enemy_status = Enemy.GetComponent<EnemyStatus>();

        PlayerSliderPosition = game_manager_script.SliderPlayerDefaultBox.transform.position;
        player_status.sliderHP.transform.position = MoveToSliderPosition;
        player_status.sliderHP.transform.SetParent(MoveToSliderObject.transform);

        //slider_hp.transform.SetParent(Canvas.transform);
        //SceneManager.sceneLoaded += SceneLoaded;
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
        player_status.sliderHP.transform.SetParent(null);
        player_status.sliderHP.transform.SetParent(PlayerSliderCanvas.transform);
        player_status.sliderHP.transform.position = PlayerSliderPosition;
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

    public void SceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("heloooooooooooooooo");
        game_manager_script.slider_hp.transform.SetParent(null);
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}

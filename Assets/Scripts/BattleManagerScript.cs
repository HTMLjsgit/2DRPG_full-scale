using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

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
    public Button[] ButtonAll;
    public bool operation_mode = true;
    // Start is called before the first frame update
    void Start()
    {
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManagerScript>();
        FightEnemyCreate.fight_enemy_create.Create(game_manager_script);
        int x = 0;
        foreach (Transform t in FightEnemyCreate.fight_enemy_create.GetComponentInChildren<Transform>())
        {
            enemy_status = t.GetComponent<EnemyStatus>();
            enemy_status.MyID = x;
            x++;
        }
        MoveToSliderPosition = MoveToSliderObject.transform.position;

        Player = GameObject.FindWithTag("Player");
        player_status = Player.GetComponent<PlayerStatus>();
        PlayerSliderCanvas = game_manager_script.SliderPlayerDefaultBox;

        PlayerSliderPosition = game_manager_script.SliderPlayerDefaultBox.transform.position;
        player_status.sliderHP.transform.position = MoveToSliderPosition;
        player_status.sliderHP.transform.SetParent(MoveToSliderObject.transform);
        ButtonAllInvalid();
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

    public IEnumerator TimeTurnCheckAndAttackToPlayer(EnemyStatus enemy_status)
    {
        Debug.Log("������ʂ��Ă�H");
        enemy_status.AttackNow = true;
        EnemyAttackFinishCheck();

        //True���������b�܂B
        if (EnemyAttackCheckTurn(enemy_status))
                {
                    yield return new WaitForSeconds(1f);
                };

        //AutoSelect();
        yield return null;
    }

    public void AutoSelect()
    {
        ButtonAllValidity();
        if (operation_mode)
        {
            //�Z���N�g���Ă����֐�
            UserActionButtons.transform.GetChild(0).GetComponent<Button>().Select();
        }

    }

    public IEnumerator AttackToAllEnemy()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(enemy.GetComponent<EnemyStatus>().AttackToPlayer());
            AutoSelect();

        }
        yield return null;
    }


    public bool EnemyAttackCheckTurn(EnemyStatus enemy_status_get)
    {
        //�G�̍U���ł��邩����
        if(enemy_status_get.MyTurn <= 0)
        {
            //�G�̃^�[����0�ȉ���������U�����܂��B
            StartCoroutine(enemy_status_get.AttackToPlayer());
            enemy_status_get.MyTurn = enemy_status_get.InitTurn;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void EnemyAttackFinishCheck()
    {
        Debug.Log("-----------------------------------");
            if (GameObject.FindGameObjectsWithTag("enemy").Last().GetComponent<EnemyStatus>().AttackNow == true)
            {
                Debug.Log("MYIDDDDDDDDDDDDDDDDDDDDDDDDDdd");
            //�G�̍U�����I��������ǂ����𔻒f����֐�
                AutoSelect();
                foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    enemy.GetComponent<EnemyStatus>().AttackNow = false;

                }
            }

    }

    public void EnemyTurnFallDown(EnemyStatus enemy_status)
    {
            if (enemy_status.MyTurn > 0)
            {
                enemy_status.MyTurn--;
            }
            else
            {

            }
            enemy_status.EnemyTurnText.GetComponent<Text>().text = "�c��̃^�[��: " + enemy_status.MyTurn.ToString();

    }


    public void EnemySpeedAttackCheck(EnemyStatus enemy_status)
    {
        if(enemy_status.attack_speed > player_status.AttackSpeed)
        {
            StartCoroutine(enemy_status.AttackToPlayer());
            enemy_status.enemy_first_attack = true;
        }
        AutoSelect();
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
        game_manager_script.slider_hp.transform.SetParent(null);
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    public void ButtonAllValidity()
    {
        //Button���ׂĂ�L��
        foreach (Button button in ButtonAll)
        {
            button.interactable = true;
        }
        operation_mode = true;
    }

    public void ButtonAllInvalid()
    {
        //Button���ׂĂ𖳌�
        foreach (Button button in ButtonAll)
        {
            button.interactable = false;
        }
        operation_mode = false;

    }
}

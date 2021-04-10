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
    public float attack_speed;
    public string enemyName;
    public bool onSelect;
    public KeyCode get_key;
    public float Damage;
    public bool enemy_first_attack = false;
    GameObject Player;
    PlayerStatus player_status;
    BattleManagerScript battle_manager_script;
    public Slider slider_hp;
    public GameObject EnemyNameText;
    public GameObject EnemyTurnText;
    GameObject GameManager;

    [Header("ターン数")]
    public int InitTurn;

    [Header("それぞれの戦闘設定")]
    public int MyTurn;
    public int MyID;
    public bool AttackNow;

    public bool IsDestroy;
    // Start is called before the first frame update
    void Start()
    {
        MyTurn = InitTurn;
        battle_manager_script = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManagerScript>();
        name = enemyName;
        Player = GameObject.FindGameObjectWithTag("Player");
        player_status = Player.GetComponent<PlayerStatus>();
        GameManager = GameObject.FindWithTag("GameController");
        EnemyTurnText.GetComponent<Text>().text = "残りのターン: " + MyTurn.ToString();
        //先手攻撃
        battle_manager_script.EnemySpeedAttackCheck(this);
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
        if (battle_manager_script.operation_mode)
        {
            StartCoroutine(Attacked(player_status.Attack));
        }
    }
    public IEnumerator Attacked(float Attacked)
    {
        //float damage = Mathf.Max(Attacked - defense);
        if(HP > 0)
        {
            Damage = defense - Attacked;
            if (Damage < 0)
            {
                HP = HP + Damage;
            }
            else
            {
                HP = 0;
            }
            AnimationAttackPlay();

        }
        else
        {


        }
        //GameManager.GetComponent<GameObjectShakeScript>().GameObjectShake(10f, 5f, this.gameObject);
        battle_manager_script.ButtonAllInvalid();
        slider_hp.value = HP / 100.0f;
        //StartCoroutine(AttackToPlayer());
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if(enemy != null)
            {
                EnemyStatus enemy_status = enemy.GetComponent<EnemyStatus>();

                Debug.Log("なんかいとおってますか？");
                battle_manager_script.EnemyTurnFallDown(enemy.GetComponent<EnemyStatus>());
                yield return new WaitForSeconds(1f);
                StartCoroutine(battle_manager_script.TimeTurnCheckAndAttackToPlayer(enemy.GetComponent<EnemyStatus>()));
                if (enemy_status.HP <= 0)
                {
                    kill_all_enemy_check_script.kill_all_enemy_script.Check();
                    StartCoroutine(enemy_status.DestroyObject());
                    yield return null;
                }
            }
        }
 
    }

    public IEnumerator AttackToPlayer()
    {
        yield return new WaitForSeconds(1f);
        player_status.Attacked(Attack);
        yield return null;
    }



    void AnimationAttackPlay()
    {
        GameObject AttackedAnimation = this.gameObject.GetComponent<AttackedAnimationObjectSetScript>().AttackedAnimation.gameObject;
        float r = AttackedAnimation.GetComponent<Image>().color.r;
        float b = AttackedAnimation.GetComponent<Image>().color.b;
        float g = AttackedAnimation.GetComponent<Image>().color.g;
        AttackedAnimation.GetComponent<Image>().color = new Color(r, b,g, 1);
        AttackedAnimation.GetComponent<Animator>().SetBool("play", true);

    }
    public IEnumerator DestroyObject()
    {
        IsDestroy = true;
        yield return new WaitForSeconds(0.5f);
        battle_manager_script.EnemyTurnFallDown(this);
        Destroy(this.gameObject);
        battle_manager_script.ButtonAllValidity();
        battle_manager_script.AutoSelect();
    }

}

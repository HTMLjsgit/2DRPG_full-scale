using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FightEnemyCreate : MonoBehaviour
{
    FightEnemyCreate enemy_create;
    public GameObject prefab;
    public GameObject enemy;
    GameManagerScript gameManager;
    public static FightEnemyCreate fight_enemy_create;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameManagerScript.gameManager;
    }

    private void Awake()
    {
        fight_enemy_create = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Create(GameManagerScript gameManager)
    {
        for(var i = 0; i < gameManager.Name.Count; i++)
        {
            enemy = Instantiate(prefab, this.transform);
            EnemyStatus enemy_status = enemy.gameObject.GetComponent<EnemyStatus>();
            enemy.gameObject.GetComponent<Image>().sprite = gameManager.Image[i];
            enemy_status.enemyName = gameManager.Name[i];
            enemy_status.HP = gameManager.HP[i];
            enemy_status.defense = gameManager.Defense[i];
            enemy_status.Attack = gameManager.Attack[i];
            enemy_status.InitTurn = gameManager.InitTurn[i];
            enemy_status.EnemyNameText.GetComponent<Text>().text = enemy_status.enemyName;
            enemy.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

}

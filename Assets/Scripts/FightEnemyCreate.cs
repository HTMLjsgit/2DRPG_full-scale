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
            enemy = Instantiate(prefab);
            enemy.gameObject.GetComponent<Image>().sprite = gameManager.Image[i];
            enemy.GetComponent<EnemyStatus>().enemyName = gameManager.Name[i];
            enemy.GetComponent<EnemyStatus>().HP = gameManager.HP[i];
            enemy.GetComponent<EnemyStatus>().defense = gameManager.Defense[i];
            enemy.GetComponent<EnemyStatus>().Attack = gameManager.Attack[i];
            enemy.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

}

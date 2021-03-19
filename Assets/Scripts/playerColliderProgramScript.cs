using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerColliderProgramScript : MonoBehaviour
{
    bool col = false;
    public GameObject before_destroy_object;
    GameManagerScript gameManager;
    public string MoveToPlaceName;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            EnemyFightSetScript enemy_set_script = collision.gameObject.transform.GetChild(0).gameObject.GetComponent<EnemyFightSetScript>();
            
            for (int i = 0; i < enemy_set_script.EnemyName.Length; i++)
            {
                gameManager.Name.Add(enemy_set_script.EnemyName[i]);
                gameManager.Attack.Add(enemy_set_script.Attack[i]);
                gameManager.Defense.Add(enemy_set_script.Defense[i]);
                gameManager.Image.Add(enemy_set_script.Image[i]);
                gameManager.HP.Add(enemy_set_script.HP[i]);
            }
            gameManager.EnemyFightName = collision.gameObject.name;
            MoveToPlaceName = collision.gameObject.tag;
            Destroy(collision.gameObject);
            SceneManager.LoadScene("FightScene");    
            col = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            col = false;
        }
    }
}

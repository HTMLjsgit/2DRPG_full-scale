using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerColliderProgramScript : MonoBehaviour
{
    bool col = false;
    GameManagerScript gameManager;
    public string MoveToPlaceName;
    GameObject target;
    public KeyCode keycode;
    TextControllerScript text_controller_script;
    public List<string> messages;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        text_controller_script = GameObject.FindWithTag("TextController").GetComponent<TextControllerScript>();
        SceneManager.sceneLoaded += SceneLoaded;

    }
    public void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager.ItemAll.GetComponent<Toggle>().isOn = false;
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && col)
        {
            if (Input.GetKeyDown(keycode))
            {
                ItemAddScript item_add_script = target.gameObject.GetComponent<ItemAddScript>();
                item_add_script.ItemAdd_to_ItemDatabase();
                text_controller_script.TextWrite(messages, item_add_script.ItemName);
                item_add_script.ObjectDelete();
                target = null;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
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
                gameManager.AttackSpeed.Add(enemy_set_script.AttackSpeed[i]);
                gameManager.InitTurn.Add(enemy_set_script.InitTurnCount[i]);
            }
            gameManager.EnemyFightName = collision.gameObject.name;
            MoveToPlaceName = collision.gameObject.tag;
            
            Destroy(collision.gameObject);
            SceneManager.LoadScene("FightScene");    
        }
        if (collision.gameObject.CompareTag("item"))
        {
            target = collision.gameObject;
        }
        col = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
        }
        col = false;
    }
}

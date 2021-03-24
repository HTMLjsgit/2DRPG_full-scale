using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using MiniJSON;
public class StartButton : MonoBehaviour
{
    public string StartSceneName;
    public GameObject ObjectGames;
    List<ItemList> itemsLoad = new List<ItemList>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneMoveStart()
    {
        SceneMove(true);
    }

    public void Continue()
    {
        SceneMove(false);
    }

    public void SceneMove(bool start)
    {

        if (start == true)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(StartSceneName);
        }
        else
        {
            var continue_load_status = PlayerPrefsObject.GetObject<Status>("Status");
            var continue_load_object_save = PlayerPrefsObject.GetObject<ObjectSave>("objectSave");
            var continue_load_item_save = PlayerPrefsObject.GetObject<ItemSave>("ItemSave");
            if(continue_load_status != null && continue_load_object_save != null)
            {
                //保存データーがあったら
                var continue_load_status_json = JsonUtility.ToJson(continue_load_status).ToString();
                var continue_load_object_save_json = JsonUtility.ToJson(continue_load_object_save).ToString();
                var continue_load_item_save_json = JsonUtility.ToJson(continue_load_item_save);

                var continue_load_status_json_taking_out = JsonUtility.FromJson<Status>(continue_load_status_json);
                var continue_load_object_save_json_taking_out = JsonUtility.FromJson<ObjectSave>(continue_load_object_save_json);
                var continue_load_item_save_json_taking_out = JsonUtility.FromJson<ItemSave>(continue_load_item_save_json);
                SceneManager.sceneLoaded += SceneLoaded;
                SceneManager.LoadScene(continue_load_object_save_json_taking_out.SceneName);
                //保存データに保存してあるシーンの名前に移動する。
            }
            else
            {
                //保存データがなかったら
                SceneManager.LoadScene(StartSceneName);

            }
        }

    }

    public void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        GameObject ObjectGames_prefab = Instantiate(ObjectGames);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject GameManager = GameObject.FindGameObjectWithTag("GameController");
        GameManagerScript GameManagerScript = GameManager.GetComponent<GameManagerScript>();
        GameObject ItemController = GameObject.FindWithTag("ItemController");
        ItemDatabase item_database = ItemController.GetComponent<ItemDatabase>();
        PlayerStatus PlayerStatus = Player.GetComponent<PlayerStatus>();


        var continue_load_status = PlayerPrefsObject.GetObject<Status>("Status");
        var continue_load_object_save = PlayerPrefsObject.GetObject<ObjectSave>("objectSave");
        var continue_load_status_json = JsonUtility.ToJson(continue_load_status).ToString();
        var continue_load_object_save_json = JsonUtility.ToJson(continue_load_object_save).ToString();
        var continue_load_item_save = PlayerPrefsObject.GetObject<ItemSave>("ItemSave");
        var continue_load_item_save_json = JsonUtility.ToJson(continue_load_item_save).ToString();

        //jsonにしてデータ取り出しできるようにする
        var continue_load_status_json_taking_out = JsonUtility.FromJson<Status>(continue_load_status_json);
        var continue_load_object_save_json_taking_out = JsonUtility.FromJson<ObjectSave>(continue_load_object_save_json);
        var continue_load_item_save_json_taking_out = JsonUtility.FromJson<ItemSave>(continue_load_item_save_json);
        //保存したデータをGameManagerに代入
        GameManagerScript.SceneHistroy = continue_load_object_save_json_taking_out.SceneHistroy;
        GameManagerScript.SceneName = continue_load_object_save_json_taking_out.SceneName;
        GameManagerScript.wanna_destroy_enemy = continue_load_object_save_json_taking_out.WannnaDestroyEnemy;
        GameManagerScript.SceneNameBefore = continue_load_object_save_json_taking_out.SceneNameBefore;

        //保存したデータをItemControllerに代入
        for(int i = 0; i <  continue_load_item_save_json_taking_out.ItemCount; i++)
        {
            string Name = continue_load_item_save_json_taking_out.Name[i];
            float speed = continue_load_item_save_json_taking_out.speed[i];
            Sprite sprite = continue_load_item_save_json_taking_out.sprite[i];
            float HPIncrease = continue_load_item_save_json_taking_out.HPIncrease[i];
            string ID = continue_load_item_save_json_taking_out.ID[i];
            float Attack = continue_load_item_save_json_taking_out.Attack[i];
            float Defense = continue_load_item_save_json_taking_out.Defense[i];
            float LifeSteal = continue_load_item_save_json_taking_out.LifeSteal[i];
            string Description = continue_load_item_save_json_taking_out.Description[i];
            ItemList.ItemType itemType = continue_load_item_save_json_taking_out.iType[i];
            ItemList.elementType elemenType = continue_load_item_save_json_taking_out.eType[i];
            //float speed = continue_load_item_save_json_taking_out.
            //ここでまずはアイテムステータスを作っていくよ。
            itemsLoad.Add(new ItemList(name: Name, id: ID, power: Attack, desc: Description, def: Defense, speed: speed, ls: LifeSteal, etype: elemenType, type: itemType, sprite: sprite, itemHPIncre: HPIncrease));
        }
        item_database.items = itemsLoad;
        //保存したデータをプレイヤーに代入
        PlayerStatus.HP = continue_load_status_json_taking_out.HP;
        PlayerStatus.Defense = continue_load_status_json_taking_out.Defense;
        PlayerStatus.Attack = continue_load_status_json_taking_out.Attack;
        PlayerStatus.position = continue_load_status_json_taking_out.position;
        PlayerStatus.gameObject.transform.position = continue_load_status_json_taking_out.position;
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}

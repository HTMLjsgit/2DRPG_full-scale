using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
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
            Debug.Log("Starttttttttttttttttttttttttttttttttttttttt");

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
        Debug.Log("I am here ScneLoaded---------------------------------");
        GameObject ObjectGames_prefab = Instantiate(ObjectGames);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject GameManager = GameObject.FindGameObjectWithTag("GameController");
        GameManagerScript GameManagerScript = GameManager.GetComponent<GameManagerScript>();
        GameObject ItemController = GameObject.FindWithTag("ItemController");
        ItemDatabase item_database = ItemController.GetComponent<ItemDatabase>();
        PlayerStatus PlayerStatus = Player.GetComponent<PlayerStatus>();
        GearManagerScript gear_manager_script = ItemController.GetComponent<GearManagerScript>();
        GearsSetScript gears_set_script = ItemController.GetComponent<GearsSetScript>();

        var continue_load_status = PlayerPrefsObject.GetObject<Status>("Status");
        var continue_load_object_save = PlayerPrefsObject.GetObject<ObjectSave>("objectSave");
        var continue_load_item_save = PlayerPrefsObject.GetObject<ItemSave>("ItemSave");
        var continue_load_gear_save = PlayerPrefsObject.GetObject<GearSave>("GearSave");
        var continue_load_gear_status_save = PlayerPrefsObject.GetObject<GearStatusSave>("GearStatusSave");

        var continue_load_status_json = JsonUtility.ToJson(continue_load_status).ToString();
        var continue_load_object_save_json = JsonUtility.ToJson(continue_load_object_save).ToString();
        var continue_load_item_save_json = JsonUtility.ToJson(continue_load_item_save).ToString();
        var continue_load_gear_save_json = JsonUtility.ToJson(continue_load_gear_save).ToString();
        var continue_load_gear_status_save_json = JsonUtility.ToJson(continue_load_gear_status_save).ToString();

        //jsonにしてデータ取り出しできるようにする
        var continue_load_status_json_taking_out = JsonUtility.FromJson<Status>(continue_load_status_json);
        var continue_load_object_save_json_taking_out = JsonUtility.FromJson<ObjectSave>(continue_load_object_save_json);
        var continue_load_item_save_json_taking_out = JsonUtility.FromJson<ItemSave>(continue_load_item_save_json);
        var continue_load_gear_save_json_taking_out = JsonUtility.FromJson<GearSave>(continue_load_gear_save_json);
        var continue_load_gear_status_save_json_taking_out = JsonUtility.FromJson<GearStatusSave>(continue_load_gear_status_save_json);

        //保存したデータをGameManagerに代入
        GameManagerScript.SceneHistroy = continue_load_object_save_json_taking_out.SceneHistroy;
        GameManagerScript.SceneName = continue_load_object_save_json_taking_out.SceneName;
        GameManagerScript.wanna_destroy_enemy = continue_load_object_save_json_taking_out.WannnaDestroyEnemy;
        GameManagerScript.SceneNameBefore = continue_load_object_save_json_taking_out.SceneNameBefore;

        //保存したデータをItemDatabase(ItemController)に代入(削除したいアイテムのID名などの保管庫)
        item_database.wanna_destroy_item_id = continue_load_object_save_json_taking_out.WannaDestroyItem;
        //保存したデータをItemControllerに代入
        for (int i = 0; i <  continue_load_item_save_json_taking_out.ItemCount; i++)
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
        //上で作成したListを入れていく―
        item_database.items = itemsLoad;

        //GearManagerScriptに代入。(装備管理スクリプト)

        gear_manager_script.weaponID = continue_load_gear_save_json_taking_out.weaponID;
        gear_manager_script.weaponName = continue_load_gear_save_json_taking_out.weaponName;
        gear_manager_script.weaponPower = continue_load_gear_save_json_taking_out.weaponPower;
        gear_manager_script.WeaponAttackSpeed = continue_load_gear_save_json_taking_out.WeaponAttackSpeed;


        gear_manager_script.GearID = continue_load_gear_save_json_taking_out.GearID;
        gear_manager_script.GearDefense = continue_load_gear_save_json_taking_out.GearDefense;
        gear_manager_script.GearName = continue_load_gear_save_json_taking_out.GearName;

        gear_manager_script.GearHead = continue_load_gear_save_json_taking_out.GearHead;
        gear_manager_script.GearBody = continue_load_gear_save_json_taking_out.GearBody;
        gear_manager_script.GearLeg = continue_load_gear_save_json_taking_out.GearLeg;
        gear_manager_script.GearArmRight = continue_load_gear_save_json_taking_out.GearArmRight;
        gear_manager_script.GearArmLeft = continue_load_gear_save_json_taking_out.GearArmLeft;


        for (int i = 0; i < continue_load_gear_status_save_json_taking_out.GearID.Count; i++)
            {
                gears_set_script.Head.Add(continue_load_gear_status_save_json_taking_out.GearHead[i]);
                gears_set_script.Body.Add(continue_load_gear_status_save_json_taking_out.GearBody[i]);
                gears_set_script.Leg.Add(continue_load_gear_status_save_json_taking_out.GearLeg[i]);
                gears_set_script.ArmsLeft.Add(continue_load_gear_status_save_json_taking_out.GearArmLeft[i]);
                gears_set_script.ArmsRight.Add(continue_load_gear_status_save_json_taking_out.GearArmRight[i]);
                gears_set_script.GearDefense.Add(continue_load_gear_status_save_json_taking_out.GearDefense[i]);
                gears_set_script.GearID.Add(continue_load_gear_status_save_json_taking_out.GearID[i]);
                gears_set_script.GearName.Add(continue_load_gear_status_save_json_taking_out.GearName[i]);

            }




        //保存したデータをPlayerStautsに代入
        PlayerStatus.HP = continue_load_status_json_taking_out.HP;
        PlayerStatus.Defense = continue_load_status_json_taking_out.Defense;
        PlayerStatus.Attack = continue_load_status_json_taking_out.Attack;
        PlayerStatus.position = continue_load_status_json_taking_out.position;
        PlayerStatus.gameObject.transform.position = continue_load_status_json_taking_out.position;
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}

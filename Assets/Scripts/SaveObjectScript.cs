using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class Status
{
    public Vector2 position;
    public float HP;
    public float Defense;
    public float Attack;

}
class ObjectSave
{
    public string SceneName;
    public string SceneNameBefore;
    public List<string> SceneHistroy;
    public List<string> WannnaDestroyEnemy;
}
public class SaveObjectScript : MonoBehaviour
{
    public List<GameObject> WannaSaveGameObject;
    public static SaveObjectScript save_object;
    GameManagerScript game_manager_script;
    PlayerStatus player;

    // Start is called before the first frame update
    void Start()
    {
        var status = PlayerPrefsObject.GetObject<Status>("Status");
        game_manager_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    private void Awake()
    {
        save_object = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SceneLoaded(Scene scene, LoadSceneMode SceneMode)
    {

    }
    public void Save()
    {
        foreach(GameObject wanna_object in WannaSaveGameObject)
        {
            if(player != null)
            {

                var status =
                new Status
                {
                    position = player.position,
                    HP = player.HP,
                    Defense = player.Defense,
                    Attack = player.Attack
                };

                var objectSave =
                new ObjectSave
                {
                    SceneName = game_manager_script.SceneName,
                    SceneNameBefore = game_manager_script.SceneNameBefore,
                    SceneHistroy = game_manager_script.SceneHistroy,
                    WannnaDestroyEnemy = game_manager_script.wanna_destroy_enemy
                };

                PlayerPrefsObject.SetObject("Status", status);
                PlayerPrefsObject.SetObject("objectSave", objectSave);
            }

        }
    }
}

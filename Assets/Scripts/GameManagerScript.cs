using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public string SceneName;
    GameObject enemy;
    GameObject player;
    public string SceneNameBefore;

    //シーン移行の履歴

    public List<string> SceneHistroy = new List<string>();
    //戦闘シーン用
    public List<string> Name = new List<string>();
    public List<float> HP = new List<float>();
    public List<float> Attack = new List<float>();
    public List<float> Defense = new List<float>();
    public List<Sprite> Image = new List<Sprite>();
    public static GameManagerScript gameManager;
    public string EnemyFightName;
    public List<string> wanna_destroy_enemy = new List<string>();
    public Dictionary<string, string> dictionary = new Dictionary<string, string>();
    public GameObject saveObject;
    public GameObject Menu;
    public Vector2 PlayerPositionSave;
    GameObject Enemy;
    public Slider slider_hp;
    public GameObject Canvas;
    public GameObject ItemShowImage;
    public GameObject ItemAll;
    public string[] wanna_un_use_scene_name;
    public bool home_check;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += SceneUnloaded;
        
        SceneManager.sceneLoaded += SceneLoaded;
        player = GameObject.FindGameObjectWithTag("Player");
        SceneName = SceneManager.GetActiveScene().name;
        SceneHistroy.Add(SceneName);
        int ret = Array.IndexOf(wanna_un_use_scene_name, SceneManager.GetActiveScene().name);

        if (ret < 0 && !home_check)
        {
            foreach (string wannna_destroy_name in wanna_destroy_enemy)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    if (wannna_destroy_name == enemy.GetComponent<EnemyNameSet>().Name)
                    {
                        Destroy(enemy);
                    }
                }
            }
        }
    }

    private void Awake()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SceneUnloaded(Scene beforeScene)
    {
        SceneNameBefore = beforeScene.name;
    }

    public void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        SceneName = nextScene.name;
        SceneHistroy.Add(nextScene.name);
        int ret = Array.IndexOf(wanna_un_use_scene_name, nextScene.name);
        if (ret < 0)
        {
            foreach (string wannna_destroy_name in wanna_destroy_enemy)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    if (wannna_destroy_name == enemy.GetComponent<EnemyNameSet>().Name)
                    {
                        Destroy(enemy);
                    }
                }
            }
        }
    }
}

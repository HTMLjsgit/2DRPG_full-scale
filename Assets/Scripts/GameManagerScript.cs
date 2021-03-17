using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManagerScript : MonoBehaviour
{
    public string SceneName;
    GameObject enemy;
    PlayerGetScript player;
    public string SceneNameBefore;

    //戦闘シーン用
    public List<string> Name = new List<string>();
    public List<float> HP = new List<float>();
    public List<float> Attack = new List<float>();
    public List<float> Defense = new List<float>();
    public List<Sprite> Image = new List<Sprite>();
    public static GameManagerScript gameManager;
    public List<string> wanna_destroy_enemy = new List<string>();
    public Dictionary<string, string> dictionary = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += SceneUnloaded;
        SceneManager.sceneLoaded += SceneLoaded;
        player = PlayerGetScript.player_get;
        SceneName = SceneManager.GetActiveScene().name;
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

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        SceneName = nextScene.name;

        if (nextScene.name == "FightScene")
        {
        }
        else if(nextScene.name == "Map1")
        {
            foreach(string wannna_destroy_name in wanna_destroy_enemy)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    if(wannna_destroy_name == enemy.GetComponent<EnemyNameSet>().Name)
                    {
                        Destroy(enemy);
                    }
                }
            }

        }
    }
}

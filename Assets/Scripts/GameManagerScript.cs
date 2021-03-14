﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManagerScript : MonoBehaviour
{
    public string SceneName;
    GameObject enemy;
    PlayerGetScript player;
    public GameObject EnemySave;
    public List<string> Name = new List<string>();
    public List<float> HP = new List<float>();
    public List<float> Attack = new List<float>();
    public List<float> Defense = new List<float>();
    public List<Sprite> Image = new List<Sprite>();
    public static GameManagerScript gameManager;
    public List<GameObject> wanna_destroy_enemy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        player = PlayerGetScript.player_get;
    }

    private void Awake()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        SceneName = nextScene.name;

        if (nextScene.name == "FightScene")
        {
            FightEnemyCreate.fight_enemy_create.Create(this);
        }
        else if(nextScene.name == "Map1")
        {
            foreach(GameObject g in wanna_destroy_enemy)
            {
                Destroy(g);
            }
        }
    }
}

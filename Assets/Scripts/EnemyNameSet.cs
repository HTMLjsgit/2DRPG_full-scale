using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyNameSet : MonoBehaviour
{
    public static EnemyNameSet enemy_set_name;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        enemy_set_name = this;
        name += SceneManager.GetActiveScene().name;
        Name = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

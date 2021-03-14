using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerGetScript : MonoBehaviour
{
    public static EnemyManagerGetScript enemy_manager_get;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        enemy_manager_get = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

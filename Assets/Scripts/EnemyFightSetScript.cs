using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyFightSetScript : MonoBehaviour
{
    public static EnemyFightSetScript enemy_script;
    public string[] EnemyName;
    public float[] HP;
    public float[] Attack;
    public float[] Defense;
    public Sprite[] Image;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        enemy_script = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

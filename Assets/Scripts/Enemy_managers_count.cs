using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_managers_count : MonoBehaviour
{
    public int Enemys;
    // Start is called before the first frame update
    void Start()
    {
        Enemys = this.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

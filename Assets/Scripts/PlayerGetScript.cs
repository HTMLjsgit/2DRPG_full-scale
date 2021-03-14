using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetScript : MonoBehaviour
{
    public static PlayerGetScript player_get;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player_get = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

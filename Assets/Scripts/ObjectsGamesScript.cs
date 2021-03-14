using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGamesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static ObjectsGamesScript Instance
    {
        get; private set;
    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySaveScriptAndDestroy : MonoBehaviour
{
    public bool DestroyMe = false;
    public bool Destroy2 = false;
    GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManagerScript.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}

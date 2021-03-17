using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public static SceneMove sceneMove;
    GameManagerScript gameManager;
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        Target.SetActive(false);
    }
    private void Awake()
    {

        sceneMove = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveToBackScene(string SceneName)
    {
        gameManager.Name.Clear();
        gameManager.HP.Clear();
        gameManager.Attack.Clear();
        gameManager.Defense.Clear();
        gameManager.Image.Clear();
        Target.SetActive(true);
        SceneManager.LoadScene(SceneName);
    }
}

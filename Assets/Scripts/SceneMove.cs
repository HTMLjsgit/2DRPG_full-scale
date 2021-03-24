using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public static SceneMove sceneMove;
    GameManagerScript game_managerScript;
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        game_managerScript = GameObject.FindWithTag("GameController").GetComponent<GameManagerScript>();
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
        game_managerScript.Name.Clear();
        game_managerScript.HP.Clear();
        game_managerScript.Attack.Clear();
        game_managerScript.Defense.Clear();
        game_managerScript.Image.Clear();
        Target.SetActive(true);
        SceneManager.LoadScene(SceneName);
    }
}

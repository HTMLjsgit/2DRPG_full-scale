using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour
{
    GameObject GameManager;
    GameManagerScript game_manager_script;
    GameObject Player;
    PlayerStatus PlayerStatus;
    public string[] do_not_wanna_move_scene_name;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        PlayerStatus = Player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Player.SetActive(true);
        PlayerStatus.HP = PlayerStatus.BeforeHP;

        SceneManager.LoadScene(game_manager_script.SceneHistroy[game_manager_script.SceneHistroy.Count - 3]);
    }
}

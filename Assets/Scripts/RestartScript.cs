using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartScript : MonoBehaviour
{
    GameObject GameManager;
    GameManagerScript game_manager_script;
    GameObject Player;
    PlayerStatus PlayerStatus;
    public string[] do_not_wanna_move_scene_name;
    Slider slider_hp;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        game_manager_script = GameManager.GetComponent<GameManagerScript>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        PlayerStatus = Player.GetComponent<PlayerStatus>();
        slider_hp = game_manager_script.slider_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Player.SetActive(true);
        PlayerStatus.HP = PlayerStatus.BeforeHP;
        slider_hp.value = PlayerStatus.HP / 100.0f;
        SceneManager.LoadScene(game_manager_script.SceneHistroy[game_manager_script.SceneHistroy.Count - 3]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyEventScript : MonoBehaviour
{
    public KeyCode MenuDisplayKeyCode;
     GameObject Menu;
    bool Menu_Display = false;
    public string[] UnDisplaySceneName;
    string SceneName;
    PlayerMoveController player_move_controller;
    float speedSave;
    // Start is called before the first frame update
    void Start()
    {
        SceneName = this.gameObject.GetComponent<GameManagerScript>().SceneName;
        player_move_controller = GameObject.FindWithTag("Player").GetComponent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(MenuDisplayKeyCode))
        {
            MenuDisplay();
        }
    }

    public void MenuDisplay()
    {
        foreach(string undisplaySceneName in UnDisplaySceneName)
        {
            if (SceneName != undisplaySceneName)
            {
                if (Menu_Display)
                {
                    //player_move_controller.enabled = true;

                    player_move_controller.speed = speedSave;
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    Menu_Display = false;

                }
                else
                {
                    speedSave = player_move_controller.speed;
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    Menu_Display = true;
                }
                Menu = this.gameObject.GetComponent<GameManagerScript>().Menu.gameObject;
                Menu.GetComponent<Animator>().SetBool("display", Menu_Display);
                player_move_controller.GetComponent<Animator>().enabled = !Menu_Display;
                player_move_controller.moveMode = !Menu_Display;
                if (Menu_Display)
                {
                    this.gameObject.GetComponent<GameManagerScript>().Canvas.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();

                }
            }
        }

    }
    void Stop()
    {
        Time.timeScale = 0;

    }
    void Play()
    {
        Time.timeScale = 1;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class KeyEventScript : MonoBehaviour
{
    public KeyCode MenuDisplayKeyCode;
    public KeyCode ItemMenuDisplayKeyCode;
    GameObject Menu;
    GameObject ItemAll;
    bool Menu_Display = false;
    bool ItemMenuDisplay = false;
    public string[] UnDisplaySceneName;
    string SceneName;
    PlayerMoveController player_move_controller;
    GameObject ImageShow;
    Toggle menu_toggle;
    Toggle item_show_menu_toggle;
    GameManagerScript game_manager_script;
    // Start is called before the first frame update
    void Start()
    {
        player_move_controller = GameObject.FindWithTag("Player").GetComponent<PlayerMoveController>();
        ItemAll = this.gameObject.GetComponent<GameManagerScript>().ItemAll;
        Menu = this.gameObject.GetComponent<GameManagerScript>().Menu.gameObject;
        ImageShow = this.gameObject.GetComponent<GameManagerScript>().ItemShowImage;
        menu_toggle = Menu.GetComponent<Toggle>();
        item_show_menu_toggle = ItemAll.GetComponent<Toggle>();
        game_manager_script = GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(MenuDisplayKeyCode) && !item_show_menu_toggle.isOn)
        {
            MenuDisplay();
        }else if (Input.GetKeyDown(ItemMenuDisplayKeyCode) && !menu_toggle.isOn)
        {
            ItemMenuShow();
        }
    }

    public void MenuDisplay()
    {

        SceneName = SceneManager.GetActiveScene().name;
            int ret = Array.IndexOf(UnDisplaySceneName, SceneName); //現在のシーンと表示したくないシーンがあったら
            if (ret < 0)
            {
                Menu_Display = !menu_toggle.isOn;
                if (!Menu_Display)
                {
                    //player_move_controller.enabled = true;

                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                }
                else if(Menu_Display)
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
                if (!ItemMenuDisplay)
                {
                    menu_toggle.isOn = Menu_Display;
                }
                Menu.GetComponent<Animator>().SetBool("display", Menu_Display);
                player_move_controller.GetComponent<Animator>().enabled = !Menu_Display;
                player_move_controller.moveMode = !Menu_Display;
                if (Menu_Display)
                {
                    GameObject g = Menu.transform.GetChild(0).gameObject;
                    game_manager_script.BasicSelectObject(g);
                }
            }
    }

    public void ItemMenuShow() {
        SceneName = this.gameObject.GetComponent<GameManagerScript>().SceneName;
        Debug.Log("開いた！！！！！！！！");
        int ret = Array.IndexOf(UnDisplaySceneName, SceneName);  //現在のシーンと表示したくないシーンがあったら
        if (ret < 0)
            {
            Debug.Log("シーンネームでバグってんじぇねぇの？");
            ItemMenuDisplay = !item_show_menu_toggle.isOn; //先にisOnする
         
            if (!ItemMenuDisplay)
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
                else
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
                if (!Menu_Display)
                {
                    ItemAll.GetComponent<Toggle>().isOn = ItemMenuDisplay;

                }
                GameObject[] ItemImageAndBackground = GameObject.FindGameObjectsWithTag("ItemImageAndBackground");
                Debug.Log( "I am " + GameObject.FindGameObjectsWithTag("ItemImageAndBackground").Length);
                ItemAll.GetComponent<Animator>().SetBool("show", ItemMenuDisplay);
                player_move_controller.GetComponent<Animator>().enabled = !ItemMenuDisplay;
                player_move_controller.moveMode = !ItemMenuDisplay;
            if (ItemImageAndBackground.Length != 0)
                {
                //game_manager_script.BasicSelectObject(ItemImageAndBackground[0]);
                ItemImageAndBackground[0].GetComponent<Selectable>().Select();
                Debug.Log(EventSystem.current.currentSelectedGameObject);

            }
        }
    }


}

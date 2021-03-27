using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    // Start is called before the first frame update
    void Start()
    {
        player_move_controller = GameObject.FindWithTag("Player").GetComponent<PlayerMoveController>();
        ItemAll = this.gameObject.GetComponent<GameManagerScript>().ItemAll;
        Menu = this.gameObject.GetComponent<GameManagerScript>().Menu.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(MenuDisplayKeyCode))
        {
            MenuDisplay();
        }else if (Input.GetKeyDown(ItemMenuDisplayKeyCode))
        {
            ItemMenuShow();
        }
    }

    public void MenuDisplay()
    {
        SceneName = this.gameObject.GetComponent<GameManagerScript>().SceneName;
        int ret = Array.IndexOf(UnDisplaySceneName, SceneName); //現在のシーンと表示したくないシーンがあったら
            if (ret < 0)
            {
                if (Menu_Display)
                {
                    //player_move_controller.enabled = true;

                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    Menu_Display = false;

                }
                else
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    Menu_Display = true;
                }
                if (!ItemMenuDisplay)
                {
                    Menu.GetComponent<Toggle>().isOn = Menu_Display;
                }
                Menu.GetComponent<Animator>().SetBool("display", Menu_Display);
                player_move_controller.GetComponent<Animator>().enabled = !Menu_Display;
                player_move_controller.moveMode = !Menu_Display;
                if (Menu_Display)
                {
                    GameObject g = Menu.transform.GetChild(0).gameObject;
                    BasicSelectObject(g);
                }
            }
    }

    public void ItemMenuShow() {
        SceneName = this.gameObject.GetComponent<GameManagerScript>().SceneName;

        int ret = Array.IndexOf(UnDisplaySceneName, SceneName);  //現在のシーンと表示したくないシーンがあったら
        if (ret < 0)
            {
                if (ItemMenuDisplay)
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    ItemMenuDisplay = false;
                }
                else
                {
                    player_move_controller.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    ItemMenuDisplay = true;
                }
                if (!Menu_Display)
                {
                    ItemAll.GetComponent<Toggle>().isOn = ItemMenuDisplay;

                }

                ItemAll.GetComponent<Animator>().SetBool("show", ItemMenuDisplay);
                player_move_controller.GetComponent<Animator>().enabled = !ItemMenuDisplay;
                player_move_controller.moveMode = !ItemMenuDisplay;
                if (ItemAll.transform.childCount != 0 && ItemMenuDisplay)
                {
                   BasicSelectObject(ItemAll.transform.GetChild(0).gameObject);
                }
        }
    }

    void BasicSelectObject(GameObject select_object)
    {
        Button button = select_object.GetComponent<Button>();
        Selectable selectable = select_object.GetComponent<Selectable>();
        if(select_object != null)
        {
            if (button != null)
            {
                button.Select();
            }
            else if (selectable != null)
            {
                selectable.Select();
            }
        }
    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        SceneName = this.gameObject.GetComponent<GameManagerScript>().SceneName;
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
                    Menu_Display = false;
                }
                else
                {
                    Menu_Display = true;
                }
                Menu = this.gameObject.GetComponent<GameManagerScript>().Menu.gameObject;
                Menu.GetComponent<Animator>().SetBool("display", Menu_Display);
                if (Menu_Display)
                {
                    this.gameObject.GetComponent<GameManagerScript>().Canvas.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
                }
            }
        }



        }
}

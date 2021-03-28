using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveClick : MonoBehaviour
{
    GameObject SaveObject;
    // Start is called before the first frame update
    void Start()
    {
        SaveObject = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().saveObject;
    }
    public void SaveClickEvent()
    {
        if(SaveObject.GetComponent<SaveObjectScript>() != null)
        {
            SaveObject.GetComponent<SaveObjectScript>().Save();
        }
    }

    public void HomeMoveClick()
    {
        SaveObject.GetComponent<SaveObjectScript>().Save();
        ItemDatabase item_database = GameObject.FindWithTag("ItemController").GetComponent<ItemDatabase>();
        GameManagerScript game_manager_script = GameObject.FindWithTag("GameController").GetComponent<GameManagerScript>();

        item_database.wanna_destroy_item_id = null;
        game_manager_script.wanna_destroy_enemy = null;
        SceneManager.sceneLoaded -= item_database.SceneItemLoaded;
        SceneManager.sceneLoaded -= game_manager_script.SceneLoaded;


        Destroy(GameObject.FindGameObjectWithTag("ObjectsGames"));

        SceneManager.LoadScene("GameStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

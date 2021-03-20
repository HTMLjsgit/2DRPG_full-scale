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

        SceneManager.LoadScene("GameStart");
        Destroy(GameObject.FindGameObjectWithTag("ObjectsGames"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

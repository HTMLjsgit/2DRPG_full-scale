using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameManagerScript.gameManager.Name.Clear();
        GameManagerScript.gameManager.HP.Clear();
        GameManagerScript.gameManager.Attack.Clear();
        GameManagerScript.gameManager.Defense.Clear();
        GameManagerScript.gameManager.Image.Clear();

        SceneManager.LoadScene("Map1");
    }
}

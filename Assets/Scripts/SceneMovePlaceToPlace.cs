using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMovePlaceToPlace : MonoBehaviour
{
    public string ToMoveScene;
    private bool col = false;
    public KeyCode enter;
    [Header("return_modeがtrueの")]
    bool return_mode;
    public Vector2 position;
    GameManagerScript GameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col)
        {
            if (Input.GetKeyDown(enter))
            {
                Debug.Log("ttttttttttttttttttttttttttttttttttttttttttttttttttt");
                SceneManager.sceneLoaded += SceneLoaded;

                SceneManager.LoadScene(ToMoveScene);
            }
        }
    }
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == ToMoveScene)
        {
          GameObject.FindGameObjectWithTag("Player").transform.position = position;
        }
        SceneManager.sceneLoaded -= SceneLoaded;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col = false;
        }
    }
}

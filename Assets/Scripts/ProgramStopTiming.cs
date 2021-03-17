using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgramStopTiming : MonoBehaviour
{
    public string[] wanna_scene_name;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;   
    }


    void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        for(int i = 0; i < wanna_scene_name.Length; i++)
        {
            if(wanna_scene_name[i] == scene.name)
            {
                // ここに処理をストップするプログラムを書く。
            }else if(wanna_scene_name[i] != scene.name)
            {
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

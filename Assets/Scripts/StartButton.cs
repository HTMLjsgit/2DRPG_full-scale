using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using MiniJSON;
public class StartButton : MonoBehaviour
{
    public string StartSceneName;
    public GameObject ObjectGames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneMoveStart()
    {
        SceneMove(true);
    }

    public void Continue()
    {
        SceneMove(false);
    }

    public void SceneMove(bool start)
    {

        if (start == true)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(StartSceneName);
        }
        else
        {
            var continue_load_status = PlayerPrefsObject.GetObject<Status>("Status");
            var continue_load_object_save = PlayerPrefsObject.GetObject<ObjectSave>("objectSave");
            if(continue_load_status != null && continue_load_object_save != null)
            {
                //�ۑ��f�[�^�[����������
                var continue_load_status_json = JsonUtility.ToJson(continue_load_status).ToString();
                var continue_load_object_save_json = JsonUtility.ToJson(continue_load_object_save).ToString();
                var continue_load_status_json_taking_out = JsonUtility.FromJson<Status>(continue_load_status_json);
                var continue_load_object_save_json_taking_out = JsonUtility.FromJson<ObjectSave>(continue_load_object_save_json);
                SceneManager.sceneLoaded += SceneLoaded;
                SceneManager.LoadScene(continue_load_object_save_json_taking_out.SceneName);
                //�ۑ��f�[�^�ɕۑ����Ă���V�[���̖��O�Ɉړ�����B
            }
            else
            {
                //�ۑ��f�[�^���Ȃ�������
                SceneManager.LoadScene(StartSceneName);

            }
        }

    }

    public void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        GameObject ObjectGames_prefab = Instantiate(ObjectGames);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject GameManager = GameObject.FindGameObjectWithTag("GameController");
        GameManagerScript GameManagerScript = GameManager.GetComponent<GameManagerScript>();
        PlayerStatus PlayerStatus = Player.GetComponent<PlayerStatus>();


        var continue_load_status = PlayerPrefsObject.GetObject<Status>("Status");
        var continue_load_object_save = PlayerPrefsObject.GetObject<ObjectSave>("objectSave");
        var continue_load_status_json = JsonUtility.ToJson(continue_load_status).ToString();
        var continue_load_object_save_json = JsonUtility.ToJson(continue_load_object_save).ToString();

       //json�ɂ��ăf�[�^���o���ł���悤�ɂ���
        var continue_load_status_json_taking_out = JsonUtility.FromJson<Status>(continue_load_status_json);
        var continue_load_object_save_json_taking_out = JsonUtility.FromJson<ObjectSave>(continue_load_object_save_json);

        //�ۑ������f�[�^��GameManager�ɑ��
        GameManagerScript.SceneHistroy = continue_load_object_save_json_taking_out.SceneHistroy;
        GameManagerScript.SceneName = continue_load_object_save_json_taking_out.SceneName;
        GameManagerScript.wanna_destroy_enemy = continue_load_object_save_json_taking_out.WannnaDestroyEnemy;
        GameManagerScript.SceneNameBefore = continue_load_object_save_json_taking_out.SceneNameBefore;

        //�ۑ������f�[�^���v���C���[�ɑ��
        PlayerStatus.HP = continue_load_status_json_taking_out.HP;
        PlayerStatus.Defense = continue_load_status_json_taking_out.Defense;
        PlayerStatus.Attack = continue_load_status_json_taking_out.Attack;
        PlayerStatus.position = continue_load_status_json_taking_out.position;
        PlayerStatus.gameObject.transform.position = continue_load_status_json_taking_out.position;
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}

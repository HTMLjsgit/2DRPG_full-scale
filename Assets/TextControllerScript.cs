using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextControllerScript : MonoBehaviour
{
    public KeyCode advance_message_key;
    public Text message_text;
    PlayerStatus player_status;

    public GameObject MessageWindow;

    private string currentText = string.Empty;
    public float timeElapsed = 1;
    private int currentLine = 0;
    private int lastUpdateCharacter = -1;
    private float timeUntilDisplay = 0;
    public List<string> messages_texts;
    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;
    public bool TextMode;

    public string ItemName;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        player_status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    // Update is called once per frame


    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    public void TextWrite(List<string> messages, string itemName = null, GameObject enemy = null)
    {
        MessageWindow.GetComponent<Toggle>().isOn = true;
        messages_texts = messages;
        ItemName = itemName;
        Debug.Log(ItemName);
        TextMode = true;
        SetNextLine();
    }

    void Update()
    {
        if (TextMode)
        {
            if (IsCompleteDisplayText)
            {
                if (Input.GetKeyDown(advance_message_key))
                {
                    Debug.Log("---------------------------");
                    SetNextLine();
                }



            }
            else
            {
                if (Input.GetKeyDown(advance_message_key))
                {
                    timeUntilDisplay = 0;
                }
            }
            if(currentText != null)
            {
                int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
                if (displayCharacterCount != lastUpdateCharacter)
                {
                    message_text.text = currentText.Substring(0, displayCharacterCount);
                    lastUpdateCharacter = displayCharacterCount;
                }
            }

        }

    }

    public void SetNextLine()
    {

        Debug.Log("currentLine" + currentLine.ToString());
        Debug.Log("messages_texts" + messages_texts.Count.ToString());

        if (currentLine == messages_texts.Count)
            {
                Debug.Log("Finish----------------------------------");
                timeUntilDisplay = 0;
                lastUpdateCharacter = -1;
                message_text.text = "";
                currentLine = 0;
                messages_texts = null;
                MessageWindow.GetComponent<Toggle>().isOn = false;

                TextMode = false;
                currentText = null;
                ItemName = null; 
                return;
            }
        currentText = MessageChangeChar(messages_texts[currentLine]);

        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        currentLine++;
        lastUpdateCharacter = -1;
    }

    public string MessageChangeChar(string message)
    {
        if(enemy != null)
        {
            EnemyStatus enemy_status = enemy.GetComponent<EnemyStatus>();
            message = message.Replace("#{enemy_hp}", enemy_status.HP.ToString());
            message.Replace("#{enemy_attack}", enemy_status.Attack.ToString());
        }


        Debug.Log(ItemName);
        message = message.Replace("#{item_name}", ItemName);
        message = message.Replace("#{player_hp}", player_status.HP.ToString());
        message = message.Replace("#{player_attack}", player_status.Attack.ToString());
        message = message.Replace("#{player_defense}", player_status.Defense.ToString());

        return message;
    }

}

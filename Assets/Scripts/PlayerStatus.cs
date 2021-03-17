using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus player_status;
    public float HP;
    public float Defense;
    public float Attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        player_status = this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attacked(float Attacked)
    {

        //float damage = Mathf.Max(Attacked - defense);
        if (HP > 0)
        {
            HP -= Attacked + Defense;
            if (HP < 0)
            {
                Debug.Log("GameOver");
               // Destroy(this.gameObject);

            }
        }
        else
        {
            Debug.Log("GameOver");
            //Destroy(this.gameObject);
        }

    }
}

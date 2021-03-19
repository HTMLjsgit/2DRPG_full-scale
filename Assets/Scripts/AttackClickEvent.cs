using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackClickEvent : MonoBehaviour
{
    FightEnemyCreate fight_enemy_create;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().Select();
        fight_enemy_create = FightEnemyCreate.fight_enemy_create;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
            fight_enemy_create.gameObject.transform.GetChild(0).GetComponent<Selectable>().Select();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGearImageSetScript : MonoBehaviour
{
    GameObject ItemController;
    public Sprite LegSkin;
    public Sprite HeadSkin;
    public Sprite BodySkin;
    public Sprite ArmsSkinLeft; //ひだり　右の順番

    public Sprite ArmsSkinRight; //ひだり　右の順番
    // Start is called before the first frame update
    void Start()
    {
        ItemController = GameObject.FindWithTag("ItemController");
        GearManagerScript gear_manager_script = ItemController.GetComponent<GearManagerScript>();
        //もし画像がセットされていなかった場合　GearmanagerScriptにセットしておいた画像たち(初期画像)を自動セットする
        if (LegSkin == null)
        {
            LegSkin = gear_manager_script.InitLeg;
        }
        if (HeadSkin == null)
        {
            HeadSkin = gear_manager_script.InitHead;

        }
        if (BodySkin == null)
        {
            BodySkin = gear_manager_script.InitBody;

        }
        if(ArmsSkinLeft == null)
        {
            ArmsSkinLeft = gear_manager_script.InitArmLeft;
        }
        if(ArmsSkinRight == null)
        {
            ArmsSkinRight = gear_manager_script.InitArmRight;
        }

        if (ArmsSkinLeft == null || ArmsSkinRight == null || BodySkin == null || LegSkin == null || HeadSkin == null)
        {
            Debug.LogWarning("スキン画像がセットされていなかったため、デフォルトの画像にしました。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

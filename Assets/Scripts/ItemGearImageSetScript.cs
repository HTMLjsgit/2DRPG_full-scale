using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGearImageSetScript : MonoBehaviour
{
    GameObject ItemController;
    public Sprite LegSkin;
    public Sprite HeadSkin;
    public Sprite BodySkin;
    public Sprite ArmsSkinLeft; //�Ђ���@�E�̏���

    public Sprite ArmsSkinRight; //�Ђ���@�E�̏���
    // Start is called before the first frame update
    void Start()
    {
        ItemController = GameObject.FindWithTag("ItemController");
        GearManagerScript gear_manager_script = ItemController.GetComponent<GearManagerScript>();
        //�����摜���Z�b�g����Ă��Ȃ������ꍇ�@GearmanagerScript�ɃZ�b�g���Ă������摜����(�����摜)�������Z�b�g����
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
            Debug.LogWarning("�X�L���摜���Z�b�g����Ă��Ȃ��������߁A�f�t�H���g�̉摜�ɂ��܂����B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    [HideInInspector]
    public List<Unit> attackInfos = new List<Unit>();

    [SerializeField]
    public static List<Unit_data> unit_list { get; private set; }
    private void Awake()
    {
        //���j�b�g�̃f�[�^�͂��ׂĂ����Ƀ��X�g��������B
        Unit_data[] dataFiles = Resources.LoadAll<Unit_data>("Unit_data");
        //Unit_data�����[�h
        unit_list = new List<Unit_data>(dataFiles);
    }

    public void AddAttack(Unit us)
    {
        attackInfos.Add(us);
    }
    /// <summary>
    /// ����͂Ȃ񂼂�F �U���Ɋւ���Փˉ������
    /// �������R�F      �����ɍU�������������ꍇ�̃G���[���p
    /// ����Ă��邱�ƁF�U���͈͂ɓ������҂���U����\�񂵂čU�����Ԃ�������U��������B
    /// </summary>
    public void FixedUpdate()
    {
        for(int i = 0; i < attackInfos.Count; i++)
        {
            if (attackInfos[i] != null)
            {
                attackInfos[i].GetComponent<Unit_model>().now_attack_delay += Time.deltaTime;

                if (attackInfos[i].GetComponent<Unit_model>().now_attack_delay > attackInfos[i].GetComponent<Unit_model>().attack_delay
                    && attackInfos[i].GetComponent<Unit>().isCooldown == false)
                {
                    //�U���̏���
                    StartCoroutine(attackInfos[i].GetComponent<Unit>().Battle(attackInfos[i].GetComponent<Unit_model>().attack_speed));   //�U���̌Ăяo��

                    //���Z�b�g
                    attackInfos[i].GetComponent<Unit_model>().now_attack_delay = 0; //�U���ҋ@���Ԃ��O��
                    //���X�g����폜
                    attackInfos.Remove(attackInfos[i]);
                }
            }
            else if(attackInfos[i]�@== null)
            {
                attackInfos.Remove(attackInfos[i]); //null��������j�������
            }
        }
    }

    /// <summary>
    /// �_���[�W�v�Z
    /// </summary>
    /// <param name="attack_power">�U�����鑤�̍U����</param>
    /// <param name="defense_power">�U�����󂯂鑤�̖h���</param>
    /// <returns></returns>
    public int Attack_calculation(int attack_power,int defense_power)
    {
        Debug.Log(attack_power - defense_power);
        if (attack_power > defense_power)
        {
            //Debug.Log("�ȉ��̃_���[�W����������");
            //Debug.Log(attack_power - defense_power);
            return attack_power - defense_power;
        }
        else //���炩�̃G���[���N�����ꍇ�͂�����ց`
        {
            Debug.Log("�����Ńf�o�b�O���O�������̂͂���������i�_���[�W�v�Z�j");
            return 0;
        }
    }

    #region ���X�g���������j�b�g�𐶐�����Ƃ��͂��������Əo�����

    /*
    ���Ăяo���Ƃ��͂�������
    InstantiateEnemy();

    ���֐��̒��g�͂��ꂾ��
    public static GameObject Instantiate_unit(Unit_data unit_data)
    {
        GameObject enemy = Instantiate(unit_data.Unit_object, new Vector3(0,0,0), Quaternion.identity);
        return enemy;
    }
    */
    #endregion
}

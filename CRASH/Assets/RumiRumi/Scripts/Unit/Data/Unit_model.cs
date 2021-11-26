using UnityEngine;

public class Unit_model : Unit_base
{
    [SerializeField,Header("�̗�")]
    private int hp;              //���j�b�g�̗̑�
    [Header("�U����")]
    public int attack_power;    //���j�b�g�̍U����
    [Header("�U�����x")]
    public int attack_speed;    //���j�b�g�̍U�����x
    [Header("�h���")]
    public int defense_power;   //���j�b�g�̖h���
    [Header("�ړ����x")]
    public int move_speed;  //���j�b�g�̈ړ����x

    /// <summary>
    /// �̗͂��O�̎��ɁA���I�u�W�F�N�g���f�X�g���C���鏈��
    /// </summary>
    [HideInInspector]
    public int unit_hp  //HP���ϓ������ۂɑ̗͂��O�ȉ��Ȃ�I�u�W�F�N�g���폜
    { 
      get { return hp; }
      set {
            hp = value;

            if (hp <= 0)
                Destroy(gameObject);
          } 
    }
}

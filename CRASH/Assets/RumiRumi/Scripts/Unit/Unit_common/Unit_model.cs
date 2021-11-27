using UnityEngine;

public class Unit_model : Unit_base
{
    [Header("�U���Ώ�")]
    public GameObject target = null;  //�U������^�[�Q�b�g���i�[

    [Header("�̗�")]
    public int hp;              //���j�b�g�̗̑�
    [Header("�U����")]
    public int attack_power;    //���j�b�g�̍U����
    [Header("�U�����x(�b)")]
    public int attack_speed;    //���j�b�g�̍U�����x
    [Header("�h���")]
    public int defense_power;   //���j�b�g�̖h���
    [Header("�ړ����x")]
    public int move_speed;  //���j�b�g�̈ړ����x

    private void OnTriggerEnter2D(Collider2D co)
    {
        if (gameObject.CompareTag("Unit1"))
        {
            if (co.CompareTag("Unit2") || co.CompareTag("Castle2"))
                target = co.gameObject;     //�U���Ώۂ�I��
        }
        if (gameObject.CompareTag("Unit2"))
        {
            if (co.CompareTag("Unit1") || co.CompareTag("Castle1"))
                target = co.gameObject;     //�U���Ώۂ�I��
        }
    }

//------------------------------------------------------------------------

    /// <summary>
    /// �̗͂��O�ȉ��ɂȂ������ɁA���I�u�W�F�N�g���f�X�g���C���鏈��
    /// </summary>
    [HideInInspector]
    public int Unit_hp  //HP���ϓ������ۂɑ̗͂��O�ȉ��Ȃ�I�u�W�F�N�g���폜
    { 
      get { return hp; }
      set {
            hp = value;

            if (hp <= 0)
                Destroy(gameObject);
          } 
    }
}

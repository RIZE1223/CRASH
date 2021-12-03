using System.Collections;
using UnityEngine;

public enum Unit_move    //���j�b�g�̍s��
{
    Moving_method,   //�ړ�
    Battle, //�U��  
}

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Unit_move unit_move;  //���j�b�g�������̍s�������Ă��邩

    protected Unit_model unit_model;  //model�ɂ����Ă�����̂��g����悤�ɂ����
    protected Unit_manager unit_manager;  // //manager�ɂ���_���[�W�v�Z���g����悤�ɂ����

    [Header("�U���Ώ�")]
    public GameObject target = null;  //�U������^�[�Q�b�g���i�[

    [HideInInspector]
    public bool isCool_down;    //�N�[���_�E�����Ă邩�݂�YO!
    private bool isAttack_reserve;  //�U���\����s���Ă��邩���݂�YO!

//------------------------------------------------------------------------------

    private void Awake()
    {
        unit_model = gameObject.GetComponent<Unit_model>();//���g�ɃA�^�b�`����Ă���Unit_model��T��YO!
        unit_manager = GameObject.FindObjectOfType<Unit_manager>(); //hierarchy�ɂ���Unit_manager��T��YO�I
    }

    private void Start()
    {
        isCool_down = false; //�N�[���_�E������Attack_speed�̐��l���ҋ@���Ă��܂��B
        isAttack_reserve = false;
    }


//------------------------------------------------------------------------------

    private void FixedUpdate()
    {
        //�̗͂��O�ȉ��Ȃ�I�u�W�F�N�g���폜
        if (unit_model.hp <= 0)
        {
            //RiP
            Destroy(this.gameObject);
        }

        else if (unit_model.hp > 0)
        {
            switch (unit_move)
            {
                case Unit_move.Moving_method:
                    Moving_method();
                    break;
                case Unit_move.Battle:
                    if (!isAttack_reserve)//�A���ŗ\�񂪂���Ȃ��悤�ɂ��Ă���
                    {
                        unit_manager.AddAttack(GetComponent<Unit>());
                        isAttack_reserve = true;    //�U���\�񂵂܂������
                    }
                    break;
                default:
                    Debug.Log("�����Ɠ��삵�ĂȂ����(�L�����̍s��)");
                    break;
            }
        }
    }

    /// <summary>
    /// �U��
    /// </summary>
    /// <param name="cool_time">Attack_speed(�U���ォ�玟�̍U�����Ă΂��܂ŁB)</param>
    /// <returns></returns>
    public IEnumerator Battle(float cool_time)
    {
        if (isCool_down != true) //�N�[���^�C�����I�����Ă��邱�Ƃ��m�F
        {
            if (target != null) //�U���Ώۂ����܂��Ă��邩���m�F
            {
                Attack();
            }
            isCool_down = true;  //�U����̃N�[���^�C�����J�n���w��
        }
        
        if (target == null)  //�U���Ώۂ�|�������m�F
        {
            unit_move = Unit_move.Moving_method;   //�ړ��J�n
        }

        yield return new WaitForSeconds(cool_time); //�N�[���^�C���v���J�n

        //���Z�b�g
        isCool_down = false; //�U����̑ҋ@�J�n
        isAttack_reserve = false;   //�U�����������\�������������I
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    protected virtual void Moving_method()
    {
        Move();
        if (target != null)
        {
            unit_move = Unit_move.Battle;   //�U���J�n
        }
    }

    protected virtual void Move()
    {
        //�e���j�b�g���Ƃɏ��������Ă�
    }
    protected virtual void Attack()
    {
        //�e���j�b�g���Ƃɏ��������Ă�
    }

//------------------------------------------------------------------------------

    protected virtual void OnCollisionEnter2D(Collision2D co)
    {
        if (gameObject.CompareTag("Unit1"))
        {
            if (co.collider.tag == ("Unit2") || co.collider.tag == ("Castle2"))
                target = co.gameObject;//�U���Ώۂ�I��
        }
        else if (gameObject.CompareTag("Unit2"))
        {
            if (co.collider.tag == ("Unit1") || co.collider.tag == ("Castle1"))
                target = co.gameObject;     //�U���Ώۂ�I��
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D co)
    {
        if(co.gameObject == target.gameObject)
        {
            target = null;  //�U���͈͊O�ɏo���ꍇ��target����O����
        }
    }
}

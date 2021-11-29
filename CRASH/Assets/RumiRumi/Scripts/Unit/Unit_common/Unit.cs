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
    public bool isCooldown;    //�N�[���_�E�����Ă邩�݂�YO!

    protected int List_number;    //manager�ŊǗ�����Ă��鎩�g�̔ԍ����L������

//------------------------------------------------------------------------------

    private void Awake()
    {
        unit_model = gameObject.GetComponent<Unit_model>();//���g�ɃA�^�b�`����Ă���Unit_model��T��YO!
        unit_manager = GameObject.FindObjectOfType<Unit_manager>(); //hierarchy�ɂ���Unit_manager��T��YO�I
    }

    private void Start()
    {
        isCooldown = false;
        List_number = 0;
    }


//------------------------------------------------------------------------------

    private void FixedUpdate()
    {

        //�̗͂��O�ȉ��Ȃ�I�u�W�F�N�g���폜
        if (unit_model.hp <= 0)
        {
            //�O�b�o�[�C
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
                    unit_manager.AddAttack(GetComponent<Unit>());
                    List_number = unit_manager.attackInfos.Count;
                    break;
                default:
                    Debug.Log("�����Ɠ��삵�ĂȂ����(�L�����̍s��)");
                    break;
            }
        }
    }

    public IEnumerator Battle(float cool_time)
    {
        Attack();
        if (target == null)  //����ł��邩�`�F�b�N
        {
            unit_move = Unit_move.Moving_method;   //�ړ��J�n
        }

        yield return new WaitForSeconds(cool_time);
        isCooldown = false;
    }

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

    protected virtual void OnTriggerEnter2D(Collider2D co)
    {
        if (gameObject.CompareTag("Unit1"))
        {
            if (co.CompareTag("Unit2") || co.CompareTag("Castle2"))
                target = co.gameObject;//�U���Ώۂ�I��
        }
        if (gameObject.CompareTag("Unit2"))
        {
            if (co.CompareTag("Unit1") || co.CompareTag("Castle1"))
                target = co.gameObject;     //�U���Ώۂ�I��
        }
    }
}

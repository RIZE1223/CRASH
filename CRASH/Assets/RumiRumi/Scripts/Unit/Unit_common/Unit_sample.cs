using UnityEngine;

public class Unit_sample : MonoBehaviour
{
    public Unit_model unit_model;   //model�ɂ����Ă�����̂��g����悤�ɂ����
    public Unit_manager unit_manager;   //manager�ɂ���_���[�W�v�Z���g����悤�ɂ����
    private float time_elapsed; //�o�߂������Ԃ��i�[

    public enum Unit_move    //���j�b�g�̍s��
    {
        move,   //�ړ�
        attack, //�U��  
    }
    [HideInInspector]
    public Unit_move unit_move;  //���j�b�g�������̍s�������Ă��邩

    private void FixedUpdate()
    {
        switch (unit_move)
        {
            case Unit_move.move:    //move���I�΂�Ă����ꍇ�����̏����������
                Move();
                break;
            case Unit_move.attack:  //attack���I�΂�Ă����ꍇ�����̏����������
                Attack();
                break;
            default:    //���̑��̉��炩�̃o�O���������ꍇ�͂����̏����������
                Debug.Log("�����Ɠ��삵�ĂȂ����(�L�����̍s��)");
                break;
        }
    }

    private void Move()
    {
        //���g�����Ă�
    }
    private void Attack()
    {
        //���g�����Ă�
    }
}

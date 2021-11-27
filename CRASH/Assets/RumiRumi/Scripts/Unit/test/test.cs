using UnityEngine;

public class test : MonoBehaviour
{
    public Unit_model unit_model;
    public Unit_manager unit_manager;
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
            case Unit_move.move:
                Move();
                break;
            case Unit_move.attack:
                Attack();
                break;
            default:
                Debug.Log("�����Ɠ��삵�ĂȂ����(�L�����̍s��)");
                break;
        }
    }

    private void Move()
    {
        transform.Translate(unit_model.move_speed, 0f, 0f);
        if(unit_model.target != null)
        {
            unit_move = Unit_move.attack;   //�U���J�n
        }
    }

    private void Attack()
    {
        time_elapsed += Time.deltaTime;
        if (unit_model.attack_speed < time_elapsed)
        {
            //�_���[�W���v�Z�@�@HP = �����̍U���� - �G�̖h���
            unit_model.target.GetComponent<Unit_model>().hp -= unit_manager.Attack_calculation
                (unit_model.attack_power, unit_model.target.GetComponent<Unit_model>().defense_power);

            if (unit_model.target == null)
            {
                unit_move = Unit_move.move;   //�ړ��J�n
            }
            time_elapsed = 0; //�J�E���g��������
        }

    }
}

public class Test_unit : Unit
{
    protected override void Move()
    {
        //�w�c���̈ړ�
        if (CompareTag("Unit1"))
        {
            transform.Translate(unit_model.move_speed, 0f, 0f);
        }
        else if (CompareTag("Unit2"))
        {
            transform.Translate(-unit_model.move_speed, 0f, 0f);
        }


    }

    protected override void Attack()
    {
        if (isCooldown != true)
        {
            isCooldown = true;

            if (target != null)
            {
                //�_���[�W���v�Z�@�@HP = �����̍U���� - �G�̖h���
                target.GetComponent<Unit_model>().hp -= unit_manager.Attack_calculation
                    (unit_model.attack_power,target.GetComponent<Unit_model>().defense_power);
            }
        }
    }
}

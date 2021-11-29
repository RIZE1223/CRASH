public class Test_unit : Unit
{
    protected override void Move()
    {
        //陣営事の移動
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
                //ダメージを計算　　HP = 自分の攻撃力 - 敵の防御力
                target.GetComponent<Unit_model>().hp -= unit_manager.Attack_calculation
                    (unit_model.attack_power,target.GetComponent<Unit_model>().defense_power);
            }
        }
    }
}

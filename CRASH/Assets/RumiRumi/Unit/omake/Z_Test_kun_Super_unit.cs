public class Z_Test_kun_Super_unit : Unit
{
    protected override void Move()
    {
        //w‰c–‚ÌˆÚ“®
        if (gameObject.CompareTag("Unit1"))
        {
            transform.Translate(unit_model.move_speed, 0f, 0f);
        }
        else if (gameObject.CompareTag("Unit2"))
        {
            transform.Translate(unit_model.move_speed, 0f, 0f);
        }
    }

    protected override void Attack()
    {
        //ƒ_ƒ[ƒW‚ğŒvZ@@HP = ©•ª‚ÌUŒ‚—Í - “G‚Ì–hŒä—Í
        target.GetComponent<Unit_model>().hp -= unit_manager.Attack_calculation
            (unit_model.attack_power, target.GetComponent<Unit_model>().defense_power);
    }
}

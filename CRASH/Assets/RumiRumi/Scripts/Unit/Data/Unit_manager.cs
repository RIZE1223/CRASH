using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    /// <summary>
    /// ƒ_ƒ[ƒWŒvZ
    /// </summary>
    /// <param name="attack_power">UŒ‚‚·‚é‘¤‚ÌUŒ‚—Í</param>
    /// <param name="defense_power">UŒ‚‚ğó‚¯‚é‘¤‚Ì–hŒä—Í</param>
    /// <returns></returns>
    public int Attack_calculation(int attack_power,int defense_power)
    {
        Debug.Log(attack_power - defense_power);
        if (attack_power > defense_power)
        {
            Debug.Log("ˆÈ‰º‚Ìƒ_ƒ[ƒW‚ª“ü‚Á‚½‚æ");
            Debug.Log(attack_power - defense_power);
            return attack_power - defense_power;
        }
        else
        {
            return 0;
        }
    }

}

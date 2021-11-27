using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    /// <summary>
    /// ダメージ計算
    /// </summary>
    /// <param name="attack_power">攻撃する側の攻撃力</param>
    /// <param name="defense_power">攻撃を受ける側の防御力</param>
    /// <returns></returns>
    public int Attack_calculation(int attack_power,int defense_power)
    {
        Debug.Log(attack_power - defense_power);
        if (attack_power > defense_power)
        {
            Debug.Log("以下のダメージが入ったよ");
            Debug.Log(attack_power - defense_power);
            return attack_power - defense_power;
        }
        else
        {
            return 0;
        }
    }

}

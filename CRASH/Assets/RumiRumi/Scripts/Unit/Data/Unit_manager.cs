using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    /// <summary>
    /// �_���[�W�v�Z
    /// </summary>
    /// <param name="attack_power">�U�����鑤�̍U����</param>
    /// <param name="defense_power">�U�����󂯂鑤�̖h���</param>
    /// <returns></returns>
    public int Attack_calculation(int attack_power,int defense_power)
    {
        Debug.Log(attack_power - defense_power);
        if (attack_power > defense_power)
        {
            Debug.Log("�ȉ��̃_���[�W����������");
            Debug.Log(attack_power - defense_power);
            return attack_power - defense_power;
        }
        else
        {
            return 0;
        }
    }

}

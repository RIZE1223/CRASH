using UnityEngine;

public class test : MonoBehaviour
{
    public Unit_model unit_model;
    public Unit_manager unit_manager;
    private float time_elapsed; //経過した時間を格納

    public enum Unit_move    //ユニットの行動
    {
        move,   //移動
        attack, //攻撃  
    }
    [HideInInspector]
    public Unit_move unit_move;  //ユニットが今何の行動をしているか

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
                Debug.Log("ちゃんと動作してないよん(キャラの行動)");
                break;
        }
    }

    private void Move()
    {
        transform.Translate(unit_model.move_speed, 0f, 0f);
        if(unit_model.target != null)
        {
            unit_move = Unit_move.attack;   //攻撃開始
        }
    }

    private void Attack()
    {
        time_elapsed += Time.deltaTime;
        if (unit_model.attack_speed < time_elapsed)
        {
            //ダメージを計算　　HP = 自分の攻撃力 - 敵の防御力
            unit_model.target.GetComponent<Unit_model>().hp -= unit_manager.Attack_calculation
                (unit_model.attack_power, unit_model.target.GetComponent<Unit_model>().defense_power);

            if (unit_model.target == null)
            {
                unit_move = Unit_move.move;   //移動開始
            }
            time_elapsed = 0; //カウントを初期化
        }

    }
}

using UnityEngine;

public class Unit_sample : MonoBehaviour
{
    public Unit_model unit_model;   //modelにかいてあるものを使えるようにするよ
    public Unit_manager unit_manager;   //managerにあるダメージ計算を使えるようにするよ
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
            case Unit_move.move:    //moveが選ばれていた場合ここの処理をするよ
                Move();
                break;
            case Unit_move.attack:  //attackが選ばれていた場合ここの処理をするよ
                Attack();
                break;
            default:    //その他の何らかのバグがあった場合はここの処理をするよ
                Debug.Log("ちゃんと動作してないよん(キャラの行動)");
                break;
        }
    }

    private void Move()
    {
        //中身書いてね
    }
    private void Attack()
    {
        //中身書いてね
    }
}

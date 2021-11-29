using System.Collections;
using UnityEngine;

public enum Unit_move    //ユニットの行動
{
    Moving_method,   //移動
    Battle, //攻撃  
}

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Unit_move unit_move;  //ユニットが今何の行動をしているか

    protected Unit_model unit_model;  //modelにかいてあるものを使えるようにするよ
    protected Unit_manager unit_manager;  // //managerにあるダメージ計算を使えるようにするよ

    [Header("攻撃対象")]
    public GameObject target = null;  //攻撃するターゲットを格納

    [HideInInspector]
    public bool isCooldown;    //クールダウンしてるかみるYO!

    protected int List_number;    //managerで管理されている自身の番号を記憶する

//------------------------------------------------------------------------------

    private void Awake()
    {
        unit_model = gameObject.GetComponent<Unit_model>();//自身にアタッチされているUnit_modelを探すYO!
        unit_manager = GameObject.FindObjectOfType<Unit_manager>(); //hierarchyにあるUnit_managerを探すYO！
    }

    private void Start()
    {
        isCooldown = false;
        List_number = 0;
    }


//------------------------------------------------------------------------------

    private void FixedUpdate()
    {

        //体力が０以下ならオブジェクトを削除
        if (unit_model.hp <= 0)
        {
            //グッバーイ
            Destroy(this.gameObject);
        }
        else if (unit_model.hp > 0)
        {
            switch (unit_move)
            {
                case Unit_move.Moving_method:
                    Moving_method();
                    break;
                case Unit_move.Battle:
                    unit_manager.AddAttack(GetComponent<Unit>());
                    List_number = unit_manager.attackInfos.Count;
                    break;
                default:
                    Debug.Log("ちゃんと動作してないよん(キャラの行動)");
                    break;
            }
        }
    }

    public IEnumerator Battle(float cool_time)
    {
        Attack();
        if (target == null)  //死んでいるかチェック
        {
            unit_move = Unit_move.Moving_method;   //移動開始
        }

        yield return new WaitForSeconds(cool_time);
        isCooldown = false;
    }

    protected virtual void Moving_method()
    {
        Move();
        if (target != null)
        {
            unit_move = Unit_move.Battle;   //攻撃開始
        }
    }

    protected virtual void Move()
    {
        //各ユニットごとに書き換えてね
    }
    protected virtual void Attack()
    {
        //各ユニットごとに書き換えてね
    }

//------------------------------------------------------------------------------

    protected virtual void OnTriggerEnter2D(Collider2D co)
    {
        if (gameObject.CompareTag("Unit1"))
        {
            if (co.CompareTag("Unit2") || co.CompareTag("Castle2"))
                target = co.gameObject;//攻撃対象を選択
        }
        if (gameObject.CompareTag("Unit2"))
        {
            if (co.CompareTag("Unit1") || co.CompareTag("Castle1"))
                target = co.gameObject;     //攻撃対象を選択
        }
    }
}

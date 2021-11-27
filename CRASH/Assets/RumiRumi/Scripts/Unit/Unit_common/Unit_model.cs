using UnityEngine;

public class Unit_model : Unit_base
{
    [Header("攻撃対象")]
    public GameObject target = null;  //攻撃するターゲットを格納

    [Header("体力")]
    public int hp;              //ユニットの体力
    [Header("攻撃力")]
    public int attack_power;    //ユニットの攻撃力
    [Header("攻撃速度(秒)")]
    public int attack_speed;    //ユニットの攻撃速度
    [Header("防御力")]
    public int defense_power;   //ユニットの防御力
    [Header("移動速度")]
    public int move_speed;  //ユニットの移動速度

    private void OnTriggerEnter2D(Collider2D co)
    {
        if (gameObject.CompareTag("Unit1"))
        {
            if (co.CompareTag("Unit2") || co.CompareTag("Castle2"))
                target = co.gameObject;     //攻撃対象を選択
        }
        if (gameObject.CompareTag("Unit2"))
        {
            if (co.CompareTag("Unit1") || co.CompareTag("Castle1"))
                target = co.gameObject;     //攻撃対象を選択
        }
    }

//------------------------------------------------------------------------

    /// <summary>
    /// 体力が０以下になった時に、自オブジェクトをデストロイする処理
    /// </summary>
    [HideInInspector]
    public int Unit_hp  //HPが変動した際に体力が０以下ならオブジェクトを削除
    { 
      get { return hp; }
      set {
            hp = value;

            if (hp <= 0)
                Destroy(gameObject);
          } 
    }
}

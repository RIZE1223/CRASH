using UnityEngine;

public class Unit_model : Unit_base
{
    [SerializeField,Header("体力")]
    private int hp;              //ユニットの体力
    [Header("攻撃力")]
    public int attack_power;    //ユニットの攻撃力
    [Header("攻撃速度")]
    public int attack_speed;    //ユニットの攻撃速度
    [Header("防御力")]
    public int defense_power;   //ユニットの防御力
    [Header("移動速度")]
    public int move_speed;  //ユニットの移動速度

    /// <summary>
    /// 体力が０の時に、自オブジェクトをデストロイする処理
    /// </summary>
    [HideInInspector]
    public int unit_hp  //HPが変動した際に体力が０以下ならオブジェクトを削除
    { 
      get { return hp; }
      set {
            hp = value;

            if (hp <= 0)
                Destroy(gameObject);
          } 
    }
}

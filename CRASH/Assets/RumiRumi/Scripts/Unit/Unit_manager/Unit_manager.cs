using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    [HideInInspector]
    public List<Unit> attackInfos = new List<Unit>();

    [SerializeField]
    public static List<Unit_data> unit_list { get; private set; }


    private void Awake()
    {
        //ユニットのデータはすべてここにリスト化されるよ。
        Unit_data[] dataFiles = Resources.LoadAll<Unit_data>("Unit_data");
        //Unit_dataをロード
        unit_list = new List<Unit_data>(dataFiles);
    }
        

    public void AddAttack(Unit us)
    {
        attackInfos.Add(us);
    }

    /// <summary>
    /// これはなんぞや： 攻撃に関する衝突回避処理
    /// 実装理由：      同時に攻撃が発生した場合のエラー回避用
    /// やっていること：攻撃範囲に入った者から攻撃を予約して攻撃時間が来たら攻撃をする。
    /// </summary>
    public void FixedUpdate()
    {
        float elapsed_time = Time.fixedDeltaTime;    //経過時間の取得

        for (int i = 0; i < attackInfos.Count; i++)
        {
            Debug.Log(i);
            if (attackInfos[i] != null && attackInfos[i].GetComponent<Unit>().isCool_down == false)
            {
                attackInfos[i].GetComponent<Unit_model>().now_attack_delay += elapsed_time;

                //攻撃ディレイが規定時間に達した場合読み込まれるよん / 攻撃のアニメーションが使われている際にここの計算を使用されるよ。
                if (attackInfos[i].GetComponent<Unit_model>().now_attack_delay > attackInfos[i].GetComponent<Unit_model>().attack_delay)
                {
                    //攻撃の処理
                    StartCoroutine(attackInfos[i].GetComponent<Unit>().Battle(attackInfos[i].GetComponent<Unit_model>().attack_cool_time));   //攻撃の呼び出し

                    //リセット
                    attackInfos[i].GetComponent<Unit_model>().now_attack_delay = 0; //攻撃待機時間を０にするよ
                    //リストから削除
                    attackInfos.Remove(attackInfos[i]);
                }
            }
            else if(attackInfos[i]　== null) //攻撃予約をしたユニットが死んでいるか確認
            {
                attackInfos.Remove(attackInfos[i]); //nullだったら破棄するよ
            }
        }
    }

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
            //Debug.Log("以下のダメージが入ったよ");
            //Debug.Log(attack_power - defense_power);
            return attack_power - defense_power;
        }
        else //何らかのエラーが起きた場合はこちらへ～
        {
            Debug.Log("ここでデバッグログが流れるのはおかしいよ（ダメージ計算）");
            return 0;
        }
    }

    #region リスト化したユニットを生成するときはこう書くと出せるよ

    /*
    ↓呼び出すときはこう書く
    Instantiate_unit(unit_list[必要なユニットの格納されているListの番号]);

    ↓関数の中身はこれだよ
    public static GameObject Instantiate_unit(Unit_data unit_data)
    {
        GameObject unit = Instantiate(unit_data.Unit_object, new Vector3(生成場所の指定), Quaternion.identity);
        return unit;
    }

    ↓タグのつけ方は多分これ
    unit_data.Unit_object.tag = ("タグ名");
    */

    #endregion
}

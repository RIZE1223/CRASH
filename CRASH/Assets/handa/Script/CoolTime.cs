using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    [Header("クールタイム用image")]
    public Image Image;

    [Header("クールタイム時間(秒)")]
    public float coolTime;

    [Header("プレイヤー判定(fales = 1, true = 2)")]
    public bool wayPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        Image.enabled = false;//非表示
    }

    // Update is called once per frame
    void Update()
    {
        //召喚可能エリアで召喚出来たら
        if(!wayPlayer && gameObject.CompareTag("SummonZone_p1")
            || wayPlayer && gameObject.CompareTag("SummonZone_p2")
                || gameObject.CompareTag("StrategyStage"))
        {
            OnCoolCard();
        }

        //購入できない場合(所持金 < 必要金額)
        //if(GeneralManager.instance.unitManager.UnitMoney <= Unit_manager.unit_list[].Price)
        //{
        //    NotBuyCard();
        //}
    }

    public void OnCoolCard()
    {
        //表示して円ゲージみたいに減少
        Image.enabled = true;
        Image.fillAmount -= 1.0f / coolTime * Time.deltaTime;

        //一周したらfillAmountを１に戻して非表示
        if(Image.fillAmount <= 0)
        {
            Image.fillAmount = 1;
            Image.enabled = false;
        }
    }

    public void NotBuyCard()
    {
        //表示
        Image.enabled = true;

        //所持金が上回ったら非表示
        //if(GeneralManager.instance.unitManager.UnitMoney >= Unit_manager.unit_list[].Price)
        //{
        //    Image.enabled = false;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoolTime : MonoBehaviour
{
    [Header("image")]
    [SerializeField]
    public Image image; //灰色の透明image的なのを

    [Header("クールタイム時間「秒」")]
    public float coolTime;

    [Header("プレイヤー１ならFalse,プレイヤー２ならTrue")]
    public bool whoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f); //色を薄くする
        image.enabled = false; //初手非表示
    }

    // Update is called once per frame
    void Update()
    {
        //召喚したらクールタイムへ
        if(gameObject.CompareTag("SummonZone_p1"))
        {
            OnCoolTime();
        }

        //所持金が足りないときは購入不可へ
        //if(GeneralManager.instance.unitManager.UnitMoney <= Unit_manager.unit_list[].Price)
        //{
        //    NotBuyCard();
        //}
        
    }

    /// <summary>
    /// クールタイム
    /// </summary>
    public void OnCoolTime()
    {
        //召喚したらクールタイム用のimageを表示
        //coolTime分の円ゲージ風に減少
        image.fillAmount -= 1.0f / coolTime * Time.deltaTime;
        image.enabled = true; //非表示用

        //一周したらフラグをfalseに
        if (image.fillAmount <= 0)
        {
            //fikkAmountを戻して透明化
            image.fillAmount = 1;
            image.enabled = false; //非表示用
        }
    }

    /// <summary>
    /// 召喚不可（召喚金額＞所持金）
    /// </summary>
    public void NotBuyCard()
    {
        //imageを半透明で表示
        image.enabled = true;

        //購入可能になったら(所持金＞購入金額)
        //if(GeneralManager.instance.unitManager.UnitMoney >= Unit_manager.unit_list[].Price)
        //{
        //    image.enabled = false;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    //リストnumber
    public int summon_number;

    public GameObject unit_parent;
    private GameObject unit_child;
    [Header("ユニットならFalse,計略カードならTrue")]
    public bool isCardType; //ユニットならFalse,計略カードならTrue
    [Header("プレイヤー１ならFalse,プレイヤー２ならTrue")]
    public bool isPlayer;
    //ドラッグ前の位置
    private Vector2 startPos;

    public void Start()
    {
        unit_parent = GameObject.Find("Unit_generation_location");
    }
    //ドラッグ開始
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;  //マウスをクリックした最初の場所を保管
                                        //色を薄くする
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

        //raycastTargetをOFFにする
        GetComponent<Image>().raycastTarget = false;
    }

    //ドラッグ中
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 objectPoint = Camera.main.WorldToScreenPoint(transform.position);   //objectの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector2 pointScreen = new Vector2(Input.mousePosition.x, Input.mousePosition.y);   //マウスの位置を保存   
        Vector2 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);   //オブジェクトの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        transform.position = pointWorld;    //オブジェクトの位置を、pointWorldにする   
    }

    //ドラッグ終了
    public void OnEndDrag(PointerEventData eventData)
    {
        //色を元に戻す（白色にする）
        GetComponent<Image>().color = Color.white;

        //raycastTargetをONにする
        GetComponent<Image>().raycastTarget = true;

        bool flg = true;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (!isCardType)
            {
                if (hit.gameObject.CompareTag("SummonZone_p1")) //      マウスのレイが範囲以内に当たってる場合
                {
                    if (GeneralManager.instance.unitManager.UnitMoney > Unit_manager.unit_list[summon_number].Price)
                    {
                        GeneralManager.instance.unitManager.UnitMoney -= Unit_manager.unit_list[summon_number].Price;
                        if (!isPlayer)
                            unit_child = Unit_manager.Instantiate_unit(Unit_manager.unit_list[summon_number], this.transform.position, 1);
                        else
                            unit_child = Unit_manager.Instantiate_unit(Unit_manager.unit_list[summon_number], this.transform.position, 2);
                        unit_child.transform.parent = unit_parent.transform;
                    }
                }
            }
            else if (isCardType)
            {
                if (hit.gameObject.CompareTag("StrategyStage")) //      マウスのレイが範囲以内に当たってる場合
                {
                    if (GeneralManager.instance.unitManager.UnitMoney > Unit_manager.strategy_list[summon_number].Price)
                    {
                        GeneralManager.instance.unitManager.UnitMoney -= Unit_manager.strategy_list[summon_number].Price;
                        if (!isPlayer)
                            unit_child = Unit_manager.Instantiate_unit(Unit_manager.strategy_list[summon_number], this.transform.position, 1);
                        else
                            unit_child = Unit_manager.Instantiate_unit(Unit_manager.strategy_list[summon_number], this.transform.position, 2);
                    }
                }
            }
                flg = false;
                GetComponent<Image>().raycastTarget = true;
        }

        transform.position = startPos;
    }
}

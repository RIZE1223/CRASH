using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //ドラッグ前の位置
    private Vector2 startPos;
    //リストnumber
    public int summon_number;
    public float time = 5;
    private bool cooltime = false;

    private void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            cooltime = true;
        }
    }
    //ドラッグ開始
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(cooltime == true)
        {
            startPos = transform.position;  //マウスをクリックした最初の場所を保管
                                            //色を薄くする
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

            //raycastTargetをOFFにする
            GetComponent<Image>().raycastTarget = false;
        }
    }

    //ドラッグ中
    public void OnDrag(PointerEventData eventData)
    {
        if (cooltime == true)
        {
            Vector2 objectPoint = Camera.main.WorldToScreenPoint(transform.position);   //objectの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
            Vector2 pointScreen = new Vector2(Input.mousePosition.x, Input.mousePosition.y);   //マウスの位置を保存   
            Vector2 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);   //オブジェクトの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
            transform.position = pointWorld;    //オブジェクトの位置を、pointWorldにする
        }
            
    }

    //ドラッグ終了
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cooltime == true)
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
                if (hit.gameObject.CompareTag("SummonZone_p1")) //      マウスのレイが範囲以内に当たってる場合
                {
                    Unit_manager.Instantiate_unit(Unit_manager.unit_list[summon_number], this.transform.position, 1);

                    //transform.position = hit.gameObject.transform.position;
                    flg = false;

                    GetComponent<Image>().raycastTarget = false;

                }
            }

            if (flg)    //範囲外だったら最初の場所に戻る（マウスをクリックした場所）
            {
                transform.position = startPos;
            }
            else
            {

                Destroy(gameObject);
            }
        }
            
    }
}

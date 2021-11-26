using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof (Image))]
public class Sildier : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //ドラッグ前の位置
    private Vector2 startPos;

    //ドラッグ開始
    public void OnBeginDrag(PointerEventData eventData)
    {
        //ドラッグ前の位置を記憶する
        startPos = transform.position;

        //色を薄くする
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

        //raycastTargetをOFFにする
        GetComponent<Image>().raycastTarget = false;
    }

    //ドラッグ中
    public void OnDrag(PointerEventData eventData)
    {
        //ドラッグ中は位置を更新する
        transform.position = eventData.position;

        GetComponent<RectTransform>().Translate(eventData.delta);
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
            if (hit.gameObject.CompareTag("Stage"))
            {
                transform.position = hit.gameObject.transform.position;
                flg = false;

                GetComponent<Image>().raycastTarget = false;

            }
        }

        if (flg)
        {
            transform.position = startPos;
        }
    }
}

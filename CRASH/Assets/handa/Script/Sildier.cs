using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof (Image))]
public class Sildier : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //�h���b�O�O�̈ʒu
    private Vector2 startPos;

    //�h���b�O�J�n
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�h���b�O�O�̈ʒu���L������
        startPos = transform.position;

        //�F�𔖂�����
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

        //raycastTarget��OFF�ɂ���
        GetComponent<Image>().raycastTarget = false;
    }

    //�h���b�O��
    public void OnDrag(PointerEventData eventData)
    {
        //�h���b�O���͈ʒu���X�V����
        transform.position = eventData.position;

        GetComponent<RectTransform>().Translate(eventData.delta);
    }

    //�h���b�O�I��
    public void OnEndDrag(PointerEventData eventData)
    {
        //�F�����ɖ߂��i���F�ɂ���j
        GetComponent<Image>().color = Color.white;

        //raycastTarget��ON�ɂ���
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

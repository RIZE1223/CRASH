using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Sildier : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rb;

    public float moveSpeed = 0;

    void Stat()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("start");
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Ing");
        GetComponent<RectTransform>().Translate(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");
        GetComponent<Image>().color = Color.white;
        GetComponent<Image>().raycastTarget = true;

        if (gameObject.tag == "Stage")
        {
            GetComponent<Image>().raycastTarget = false;
            Debug.Log("On");
            moveSpeed = 1;
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            moveSpeed = 0;
        }
    }
}

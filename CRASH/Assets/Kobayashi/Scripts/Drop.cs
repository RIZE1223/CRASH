using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //ãzíÖÇ∑ÇÈèàóù
            eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            Unit_manager.Instantiate_unit(Unit_manager.unit_list[1], , 1);
        }
    }
    
}
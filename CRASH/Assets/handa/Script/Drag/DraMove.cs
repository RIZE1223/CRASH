using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraMove : MonoBehaviour,IBeginDragHandler,IDeselectHandler,IDragHandler,IEndDragHandler
{
    //Dragして複製したObject
    private GameObject draggingObj;

    //複製元
    [SerializeField] private GameObject dragImageObj;

    private Transform cancasTrans;

    // Start is called before the first frame update
    void Start()
    {
        //cancasTransの初期化
        cancasTrans = FindObjectOfType<Canvas>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Drag開始の処理*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        //特定のUIしかDragできないように
        //if ("特定のUI" == null) return;

        //Dragしたものを複製
        draggingObj = Instantiate(dragImageObj, cancasTrans);

        //複製したものを最前面に（親オブジェクトはCanvas）
        draggingObj.transform.SetAsLastSibling();

        //複製元の色を暗くする


        //複製がレイキャストをブロックしないようにする
        /*ボタンを離した情報は最前面の複製が真っ先に受け取られ、スロットに届かないから*/

        Debug.Log("dragstart");
    }


    /*Drag中の処理*/
    public void OnDeselect(BaseEventData eventData)
    {
        //特定のUIしかDragできないように
        //if ("特定のUI" == null) return;

        //複製がポインターを追尾する
        draggingObj.transform.position = Input.mousePosition;

        Debug.Log("draging");

    }

    public void OnDrag(PointerEventData eventData)
    {
        //仲介人からDragしたものを受け取る
        
        //元々持っていた情報を仲介人に渡す
    }

    /*Drag終了の処理*/
    public void OnEndDrag(PointerEventData eventData)
    {
        ////複数を破壊
        //Destroy(draggingObj);

        //仲介人からDragしたものを受け取る
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraMove : MonoBehaviour,IBeginDragHandler,IDeselectHandler,IDragHandler,IEndDragHandler
{
    //Drag���ĕ�������Object
    private GameObject draggingObj;

    //������
    [SerializeField] private GameObject dragImageObj;

    private Transform cancasTrans;

    // Start is called before the first frame update
    void Start()
    {
        //cancasTrans�̏�����
        cancasTrans = FindObjectOfType<Canvas>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Drag�J�n�̏���*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�����UI����Drag�ł��Ȃ��悤��
        //if ("�����UI" == null) return;

        //Drag�������̂𕡐�
        draggingObj = Instantiate(dragImageObj, cancasTrans);

        //�����������̂��őO�ʂɁi�e�I�u�W�F�N�g��Canvas�j
        draggingObj.transform.SetAsLastSibling();

        //�������̐F���Â�����


        //���������C�L���X�g���u���b�N���Ȃ��悤�ɂ���
        /*�{�^���𗣂������͍őO�ʂ̕������^����Ɏ󂯎���A�X���b�g�ɓ͂��Ȃ�����*/

        Debug.Log("dragstart");
    }


    /*Drag���̏���*/
    public void OnDeselect(BaseEventData eventData)
    {
        //�����UI����Drag�ł��Ȃ��悤��
        //if ("�����UI" == null) return;

        //�������|�C���^�[��ǔ�����
        draggingObj.transform.position = Input.mousePosition;

        Debug.Log("draging");

    }

    public void OnDrag(PointerEventData eventData)
    {
        //����l����Drag�������̂��󂯎��
        
        //���X�����Ă������𒇉�l�ɓn��
    }

    /*Drag�I���̏���*/
    public void OnEndDrag(PointerEventData eventData)
    {
        ////������j��
        //Destroy(draggingObj);

        //����l����Drag�������̂��󂯎��
    }
}

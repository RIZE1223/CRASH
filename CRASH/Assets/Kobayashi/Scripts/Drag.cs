using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //�h���b�O�O�̈ʒu
    private Vector2 startPos;
    //���X�gnumber
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
    //�h���b�O�J�n
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(cooltime == true)
        {
            startPos = transform.position;  //�}�E�X���N���b�N�����ŏ��̏ꏊ��ۊ�
                                            //�F�𔖂�����
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

            //raycastTarget��OFF�ɂ���
            GetComponent<Image>().raycastTarget = false;
        }
    }

    //�h���b�O��
    public void OnDrag(PointerEventData eventData)
    {
        if (cooltime == true)
        {
            Vector2 objectPoint = Camera.main.WorldToScreenPoint(transform.position);   //object�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
            Vector2 pointScreen = new Vector2(Input.mousePosition.x, Input.mousePosition.y);   //�}�E�X�̈ʒu��ۑ�   
            Vector2 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);   //�I�u�W�F�N�g�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
            transform.position = pointWorld;    //�I�u�W�F�N�g�̈ʒu���ApointWorld�ɂ���
        }
            
    }

    //�h���b�O�I��
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cooltime == true)
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
                if (hit.gameObject.CompareTag("SummonZone_p1")) //      �}�E�X�̃��C���͈͈ȓ��ɓ������Ă�ꍇ
                {
                    Unit_manager.Instantiate_unit(Unit_manager.unit_list[summon_number], this.transform.position, 1);

                    //transform.position = hit.gameObject.transform.position;
                    flg = false;

                    GetComponent<Image>().raycastTarget = false;

                }
            }

            if (flg)    //�͈͊O��������ŏ��̏ꏊ�ɖ߂�i�}�E�X���N���b�N�����ꏊ�j
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
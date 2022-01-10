using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    //���X�gnumber
    public int summon_number;

    public GameObject unit_parent;
    private GameObject unit_child;
    [Header("���j�b�g�Ȃ�False,�v���J�[�h�Ȃ�True")]
    public bool isCardType; //���j�b�g�Ȃ�False,�v���J�[�h�Ȃ�True
    [Header("�v���C���[�P�Ȃ�False,�v���C���[�Q�Ȃ�True")]
    public bool isPlayer;
    //�h���b�O�O�̈ʒu
    private Vector2 startPos;

    public void Start()
    {
        unit_parent = GameObject.Find("Unit_generation_location");
    }
    //�h���b�O�J�n
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;  //�}�E�X���N���b�N�����ŏ��̏ꏊ��ۊ�
                                        //�F�𔖂�����
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

        //raycastTarget��OFF�ɂ���
        GetComponent<Image>().raycastTarget = false;
    }

    //�h���b�O��
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 objectPoint = Camera.main.WorldToScreenPoint(transform.position);   //object�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector2 pointScreen = new Vector2(Input.mousePosition.x, Input.mousePosition.y);   //�}�E�X�̈ʒu��ۑ�   
        Vector2 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);   //�I�u�W�F�N�g�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        transform.position = pointWorld;    //�I�u�W�F�N�g�̈ʒu���ApointWorld�ɂ���   
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
            if (!isCardType)
            {
                if (hit.gameObject.CompareTag("SummonZone_p1")) //      �}�E�X�̃��C���͈͈ȓ��ɓ������Ă�ꍇ
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
                if (hit.gameObject.CompareTag("StrategyStage")) //      �}�E�X�̃��C���͈͈ȓ��ɓ������Ă�ꍇ
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

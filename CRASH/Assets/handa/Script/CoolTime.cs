using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    [Header("�N�[���^�C���pimage")]
    public Image Image;

    [Header("�N�[���^�C������(�b)")]
    public float coolTime;

    [Header("�v���C���[����(fales = 1, true = 2)")]
    public bool wayPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        Image.enabled = false;//��\��
    }

    // Update is called once per frame
    void Update()
    {
        //�����\�G���A�ŏ����o������
        if(!wayPlayer && gameObject.CompareTag("SummonZone_p1")
            || wayPlayer && gameObject.CompareTag("SummonZone_p2")
                || gameObject.CompareTag("StrategyStage"))
        {
            OnCoolCard();
        }

        //�w���ł��Ȃ��ꍇ(������ < �K�v���z)
        //if(GeneralManager.instance.unitManager.UnitMoney <= Unit_manager.unit_list[].Price)
        //{
        //    NotBuyCard();
        //}
    }

    public void OnCoolCard()
    {
        //�\�����ĉ~�Q�[�W�݂����Ɍ���
        Image.enabled = true;
        Image.fillAmount -= 1.0f / coolTime * Time.deltaTime;

        //���������fillAmount���P�ɖ߂��Ĕ�\��
        if(Image.fillAmount <= 0)
        {
            Image.fillAmount = 1;
            Image.enabled = false;
        }
    }

    public void NotBuyCard()
    {
        //�\��
        Image.enabled = true;

        //�����������������\��
        //if(GeneralManager.instance.unitManager.UnitMoney >= Unit_manager.unit_list[].Price)
        //{
        //    Image.enabled = false;
        //}
    }
}

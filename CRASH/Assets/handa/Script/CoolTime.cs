using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoolTime : MonoBehaviour
{
    [Header("image")]
    [SerializeField]
    public Image image; //�D�F�̓���image�I�Ȃ̂�

    [Header("�N�[���^�C�����ԁu�b�v")]
    public float coolTime;

    [Header("�v���C���[�P�Ȃ�False,�v���C���[�Q�Ȃ�True")]
    public bool whoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f); //�F�𔖂�����
        image.enabled = false; //�����\��
    }

    // Update is called once per frame
    void Update()
    {
        //����������N�[���^�C����
        if(gameObject.CompareTag("SummonZone_p1"))
        {
            OnCoolTime();
        }

        //������������Ȃ��Ƃ��͍w���s��
        //if(GeneralManager.instance.unitManager.UnitMoney <= Unit_manager.unit_list[].Price)
        //{
        //    NotBuyCard();
        //}
        
    }

    /// <summary>
    /// �N�[���^�C��
    /// </summary>
    public void OnCoolTime()
    {
        //����������N�[���^�C���p��image��\��
        //coolTime���̉~�Q�[�W���Ɍ���
        image.fillAmount -= 1.0f / coolTime * Time.deltaTime;
        image.enabled = true; //��\���p

        //���������t���O��false��
        if (image.fillAmount <= 0)
        {
            //fikkAmount��߂��ē�����
            image.fillAmount = 1;
            image.enabled = false; //��\���p
        }
    }

    /// <summary>
    /// �����s�i�������z���������j
    /// </summary>
    public void NotBuyCard()
    {
        //image�𔼓����ŕ\��
        image.enabled = true;

        //�w���\�ɂȂ�����(���������w�����z)
        //if(GeneralManager.instance.unitManager.UnitMoney >= Unit_manager.unit_list[].Price)
        //{
        //    image.enabled = false;
        //}
    }
}

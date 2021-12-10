using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount2 : MonoBehaviour
{
    [SerializeField, Header("�������Ԃ̐ݒ�l")]
    public int countdown;
    [SerializeField, Header("�������Ԃ̕\��")]
    public Text countdownText;

    private int currentTime;    // ���݂̎c�莞�ԁi�s�v�ȏꍇ�͐錾���Ȃ��j
    private float timer;        // ���Ԍv���p

    private int money;          // �����̐�
    private float moneyTimer;   // ���Ԍv���p(����)

    void Start()
    {
       //countdown��currentTime�ɏ���������
        currentTime = countdown;
    }

    void Update()
    {
        // timer�𗘗p���Čo�ߎ��Ԃ��v��
        timer += Time.deltaTime;

        // 1�b�o�߂��Ƃ�timer��0�ɖ߂��Acountdown�����Z����
        if (timer >= 1)
        {
            timer = 0;
            countdown--;  
            // ���ԕ\�����X�V���郁�\�b�h���Ăяo��
            DisplayCountTime(countdown);   
        }

        // timer�𗘗p���Čo�ߎ��Ԃ��v��
        moneyTimer += Time.deltaTime;

        // 3�b�o�߂��Ƃ�timer��0�ɖ߂��Amoney�����Z����
        if (moneyTimer >= 3)
        {
            moneyTimer = 0;
            money++;
        }

        if (countdown <= 0)
        {
            countdownText.text = "Time Up!!";
        }
    }

    /// <summary>
    /// �������Ԃ��X�V����[��:�b]�ŕ\������
    /// </summary>
    private void DisplayCountTime(int limitTime)
    {
        // �����Ŏ󂯎�����l��[��:�b]�ɕϊ����ĕ\������
        // ToString("00")�Ń[���v���[�X�t�H���_�[���āA�P���̂Ƃ��͓���0������
        countdownText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00\n") + "����:" + money.ToString("0");
    }

}

/*
 f0 = �����_��\�����Ȃ�
 f1 = �����_���ʂ܂ŕ\��
 f2 = �����_���ʂ܂ŕ\��
   ....
 */

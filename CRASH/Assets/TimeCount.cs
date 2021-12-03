using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 5.0f;

    // �����̏���
    public float time2 = 0.0f;
    public float money = 0;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        // �����p�̏����̕b�����J�E���g
        time2 += Time.deltaTime;

        //���ԂƎ�����\������
        timeText.text = countdown.ToString("f1") + "�b\n" + "�����F" + money.ToString("f1");


        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "Time Up!!";
        }

        // �R�b���Ɏ������P�ǉ�
        if(time2 >= 3)
        {
            money += 1;
            time2 = 0.0f;
        }
    }
}

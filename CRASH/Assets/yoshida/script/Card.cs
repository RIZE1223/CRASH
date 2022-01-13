using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("�U���f�B���C����(�U���A�j���[�V�����̎���)/�b")]
    public float attack_delay;  //�U�����[�V����
    private float nowDelay; //���݂̃��[�V��������

    int A;  //A���ĉ��ł����H
    int B;  //B���ĉ��ł����H

    private GameObject castle1HP;
    private GameObject castle2HP;
    private void Awake()
    {
        castle1HP = GameObject.Find("Player1Castle");
        castle2HP = GameObject.Find("Player2Castle");
    }

    void Start()
    {
        A = castle1HP.GetComponent<Unit_model>().hp;
        B = castle2HP.GetComponent<Unit_model>().hp;
    }

    void Update()
    {
        if (attack_delay >= nowDelay)
        {
            nowDelay += Time.deltaTime;
        }
        else if (attack_delay < nowDelay)
        {
            ChangeHp();
        }
    }

    private void ChangeHp()
    {
        castle1HP.GetComponent<Unit_model>().hp = B;
        castle2HP.GetComponent<Unit_model>().hp = A;
        Destroy(this.gameObject);
    }
}

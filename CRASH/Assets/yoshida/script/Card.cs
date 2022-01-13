using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("攻撃ディレイ時間(攻撃アニメーションの時間)/秒")]
    public float attack_delay;  //攻撃モーション
    private float nowDelay; //現在のモーション時間

    int A;  //Aって何ですか？
    int B;  //Bって何ですか？

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

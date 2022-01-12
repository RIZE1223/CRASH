using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int A;
    int B;

    public GameObject castle1HP;
    public GameObject castle2HP;

    void Start()
    {
        A = castle1HP.GetComponent<Unit_model>().hp;
        B = castle2HP.GetComponent<Unit_model>().hp;
    }

    void Update()
    {


    }


    // 城付近に触れながらマウスを離したら効果発動（仮）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SummonZone_p1")
        {
            if (Input.GetMouseButtonUp(0))
            {
               // Debug.Log("効果発動");
                castle1HP.GetComponent<Unit_model>().hp = B;
                castle2HP.GetComponent<Unit_model>().hp = A;

                Destroy(this.gameObject);

            }
        }
    }
}

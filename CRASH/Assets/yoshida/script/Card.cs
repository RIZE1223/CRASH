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


    // ��t�߂ɐG��Ȃ���}�E�X�𗣂�������ʔ����i���j
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SummonZone_p1")
        {
            if (Input.GetMouseButtonUp(0))
            {
               // Debug.Log("���ʔ���");
                castle1HP.GetComponent<Unit_model>().hp = B;
                castle2HP.GetComponent<Unit_model>().hp = A;

                Destroy(this.gameObject);

            }
        }
    }
}

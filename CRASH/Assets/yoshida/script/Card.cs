using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Castle1 = GameObject.Find("Player1Castle");
        GameObject Castle2 = GameObject.Find("Player2Castle");

    }


    // ��t�߂ɐG��Ȃ���}�E�X�𗣂�������ʔ����i���j
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SummonZone_p1")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("���ʔ���");
                // Player1Castle��HP = Player2Castle��HP
                // Player2Castle��HP = Player1Castle��HP�ɂ��������ǂ킩��Ȃ����炠�Ƃŕ���

            }
        }
    }
}

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


    // 城付近に触れながらマウスを離したら効果発動（仮）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SummonZone_p1")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("効果発動");
                // Player1CastleのHP = Player2CastleのHP
                // Player2CastleのHP = Player1CastleのHPにしたいけどわからないからあとで聞く

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCard : MonoBehaviour
{
    [SerializeField] private Transform PlayerHand;  //場所参照
    [SerializeField] private List<GameObject> cards = new List<GameObject>();  //カードリスト作成

    private void FixedUpdate()
    {

        int ObjCount = this.transform.childCount;
        int num = Random.Range(0, cards.Count); //0からカードのリストの数だけランダムでだす

        if (ObjCount <= 5)
        {      
                GameObject.Instantiate(cards[num], PlayerHand);    //カード生成     
        }
    }
}

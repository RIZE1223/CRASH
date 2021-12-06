using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCard : MonoBehaviour
{
    [SerializeField] private Transform PlayerHand;  //�ꏊ�Q��
    [SerializeField] private List<GameObject> cards = new List<GameObject>();  //�J�[�h���X�g�쐬

    private void FixedUpdate()
    {

        int ObjCount = this.transform.childCount;
        int num = Random.Range(0, cards.Count); //0����J�[�h�̃��X�g�̐����������_���ł���

        if (ObjCount <= 5)
        {      
                GameObject.Instantiate(cards[num], PlayerHand);    //�J�[�h����     
        }
    }
}

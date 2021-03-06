using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostHp : MonoBehaviour
{
    [SerializeField]
    List<GameObject> unitList = new List<GameObject>();
    private GameObject generationLocation;
    [Header("攻撃ディレイ時間(攻撃アニメーションの時間)/秒")]
    public float attack_delay;  //攻撃モーション
    private float nowDelay; //現在のモーション時間

    private void Start()
    {
        generationLocation = GameObject.Find("Unit_generation_location");
    }

    private void Update()
    {
        if (attack_delay >= nowDelay)
        {
            nowDelay += Time.deltaTime;
        }
        else if (attack_delay < nowDelay)
        {
            Magic();
        }
    }
    private void Magic()
    {
        if (this.CompareTag("StrategyCard1"))
        {
            foreach (Transform unit in generationLocation.transform)
            {
                if (unit.CompareTag("Unit2"))   //敵ユニットのHPを１にするよ
                    unit.GetComponent<Unit_model>().hp = 1;
            }
        }
        foreach (Transform unit in generationLocation.transform)
        {
            if (this.CompareTag("StrategyCard2"))
            {
                if (unit.CompareTag("Unit1"))   //敵ユニットのHPを１にするよ
                    unit.GetComponent<Unit_model>().hp = 1;
            }
        }
        Destroy(this.gameObject);
    }
}

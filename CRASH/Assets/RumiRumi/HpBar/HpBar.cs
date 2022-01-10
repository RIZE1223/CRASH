using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private int maxHp = 0;
    private int currentHp = 0;
    [Header("親オブジェクトの体力")]
    public Unit_model parentHp;
    [Header("数値を変えるスライダー")]
    public Slider slider;

    private void Start()
    {
        slider.value = 1;   //体力ゲージを最大にするよ
        maxHp = parentHp.hp;
        currentHp = maxHp;
    }
    private void FixedUpdate()
    {
        if(currentHp > parentHp.hp)
        {
            currentHp = parentHp.hp;
            slider.value = (float)currentHp / (float)maxHp;
        }
    }
}

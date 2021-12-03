using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    //カウントダウン
    public float countdown = 5.0f;

    public float time2 = 0.0f;
    public float money = 0;

    //時間を表示するText型の変数
    public Text timeText;

    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        time2 += Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒" + "資金：" + money.ToString("f1");


        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "Time Up!!";
        }

        // 資金
        if(time2 >= 3)
        {
            money += 1;
            time2 = 0.0f;
        }
    }
}

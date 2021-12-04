using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    //カウントダウン
    public float countdown = 5.0f;

    // 資金の処理
    public float time2 = 0.0f;
    public float money = 0;

    //時間を表示するText型の変数
    public Text timeText;

    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        // 資金用の処理の秒数をカウント
        time2 += Time.deltaTime;

        //時間と資金を表示する
        timeText.text = countdown.ToString("f1") + "秒\n" + "資金：" + money.ToString("f1");


        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "Time Up!!";
        }

        // ３秒毎に資金を１追加
        if(time2 >= 3)
        {
            money += 1;
            time2 = 0.0f;
        }
    }
}

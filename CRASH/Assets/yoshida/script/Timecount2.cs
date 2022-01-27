using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timecount2 : MonoBehaviour
{
    [SerializeField, Header("制限時間の設定値")]
    public int _countdown;
    private static int countdown;
    [SerializeField, Header("制限時間の表示")]
    public Text countdownText;

    private int currentTime;    // 現在の残り時間（不要な場合は宣言しない）
    private float timer;        // 時間計測用

    private float moneyTimer;   // 時間計測用(資金)
    [SerializeField]
    private bool isPlayer; //falseならプレイヤー１、trueならプレイヤー２
    private void Awake()
    {
        countdown = _countdown;

        //countdownをcurrentTimeに書き換える
        currentTime = countdown;
    }

    void Update()
    {
        // timerを利用して経過時間を計測
        timer += Time.deltaTime;

        // 1秒経過ごとにtimerを0に戻し、countdownを減算する
        if (timer >= 1)
        {
            timer = 0;
            countdown--;  
            // 時間表示を更新するメソッドを呼び出す
            DisplayCountTime(countdown);   
        }

        // timerを利用して経過時間を計測
        moneyTimer += Time.deltaTime;

        // 3秒経過ごとにtimerを0に戻し、moneyを加算する
        if (moneyTimer >= 3)
        {
            moneyTimer = 0;
            GeneralManager.instance.unitManager.UnitMoney++;
            GeneralManager.instance.unitManager.UnitMoney2++;
        }

        if (countdown <= 0)
        {
            countdownText.text = "Time Up!!";
            SceneManager.LoadScene("draw");
        }
    }

    /// <summary>
    /// 制限時間を更新して[分:秒]で表示する
    /// </summary>
    public void DisplayCountTime(int limitTime)
    {
        // 引数で受け取った値を[分:秒]に変換して表示する
        // ToString("00")でゼロプレースフォルダーして、１桁のときは頭に0をつける
        if (!isPlayer)
        {
            countdownText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00  ") + "資金:" + GeneralManager.instance.unitManager.UnitMoney.ToString("0");
        }
        else
        {
            countdownText.text = ((int)(limitTime / 60)).ToString("00") + ":" + ((int)limitTime % 60).ToString("00  ") + "資金:" + GeneralManager.instance.unitManager.UnitMoney2.ToString("0");
        }
    }
}

/*
 f0 = 小数点を表示しない
 f1 = 小数点第一位まで表示
 f2 = 小数点第二位まで表示
   ....
 */

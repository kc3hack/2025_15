using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManagement : MonoBehaviour
{
    // 制限時間（秒）
    public float timeRemaining = 180.0f; // 初期値を設定

    // TextMeshPro の参照
    public TextMeshProUGUI timerText;

    private void Update()
    {
        // 時間を減らしていく
        timeRemaining -= Time.deltaTime;

        // 時間が 0 以下になったら 0 に固定
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        //時間が0になったらシーン遷移
        if (timeRemaining == 0)
        {
            SceneManager.LoadScene("TimeUp");
        }

        // 表示を更新
        UpdateTimerDisplay();
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay()
    {
        if (timeRemaining > 60)
        {
            // 60 秒以上の場合は「〇分〇秒」の形式で表示
            int minutes = Mathf.FloorToInt(timeRemaining / 60); // 分
            float seconds = timeRemaining % 60;                 // 秒

            // 小数点以下 1 桁までの秒数を表示
            timerText.text = minutes + ":" + seconds.ToString("F1");
        }
        else
        {
            // 60 秒未満の場合は小数点以下 1 桁までの秒数を表示
            timerText.text = timeRemaining.ToString("F1");
        }
    }
}


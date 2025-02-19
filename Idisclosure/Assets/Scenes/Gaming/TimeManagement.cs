using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TimeManagement : MonoBehaviourPunCallbacks
{
    public float timeLimit = 0;

    // TextMeshPro の参照
    public TextMeshProUGUI timerText;

    private float startTime;

    private void Start()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("Time", out object limit))
        {
            timeLimit = (float)limit;
        }
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("StartTime", out object start))
        {
            startTime = (float)start;
        }
        else
        {
            startTime = Time.time;
        }
    }

    private void Update()
    {
        // 現在時刻から開始時刻を引いて経過時間を計算
        float elapsedTime = Time.time - startTime;

        // 残り時間を計算
        float timeRemaining = timeLimit - elapsedTime;

        // 時間が 0 以下になったら 0 に固定
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        // 時間が0になったらシーン遷移
        if (timeRemaining == 0)
        {
            SceneManager.LoadScene("TimeUp");
        }

        // 表示を更新
        UpdateTimerDisplay(timeRemaining);
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay(float timeRemaining)
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

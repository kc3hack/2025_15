using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;
using ExitGames.Client.Photon;

public class TimeManagement : MonoBehaviourPunCallbacks
{
    private double timeLimit;
    private double timeRemaining;
    private double startTime;
    public TMP_Text timerText;
    private bool isTimeInitialized = false;
    private bool isNotified = false;
    string snsPlofiles = "";

    private void Update()
    {
        /*----------時間関連情報取得処理----------*/
        if (!isTimeInitialized)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Time") && PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("StartTime"))
            {
                timeLimit = (double)PhotonNetwork.CurrentRoom.CustomProperties["Time"];
                startTime = (double)PhotonNetwork.CurrentRoom.CustomProperties["StartTime"];
                isTimeInitialized = true;
                Debug.Log("Time: " + timeLimit);
                Debug.Log("StartTime: " + startTime);
            }
            else
            {
                Debug.LogWarning("Time または StartTime がまだ設定されていません。");
                return; // まだ取得できていないので処理しない
            }
        }

        /*----------残り時間計算処理----------*/
        // 現在時刻から開始時刻を引いて経過時間を計算
        double elapsedTime = Time.time - startTime;

        // 残り時間を計算
        timeRemaining = timeLimit - elapsedTime;

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

        /*----------SNS Serverへの情報提供処理----------*/
        if (timeRemaining <= 60 && !isNotified)
        {
            isNotified = true;

            // プレイヤーごとのデータを取得
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Age"))
                {
                    // CustomProperties から Birthday を取得
                    int age = (int)player.CustomProperties["Age"];
                    snsPlofiles += (player.NickName + " → " + age + "years old" + "\n");
                }
            }

            // Room Custom Properties に保存
            if (!string.IsNullOrEmpty(snsPlofiles))
            {
                Hashtable plofiles = new Hashtable {
                    { "Profiles", snsPlofiles }
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(plofiles);
                Debug.Log("[保存] Profiles: " + snsPlofiles);
            }
        }
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay(double timeRemaining)
    {
        if (timeRemaining > 60)
        {
            // 60 秒以上の場合は「〇分〇秒」の形式で表示
            int minutes = (int)Math.Floor(timeRemaining / 60); // 分
            double seconds = timeRemaining % 60;                 // 秒

            // 小数点以下 1 桁までの秒数を表示
            timerText.text = minutes + ":" + seconds.ToString("00.0");
        
        }
        else
        {
            // 60 秒未満の場合は小数点以下 1 桁までの秒数を表示
            timerText.text = timeRemaining.ToString("00.0");
        }
    }
}

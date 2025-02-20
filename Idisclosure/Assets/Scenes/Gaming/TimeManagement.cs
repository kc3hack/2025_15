using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;

public class TimeManagement : MonoBehaviourPunCallbacks
{
    private double timeLimit;
    private double timeRemaining;
    private double startTime;
    public TMP_Text timerText;
    private bool isTimeInitialized = false;
    private bool isNotified = false;
    private string snsProfiles = "";

    private void Update()
    {
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
                return;
            }
        }

        // 現在時刻から開始時刻を引いて経過時間を計算
        double elapsedTime = Time.time - startTime;
        
        // 残り時間を計算
        timeRemaining = timeLimit - elapsedTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        // 残り 1 分 になったら通知
        if (timeRemaining <= 60 && !isNotified)
        {
            isNotified = true;
            CollectPlayerData();
        }

        // 時間が 0 になったらシーン遷移
        if (timeRemaining == 0)
        {
            SceneManager.LoadScene("TimeUp");
        }

        // 表示を更新
        UpdateTimerDisplay(timeRemaining);
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay(double timeRemaining)
    {
        if (timeRemaining > 60)
        {
            int minutes = (int)Math.Floor(timeRemaining / 60);
            double seconds = timeRemaining % 60;
            timerText.text = minutes + ":" + seconds.ToString("00.0");
        }
        else
        {
            timerText.text = timeRemaining.ToString("00.0");
        }
    }

    // プレイヤーのデータを収集し、カスタムプロパティに保存
    private void CollectPlayerData()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("Age"))
            {
                int age = (int)player.CustomProperties["Age"];
                snsProfiles += (player.NickName + " → " + age + " years old\n");
            }
        }

        if (!string.IsNullOrEmpty(snsProfiles))
        {
            Hashtable profiles = new Hashtable {
                { "Profiles", snsProfiles }
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
            Debug.Log("[保存] Profiles: " + snsProfiles);
        }
    }
}
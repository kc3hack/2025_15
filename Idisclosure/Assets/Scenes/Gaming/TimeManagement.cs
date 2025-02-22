using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

public class TimeManagement : MonoBehaviourPunCallbacks
{
    public static TimeManagement Instance; // シングルトンインスタンス

    private double timeLimit;
    private double timeRemaining;
    private double startTime;
    public TMP_Text timerText;
    private bool isTimeInitialized = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は破棄
        }
    }

    private void Update()
    {
        /*----------時間関連情報取得処理----------*/
        if (!isTimeInitialized)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Time") &&
                PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("StartTime"))
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
        double elapsedTime = Time.time - startTime;
        timeRemaining = timeLimit - elapsedTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            TimeUp(); // 時間切れ時の処理を実行
        }

        UpdateTimerDisplay(timeRemaining);

        // 送信するテキストを格納する変数
        HashSet<string> existingProfiles = new HashSet<string>();
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles"))
        {
            string currentProfiles = (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"];
            string[] existingEntries = currentProfiles.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in existingEntries)
            {
                existingProfiles.Add(entry);
            }
        }

        List<string> newProfiles = new List<string>();

        if (timeRemaining <= 270)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Birthyear"))
                {
                    string birthyear = (string)player.CustomProperties["Birthyear"];
                    string profileEntry = player.NickName + " → " + birthyear + " years born";
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        if (timeRemaining <= 240)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Age"))
                {
                    int age = (int)player.CustomProperties["Age"];
                    string profileEntry = player.NickName + " → " + age + " years old";
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        if (timeRemaining <= 180)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Birthday"))
                {
                    string birthday = (string)player.CustomProperties["Birthday"];
                    string profileEntry = player.NickName + " 's Birthday is " + birthday;
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        if (timeRemaining <= 120)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("PlayerIP"))
                {
                    string playerip = (string)player.CustomProperties["PlayerIP"];
                    string profileEntry = player.NickName + " 's IP is " + playerip;
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        if (timeRemaining <= 60)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("SecretID"))
                {
                    string secretid = (string)player.CustomProperties["SecretID"];
                    string profileEntry = player.NickName + "'s SecretID is " + secretid;
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        // 既に送信されていないデータがあれば追加
        if (newProfiles.Count > 0)
        {
            string newProfilesText = string.Join("\n", newProfiles);
            string updatedProfiles = (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles")
                ? (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"] + "\n"
                : "") + newProfilesText;

            Hashtable profiles = new Hashtable { { "Plofiles", updatedProfiles } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
            Debug.Log("[保存] Plofiles: " + newProfilesText);
        }
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay(double timeRemaining)
    {
        if (timerText != null) // timerText が null でないか確認
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
        else
        {
            Debug.LogError("timerText is null!"); // エラーログを出力
        }
    }

    private void TimeUp()
    {
        Debug.Log("Time Up!");
        // 時間切れ時の処理をここに記述 (例: 結果表示、ゲーム終了など)
    }
}
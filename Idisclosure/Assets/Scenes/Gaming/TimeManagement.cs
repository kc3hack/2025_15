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
    private bool isNotified270 = false; // 270秒用
    private bool isNotified240 = false; // 240秒用
    private bool isNotified180 = false;  // 180秒用
    private bool isNotified120 = false;  // 120秒用
    private bool isNotified60 = false;  // 60秒用

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
            SceneManager.LoadScene("TimeUp");
        }

        UpdateTimerDisplay(timeRemaining);

        /*----------SNS Serverへの情報提供処理 (270秒)----------*/
        if (timeRemaining <= 270 && !isNotified270)
        {
            isNotified270 = true;
            string snsProfiles = "";

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Birthyear"))
                {
                    string birthyear = (string)player.CustomProperties["Birthyear"];
                    snsProfiles += (player.NickName + " → " + birthyear + " years born\n");
                }
            }

            if (!string.IsNullOrEmpty(snsProfiles))
            {
                Hashtable profiles = new Hashtable { { "Profiles", snsProfiles } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
                Debug.Log("[保存] Profiles: " + snsProfiles);
            }
        }
        
        /*----------SNS Serverへの情報提供処理 (240秒)----------*/
        if (timeRemaining <= 240 && !isNotified240)
        {
            isNotified240 = true;
            string snsProfiles = "";

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
                Hashtable profiles = new Hashtable { { "Profiles", snsProfiles } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
                Debug.Log("[保存] Profiles: " + snsProfiles);
            }
        }

        /*----------SNS Serverへの情報提供処理 (180秒)----------*/
        if (timeRemaining <= 180 && !isNotified180)
        {
            isNotified180 = true;
            string snsProfiles = "";

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Birthday"))
                {
                    string birthday = (string)player.CustomProperties["Birthday"];
                    snsProfiles += (player.NickName + " 's Birthday is " + birthday + "\n");
                }
            }

            if (!string.IsNullOrEmpty(snsProfiles))
            {
                Hashtable profiles = new Hashtable { { "Profiles", snsProfiles } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
                Debug.Log("[保存] Profiles: " + snsProfiles);
            }
        }

        /*----------SNS Serverへの情報提供処理 (120秒)----------*/
        if (timeRemaining <= 120 && !isNotified120)
        {
            isNotified120 = true;
            string snsProfiles = "";

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("PlayerIP"))
                {
                    string playerip = (string)player.CustomProperties["PlayerIP"];
                    snsProfiles += (player.NickName + " 's IP is " + playerip + "\n");
                }
            }

            if (!string.IsNullOrEmpty(snsProfiles))
            {
                Hashtable profiles = new Hashtable { { "Profiles", snsProfiles } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
                Debug.Log("[保存] Profiles: " + snsProfiles);
            }
        }

        /*----------SNS Serverへの情報提供処理 (60秒)----------*/
        if (timeRemaining <= 60 && !isNotified60)
        {
            isNotified60 = true;
            string snsProfiles = "";

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("SecretID"))
                {
                    string secretid = (string)player.CustomProperties["SecretID"];
                    snsProfiles += (player.NickName + "'s SecretID is " + secretid + "\n");
                }
            }

            if (!string.IsNullOrEmpty(snsProfiles))
            {
                Hashtable profiles = new Hashtable { { "Profiles", snsProfiles } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
                Debug.Log("[保存] Profiles: " + snsProfiles);
            }
        }

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
}


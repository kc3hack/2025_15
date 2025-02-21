using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Linq;
using System;
using System.Net;

public class BrowserSearchMyServer : MonoBehaviour
{
    public TMP_Text SearchWords;

    public void SearchAndMove()
    {
        string searchWords = SearchWords.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Browser起動:" + searchWords);

        /*----------SNS Serverを検索----------*/
        if (searchWords == "sns server")
        {
            int drain = 1;

            int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
            if ((BatteryMyServer - drain >= 0))
            {
                /*----------BatteryMyServer減算処理----------*/
                BatteryMyServer -= drain;
                PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                PlayerPrefs.Save();
                /*----------WiFiにIPを記録----------*/
                // Wifi番号を取得
                int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                // SNSServerIPを取得
                string SNSServerIP = "";
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SNSServerIP"))
                {
                    SNSServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SNSServerIP"];
                }
                // 自分のIPを取得
                string ServerIP = "";
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                {
                    ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                }
                SortAndSave(SNSServerIP, ServerIP, WifiNumber);
                /*----------シーン遷移----------*/
                SceneManager.LoadScene("SNSServer");
            }

        }
        
        /*----------Virus Osakano Obatyannを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingVirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingVirusOO"])
            {
                if (searchWords == "virusoo")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingVirusOOIPを取得
                        string FishingVirusOOIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingVirusOOIP"))
                        {
                            FishingVirusOOIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingVirusOOIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingVirusOOIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingVirusOO");
                    }
                }
            }
            else
            {
                if (searchWords == "virusoo")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string VirusOOIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOOIP"))
                        {
                            VirusOOIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["VirusOOIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(VirusOOIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("VirusOO");
                    }
                }
            }
        }

        /*----------SpareBatteryを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBattery"])
            {
                if (searchWords == "spare battery")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("FishingSpareBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
            else
            {
                if (searchWords == "spare battery")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("SpareBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }

        /*----------SmallBatteryを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBattery"])
            {
                if (searchWords == "small battery")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("FishingSmallBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
            else
            {
                if (searchWords == "small battery")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("SmallBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }

        /*----------PullDeerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PullDeer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["PullDeer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingPullDeer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingPullDeer"])
            {
                if (searchWords == "pull deer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingPullDeerIPを取得
                        string FishingPullDeerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingPullDeerIP"))
                        {
                            FishingPullDeerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingPullDeerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingPullDeerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingPullDeer");
                    }
                }
            }
            else
            {
                if (searchWords == "pull deer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // PullDeerIPを取得
                        string PullDeerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PullDeerIP"))
                        {
                            PullDeerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PullDeerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(PullDeerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("PullDeer");
                    }
                }
            }
        }

         /*---------Dosを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Dos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Dos"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingDos"])
            {
                if (searchWords == "dos")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingDosIPを取得
                        string FishingDosIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDosIP"))
                        {
                            FishingDosIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingDosIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingDosIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingDos");
                    }
                }
            }
            else
            {
                if (searchWords == "dos")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // DosIPを取得
                        string DosIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DosIP"))
                        {
                            DosIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["DosIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(DosIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("Dos");
                    }
                }
            }
        }

        /*----------IPBST1を検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST1") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST1"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST1") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST1"])
            {
                if (searchWords == "ipbst1")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingIPBST1IPを取得
                        string FishingIPBST1IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST1IP"))
                        {
                            FishingIPBST1IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST1IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingIPBST1IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingIPBST1");
                    }
                }
            }
            else
            {
                if (searchWords == "ipbst1")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // IPBST1IPを取得
                        string IPBST1IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST1IP"))
                        {
                            IPBST1IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["IPBST1IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(IPBST1IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("IPBST1");
                    }
                }
            }
        }

            /*----------IPBST2を検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST2") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST2"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST2") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST2"])
            {
                if (searchWords == "ipbst2")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingIPBST2IPを取得
                        string FishingIPBST2IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST2IP"))
                        {
                            FishingIPBST2IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST2IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingIPBST2IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingIPBST2");
                    }
                }
            }
            else
            {
                if (searchWords == "ipbst2")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // IPBST2IPを取得
                        string IPBST2IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST2IP"))
                        {
                            IPBST2IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["IPBST2IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(IPBST2IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("IPBST2");
                    }
                }
            }
        }

            /*----------IPBST3を検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST3") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST3"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST3") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST3"])
            {
                if (searchWords == "ipbst3")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingIPBST3IPを取得
                        string FishingIPBST3IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingIPBST3IP"))
                        {
                            FishingIPBST3IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingIPBST3IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingIPBST3IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingIPBST3");
                    }
                }
            }
            else
            {
                if (searchWords == "ipbst3")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // IPBST3IPを取得
                        string IPBST3IP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST3IP"))
                        {
                            IPBST3IP = (string)PhotonNetwork.CurrentRoom.CustomProperties["IPBST3IP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["ServerIP"];
                        }
                        SortAndSave(IPBST3IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("IPBST3");
                    }
                }
            }
        }

    void SortAndSave(string IP1, string IP2, int WifiNumber)
    {
        int Permutation = UnityEngine.Random.Range(0, 2);

        // IPアドレスを比較し、昇順になるように並び替え
        string NewRecord = (Permutation == 0) ? $"{IP1}:{IP2}\n" : $"{IP2}:{IP1}\n";

        // 既存のWiFi記録を取得して追加
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi" + WifiNumber))
        {
            string Record = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi" + WifiNumber];
            NewRecord = Record + NewRecord;
        }

        // カスタムプロパティを更新
        Hashtable props = new Hashtable
        {
            { "WiFi" + WifiNumber, NewRecord },
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }
}}


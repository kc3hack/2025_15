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
                if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                {
                    ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(VirusOOIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("VirusOO");
                    }
                }
            }
        }

        /*----------SpareBatteryMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServer"])
            {
                if (searchWords == "spare BatteryMyServer")
                {
                    int drain = 0;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // SpareBatteryMyServerIPを取得
                        string FishingSpareBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServerIP"))
                        {
                            FishingSpareBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingSpareBatteryMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSpareBatteryMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "spare BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // SpareBatteryMyServerIPを取得
                        string SpareBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServerIP"))
                        {
                            SpareBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(SpareBatteryMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SpareBatteryMyServer");
                    }
                }
            }
        }

        /*----------SpareBatteryMyServerMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServerMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServerMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServerMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServerMyServer"])
            {
                if (searchWords == "spare BatteryMyServer")
                {
                    int drain = 0;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingSpareBatteryMyServerMyServerIPを取得
                        string FishingSpareBatteryMyServerMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServerMyServerIP"))
                        {
                            FishingSpareBatteryMyServerMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServerMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingSpareBatteryMyServerMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSpareBatteryMyServerMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "spare BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingSpareBatteryMyServerMyServerIPを取得
                        string SpareBatteryMyServerMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServerMyServerIP"))
                        {
                            SpareBatteryMyServerMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServerMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(SpareBatteryMyServerMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SpareBatteryMyServerMyServer");
                    }
                }
            }
        }

        /*----------SmallBatteryMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryMyServer"])
            {
                if (searchWords == "small BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string FishingSmallBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryMyServerIP"))
                        {
                            FishingSmallBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingSmallBatteryMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSmallBatteryMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "small BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string SmallBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServerIP"))
                        {
                            SmallBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(SmallBatteryMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SmallBatteryMyServer");
                    }
                }
            }
        }

        /*----------SmallBatteryMyServerMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServerMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServerMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryMyServerMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryMyServerMyServer"])
            {
                if (searchWords == "small BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string FishingSmallBatteryMyServerMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryMyServerMyServerIP"))
                        {
                            FishingSmallBatteryMyServerMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryMyServerMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingSmallBatteryMyServerMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSmallBatteryMyServerMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "small BatteryMyServer")
                {
                    int drain = 1;

                    int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((BatteryMyServer - drain >= 0))
                    {
                        BatteryMyServer -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string SmallBatteryMyServerMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServerMyServerIP"))
                        {
                            SmallBatteryMyServerMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServerMyServerIP"];
                        }
                        // 自分のIPを取得
                        string ServerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(SmallBatteryMyServerMyServerIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SmallBatteryMyServerMyServer");
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                if (searchWords == "IPBST3")
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(FishingIPBST3IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingIPBST3");
                    }
                }
            }
            else
            {
                if (searchWords == "IPBST3")
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(IPBST3IP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("IPBST3");
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
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
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("ServerIP"))
                        {
                            ServerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["ServerIP"];
                        }
                        SortAndSave(DosIP, ServerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("Dos");
                    }
                }
            }
        }
    }

    public void SortAndSave(string IP1, string IP2, int WifiNumber)
    {
        int Permutation = UnityEngine.Random.Range(0, 2);

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
}


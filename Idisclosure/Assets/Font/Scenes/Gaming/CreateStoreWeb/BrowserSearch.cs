using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Linq;
using System;
using System.Net;

public class BrowserSearch : MonoBehaviour
{
    public TMP_Text SearchWords;

    public void SearchAndMove()
    {
        string searchWords = SearchWords.text.Trim().ToLower().Replace("\u200B", "").Replace(" ","");
        Debug.Log("Browser起動:" + searchWords);

        /*----------SNS Serverを検索----------*/
        if (searchWords == "snsserver")
        {
            int drain = 1;

            int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {
                /*----------Battery減算処理----------*/
                Battery -= drain;
                PlayerPrefs.SetString("Battery", Battery.ToString());
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
                string PlayerIP = "";
                if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                {
                    PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                }
                SortAndSave(SNSServerIP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingVirusOOIP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(VirusOOIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("VirusOO");
                    }
                }
            }
        }

        /*----------SpareBatteryPCを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryPC") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryPC"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryPC") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryPC"])
            {
                if (searchWords == "sparebatterypc"|| searchWords == "sparepc")
                {
                    int drain = 0;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // SpareBatteryPCIPを取得
                        string FishingSpareBatteryPCIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryPCIP"))
                        {
                            FishingSpareBatteryPCIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryPCIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSpareBatteryPCIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSpareBatteryPC");
                    }
                }
            }
            else
            {
                if (searchWords == "sparebatterypc" || searchWords == "sparepc")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // SpareBatteryPCIPを取得
                        string SpareBatteryPCIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryPCIP"))
                        {
                            SpareBatteryPCIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryPCIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(SpareBatteryPCIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SpareBatteryPC");
                    }
                }
            }
        }

        /*----------SpareBatteryMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServer"])
            {
                if (searchWords == "sparebatterymyserver"|| searchWords == "sparemyserver"|| searchWords == "spareserver")
                {
                    int drain = 0;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingSpareBatteryMyServerIPを取得
                        string FishingSpareBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryMyServerIP"))
                        {
                            FishingSpareBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSpareBatteryMyServerIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSpareBatteryMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "sparebatterymyserver"|| searchWords == "sparemyserver"|| searchWords == "spareserver")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingSpareBatteryMyServerIPを取得
                        string SpareBatteryMyServerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServerIP"))
                        {
                            SpareBatteryMyServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServerIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(SpareBatteryMyServerIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SpareBatteryMyServer");
                    }
                }
            }
        }

        /*----------SmallBatteryPCを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryPC") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryPC"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryPC") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryPC"])
            {
                if (searchWords == "smallbatterypc"|| searchWords == "smallpc")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string FishingSmallBatteryPCIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryPCIP"))
                        {
                            FishingSmallBatteryPCIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryPCIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSmallBatteryPCIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSmallBatteryPC");
                    }
                }
            }
            else
            {
                if (searchWords == "smallbatterypc"|| searchWords == "smallpc")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // VirusOOIPを取得
                        string SmallBatteryPCIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryPCIP"))
                        {
                            SmallBatteryPCIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryPCIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(SmallBatteryPCIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SmallBatteryPC");
                    }
                }
            }
        }

        /*----------SmallBatteryMyServerを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryMyServer"])
            {
                if (searchWords == "smallbatterymyserver"|| searchWords == "smallserver"|| searchWords == "smallmyserver")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSmallBatteryMyServerIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSmallBatteryMyServer");
                    }
                }
            }
            else
            {
                if (searchWords == "smallbatterymyserver" || searchWords == "smallserver" || searchWords == "smallmyserver")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(SmallBatteryMyServerIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SmallBatteryMyServer");
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingIPBST1IP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(IPBST1IP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingIPBST2IP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(IPBST2IP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingIPBST3IP, PlayerIP, WifiNumber);
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(IPBST3IP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("IPBST3");
                    }
                }
            }
        }

         /*---------DoSToolを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DoSTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DoSTool"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDoSTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingDoSTool"])
            {
                if (searchWords == "dostool" || searchWords == "dos")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingDoSToolIPを取得
                        string FishingDoSToolIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDoSToolIP"))
                        {
                            FishingDoSToolIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingDoSToolIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingDoSToolIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingDoSTool");
                    }
                }
            }
            else
            {
                if (searchWords == "dostool" || searchWords == "dos")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // DoSToolIPを取得
                        string DoSToolIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DoSToolIP"))
                        {
                            DoSToolIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["DoSToolIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(DoSToolIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("DoSTool");
                    }
                }
            }
        }

        /*----------ClackToolを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("CrackTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["CrackTool"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingCrackTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingCrackTool"])
            {
                if (searchWords == "cracktool" || searchWords == "crack")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // FishingCrackToolIPを取得
                        string FishingCrackToolIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingCrackToolIP"))
                        {
                            FishingCrackToolIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingCrackToolIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingCrackToolIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingCrackTool");
                    }
                }
            }
            else
            {
                if (searchWords == "cracktool" || searchWords == "crack")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        /*----------バッテリー減算処理----------*/
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        /*----------WiFiにIPを記録----------*/
                        // Wifi番号を取得
                        int WifiNumber = int.Parse(PlayerPrefs.GetString("WifiNumber", "1"));
                        // CrackToolIPを取得
                        string CrackToolIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("CrackToolIP"))
                        {
                            CrackToolIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["CrackToolIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(CrackToolIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("CrackTool");
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


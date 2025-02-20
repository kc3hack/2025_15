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
        string searchWords = SearchWords.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Browser起動:" + searchWords);

        /*----------SNS Serverを検索----------*/
        if (searchWords == "sns server")
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

        /*----------SpareBatteryを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBattery"])
            {
                if (searchWords == "spare battery")
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
                        // VirusOOIPを取得
                        string SpareBatteryIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBatteryIP"))
                        {
                            SpareBatteryIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBatteryIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSpareBatteryIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSpareBattery");
                    }
                }
            }
            else
            {
                if (searchWords == "spare battery")
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
                        string SpareBatteryIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryIP"))
                        {
                            SpareBatteryIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(SpareBatteryIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SpareBattery");
                    }
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
                        string SmallBatteryIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBatteryIP"))
                        {
                            SmallBatteryIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBatteryIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSmallBatteryIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("FishingSmallBattery");
                    }
                }
            }
            else
            {
                if (searchWords == "small battery")
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
                        string SmallBatteryIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryIP"))
                        {
                            SmallBatteryIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingSmallBatteryIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("SmallBattery");
                    }
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
                        // FishingPullDeerIPを取得
                        string FishingPullDeerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingPullDeerIP"))
                        {
                            FishingPullDeerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingPullDeerIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingPullDeerIP, PlayerIP, WifiNumber);
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
                        // PullDeerIPを取得
                        string PullDeerIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PullDeerIP"))
                        {
                            PullDeerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PullDeerIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(PullDeerIP, PlayerIP, WifiNumber);
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
                        // FishingDosIPを取得
                        string FishingDosIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDosIP"))
                        {
                            FishingDosIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingDosIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(FishingDosIP, PlayerIP, WifiNumber);
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
                        // DosIPを取得
                        string DosIP = "";
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DosIP"))
                        {
                            DosIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["DosIP"];
                        }
                        // 自分のIPを取得
                        string PlayerIP = "";
                        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(DosIP, PlayerIP, WifiNumber);
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


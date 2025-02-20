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
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                {
                    PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
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
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
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
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
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
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
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

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("SmallBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }
    }

    public void SortAndSave(string IP1, string IP2, int WifiNumber)
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
}

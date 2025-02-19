using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Linq;

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
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SNSServerIP"))
                {
                    string SNSServerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["SNSServerIP"];
                }
                // 自分のIPを取得
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                {
                    string PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
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
                        // SNSServerIPを取得
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingVirusOOIP"))
                        {
                            string FishingVirusOOIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["FishingVirusOOIP"];
                        }
                        // 自分のIPを取得
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            string PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
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
                        // SNSServerIPを取得
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOOIP"))
                        {
                            string VirusOOIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["VirusOOIP"];
                        }
                        // 自分のIPを取得
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerIP"))
                        {
                            string PlayerIP = (string)PhotonNetwork.CurrentRoom.CustomProperties["PlayerIP"];
                        }
                        SortAndSave(VirusOOIP, PlayerIP, WifiNumber);
                        /*----------シーン遷移----------*/
                        SceneManager.LoadScene("VirusOO");
                    }
                }
            }
        }
    }

    public void SortAndSave(string IP1, string IP2, int WifiNumber)
    {   
        int ScaleIP1 = int.Parse(IP1.Replace(".", ""));
        int ScaleIP2 = int.Parse(IP2.Replace(".", ""));
        int[] IPScales = { ScaleIP1, ScaleIP2 };
        int[] IPScalesClone = (int[])IPScales.Clone();
        Array.Sort(IPScales);

        // ソート後の配列と元の配列を比較
        string NewRecord;
        if (IPScalesClone.SequenceEqual(IPScales))
        {
            // IPが昇順で並んでいる場合
            NewRecord = IP1 + ":" + IP2 + "\n";
        }
        else
        {
            // IPが降順の場合
            NewRecord = IP2 + ":" + IP1 + "\n";
        }

        // WiFiのカスタムプロパティを更新
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi" + WifiNumber))
        {
            string Record = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi" + WifiNumber];
            NewRecord = Record + NewRecord;
        }

        Hashtable props = new Hashtable
        {
            { "WiFi" + WifiNumber, NewRecord },
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }

}

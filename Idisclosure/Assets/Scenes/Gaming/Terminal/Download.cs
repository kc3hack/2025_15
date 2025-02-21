using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class Download : MonoBehaviour
{
    /*----------Reset時必要----------*/
    string showTerminal = "";

    public void DownloadVirusOO()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadVirusOO", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("VirusOO\n")))
            {
                // Terminalに追加
                showTerminal += "VirusOO\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadSpareBattery()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));
        int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Battery = 100;
            PlayerPrefs.SetString("Battery", Battery.ToString());
            PlayerPrefs.Save();
            SceneManager.LoadScene("Success");
        }
    }

     public void DownloadSmallBattery()
    {
        int drain = 10;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));
        int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Battery += 25;//25%充電を増やす
            PlayerPrefs.SetString("Battery", Battery.ToString());
            PlayerPrefs.Save();
            SceneManager.LoadScene("Success");
        }
    }

     public void DownloadIPBST1()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadPullDeer", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("IPBST1\n")))
            {
                // Terminalに追加
                showTerminal += "PullDeer\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadDos()
    {
        int drain = 100;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadDos", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("Dos\n")))
            {
                // Terminalに追加
                showTerminal += "Dos\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }
}


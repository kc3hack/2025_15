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

    public void DownloadSpareBatteryPC()
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

    public void DownloadSpareBatteryMyServer()
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
            PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
            PlayerPrefs.Save();
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadSmallBatteryPC()
    {
        int drain = 100;
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

    public void DownloadSmallBatteryMyServer()
    {
        int drain = 100;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));
        int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Battery += 25;//25%充電を増やす
            PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
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
            Hashtable Download = new Hashtable { { "DownloadIPBST1", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("IPBST1\n")))
            {
                // Terminalに追加
                showTerminal += "IPBST1\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadIPBST2()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadIPBST2", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("IPBST2\n")))
            {
                // Terminalに追加
                showTerminal += "IPBST2\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadIPBST3()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadIPBST3", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("IPBST3\n")))
            {
                // Terminalに追加
                showTerminal += "IPBST3\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

    public void DownloadDoSTool()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadDoSTool", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("DoSTool\n")))
            {
                // Terminalに追加
                showTerminal += "DoSTool\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }

     public void DownloadCrackTool()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 支払われたら領収通知発行
            Hashtable Download = new Hashtable { { "DownloadCrackTool", true } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(Download);
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
            {
                showTerminal = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
            }
            if (!(showTerminal.Contains("CrackTool\n")))
            {
                // Terminalに追加
                showTerminal += "CrackTool\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(ShowDisplay);
            }
            SceneManager.LoadScene("Success");
        }
    }
}


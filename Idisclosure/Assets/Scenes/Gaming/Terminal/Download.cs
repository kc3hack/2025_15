using UnityEngine;
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
            PhotonNetwork.CurrentRoom.SetCustomProperties(Download);
            if (!(showTerminal.Contains("VirusOO\n")))
            {
                // Terminalに追加
                showTerminal += "VirusOO\n";
                Hashtable ShowDisplay = new Hashtable { { "TerminalDisplay", showTerminal } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
    }
}

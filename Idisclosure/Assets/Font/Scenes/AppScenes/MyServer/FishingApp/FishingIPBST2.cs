using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingIPBST2 : MonoBehaviour
{
    public void CreateFishingIPBST2()
    {
        string showBrowser = "SNS Server\n";
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST2") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST2"]))
        {
            int drain = 20;

            int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {   
                // Batteryを減らす処理
                Battery -= drain;
                PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                PlayerPrefs.Save();
                Hashtable webs = new Hashtable 
                { 
                    { "IPBST2", true },
                    { "FishingIPBST2", true },
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingAppName", "IPBST2" },
                    { "FishingNow", true },
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // Browserに追加
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
                {
                    showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
                }
                if (!(showBrowser.Contains("IPBST2\n")))
                {
                    showBrowser += "IPBST2\n";
                    Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
                }
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","0.0.0.0");
                Hashtable fisher = new Hashtable
                {
                    {"FisherIPBST2", PhotonNetwork.NickName},
                    {"FishingIPBST2IP", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingIPBST1 : MonoBehaviour
{
    public void CreateFishingIPBST1()
    {
        string showBrowser = "SNS Server\n";
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST1") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST1"]))
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
                    { "IPBST1", true },
                    { "FishingIPBST1", true },
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingAppName", "IPBST1"},
                    { "FishingNow", true },
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // Browserに追加
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
                {
                    showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
                }
                if (!(showBrowser.Contains("IPBST1\n")))
                {
                    showBrowser += "IPBST1\n";
                    Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
                }
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","0.0.0.0");
                Hashtable fisher = new Hashtable
                {
                    {"FisherIPBST1", PhotonNetwork.NickName},
                    {"FishingIPBST1IP", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

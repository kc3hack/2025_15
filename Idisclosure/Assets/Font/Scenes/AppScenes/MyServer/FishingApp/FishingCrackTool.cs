using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingCrackTool : MonoBehaviour
{
    public void CreateFishingCrackTool()
    {
        string showBrowser = "SNS Server\n";
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("CrackTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["CrackTool"]))
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
                    { "CrackTool", true },
                    { "FishingCrackTool", true },
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingNow", true },
                    { "FishingAppName", "CrackTool" }
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // Browserに追加
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
                {
                    showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
                }
                if (!(showBrowser.Contains("CrackTool\n")))
                {
                    showBrowser += "CrackTool\n";
                    Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
                }
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","0.0.0.0");
                Hashtable fisher = new Hashtable
                {
                    {"FisherCrackTool", PhotonNetwork.NickName},
                    {"FishingCrackToolIP", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

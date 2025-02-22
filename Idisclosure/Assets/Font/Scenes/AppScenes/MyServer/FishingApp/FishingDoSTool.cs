using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingDoSTool : MonoBehaviour
{
    public void CreateFishingDoSTool()
    {
        string showBrowser = "SNS Server\n";
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DoSTool") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DoSTool"]))
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
                    { "DoSTool", true },
                    { "FishingDoSTool", true },
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingAppName", "DoSTool" },
                    { "FishingNow", true },
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // Browserに追加
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
                {
                    showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
                }
                if (!(showBrowser.Contains("DoSTool\n")))
                {
                    showBrowser += "DoSTool\n";
                    Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
                }
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","0.0.0.0");
                Hashtable fisher = new Hashtable
                {
                    {"FisherDoSTool", PhotonNetwork.NickName},
                    {"FishingDoSTool", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

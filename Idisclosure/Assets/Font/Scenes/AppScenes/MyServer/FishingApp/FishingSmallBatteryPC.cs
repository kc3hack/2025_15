using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingSmallBatteryPC : MonoBehaviour
{
    public void CreateFishingSmallBatteryPC()
    {
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryPC") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryPC"]))
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
                    { "SmallBatteryPC", true },
                    { "FishingSmallBatteryPC", true }
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingNow", true },
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","0.0.0.0");
                Hashtable fisher = new Hashtable
                {
                    {"FisherSmallBatteryPC", PhotonNetwork.NickName},
                    {"FishingSmallBatteryPCIP", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

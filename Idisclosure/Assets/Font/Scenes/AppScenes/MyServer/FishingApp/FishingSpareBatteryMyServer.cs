using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingSpareBatteryMyServer : MonoBehaviour
{
    public void CreateFishingSpareBatteryMyServer()
    {
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServer"]))
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
                    { "SpareBatteryMyServer", true },
                    { "FishingSpareBatteryMyServer", true }
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                Hashtable FishingNow = new Hashtable
                {
                    { "FishingNow", true },
                };
                PhotonNetwork.LocalPlayer.SetCustomProperties(FishingNow);
                // 宛先を保存
                string ServerIP = (string)PlayerPrefs.GetString("ServerIP","");
                Hashtable fisher = new Hashtable
                {
                    {"FisherSpareBatteryMyServer", PhotonNetwork.NickName},
                    {"FishingSpareBatteryMyServerIP", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

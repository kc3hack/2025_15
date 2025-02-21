using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingDos : MonoBehaviour
{
    public void CreateFishingDos()
    {
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Dos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Dos"]))
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
                    { "Dos", true },
                    { "FishingDos", true }
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
                    {"FisherDos", PhotonNetwork.NickName},
                    {"FishingDos", ServerIP}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
        }
    }
}

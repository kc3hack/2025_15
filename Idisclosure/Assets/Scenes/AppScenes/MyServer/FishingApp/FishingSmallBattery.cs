using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingSmallBattery : MonoBehaviour
{
    public void CreateFishingSmallBattery()
    {
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"]))
        {
            int drain = 20;

            int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {   // Batteryを減らす処理
                Battery -= drain;
                PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                PlayerPrefs.Save();
                Hashtable webs = new Hashtable 
                { 
                    { "SmallBattery", true },
                    { "FishingSmallBattery", true },
                    { "FishingNow", true}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                // 宛先を保存
                Hashtable fisher = new Hashtable
                {
                    {"FisherSmallBattery", PhotonNetwork.NickName}
                    // IPの処理も忘れずに
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
            // ここにwifiにIPメモる処理忘れずに
        }
    }
}

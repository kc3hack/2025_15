using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingViruOO : MonoBehaviour
{
    public void CreateFishingVirusOO()
    {
        if (!(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"]))
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
                    { "VirusOO", true },
                    { "FishingVirusOO", true },
                    { "FishingNow", true}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
                // 宛先を保存
                Hashtable fisher = new Hashtable
                {
                    {"FisherVirusOO", PhotonNetwork.NickName}
                    // IPの処理も忘れずに
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

                SceneManager.LoadScene("Success");
            }
            // ここにwifiにIPメモる処理忘れずに
        }
    }
}

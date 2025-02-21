using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class AntiFishingNow : MonoBehaviour
{
    // FishingNowのシーンを解除する
    public void HideFishingNow()
    {
        //FishingAppの取得と無効化
        string fishingAppName = "";
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("FishingAppName"))
        {
            fishingAppName = (string)PhotonNetwork.LocalPlayer.CustomProperties["FishingAppName"];
        }
        Hashtable webs = new Hashtable 
        { 
            { fishingAppName, false },
            { "Fishing" + fishingAppName, false },
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(webs);
        // Browserから削除
        string showBrowser = "SNS Server\n";
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
        {
            showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
        }
        if (showBrowser.Contains(fishingAppName + "\n"))
        {
            showBrowser = showBrowser.Replace(fishingAppName + "\n","");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        Hashtable props = new Hashtable
        {
            { "FishingNow", false}
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        Debug.Log("Done!");
    }
}

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
        Hashtable webs = new Hashtable 
        { 
            { "VirusOO", false },
            { "FishingVirusOO", false },
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(webs);

        Hashtable props = new Hashtable
        {
            { "FishingNow", false}
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        Debug.Log("Done!");
    }
}

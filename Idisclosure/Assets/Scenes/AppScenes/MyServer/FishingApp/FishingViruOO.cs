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
            Hashtable webs = new Hashtable 
            { 
                { "VirusOO", true },
                { "FishingVirusOO", true },
                { "FishingNow", true}
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(webs);

            Hashtable fisher = new Hashtable
            {
                {"FisherVirusOO", PhotonNetwork.NickName}
                // IPの処理も忘れずに
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(fisher);

            SceneManager.LoadScene("Success");
        }
    }
}

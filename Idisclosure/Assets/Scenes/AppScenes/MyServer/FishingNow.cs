using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class FishingNow : MonoBehaviour
{
    // FishingNowのシーンを重ねる
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingNow") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingNow"])
        {
            SceneManager.LoadScene("FishingNow", LoadSceneMode.Additive);
        }
    }
}

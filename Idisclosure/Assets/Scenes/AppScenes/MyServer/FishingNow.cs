using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class FishingNow : MonoBehaviour
{
    void Update()
    {
        // "FishingNow"シーンがすでにロードされているか確認
        if (!SceneManager.GetSceneByName("FishingNow").isLoaded && PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingNow") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingNow"])
        {
            // FishingNowシーンを重ねる
            SceneManager.LoadScene("FishingNow", LoadSceneMode.Additive);
        }
    }
}

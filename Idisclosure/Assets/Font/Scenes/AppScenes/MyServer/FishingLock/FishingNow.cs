using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class FishingNow : MonoBehaviour
{
    void Update()
    {
        if (!SceneManager.GetSceneByName("FishingNow").isLoaded && PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("FishingNow") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["FishingNow"])
        {
            // FishingNowシーンを重ねる
            SceneManager.LoadScene("FishingNow", LoadSceneMode.Additive);
        }
        else if (SceneManager.GetSceneByName("FishingNow").isLoaded && PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("FishingNow") && !((bool)PhotonNetwork.LocalPlayer.CustomProperties["FishingNow"]))
        {
            SceneManager.UnloadSceneAsync("FishingNow");
        }
    }
}

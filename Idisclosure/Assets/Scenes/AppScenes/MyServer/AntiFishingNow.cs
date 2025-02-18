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
                {"FishingNow", false}
            };
        SceneManager.UnloadSceneAsync("FishingNow");
    }
}

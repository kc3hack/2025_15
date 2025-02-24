using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class FishingManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private const byte SuccessFishing = 3;

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == SuccessFishing)
        {
            // BuhiCoinを受け取る
            int income = (int)photonEvent.CustomData;
            int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));
            BuhiCoin += income;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();
        }
    }
}

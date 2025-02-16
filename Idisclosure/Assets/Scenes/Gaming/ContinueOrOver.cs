using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private const byte CrackedSecretID = 1;

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == CrackedSecretID)
        {
            // メッセージを受け取ったらシーン遷移
            SceneManager.LoadScene("EndGame");
        }
    }
}
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class ReceiveIPs : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private const byte SendIPs = 2;

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == SendIPs)
        {
            object[] receivedData = (object[])photonEvent.CustomData;
            string playerIP = (string)receivedData[0];
            string serverIP = (string)receivedData[1];
            PlayerPrefs.SetString("PlayerIP", playerIP);
            PlayerPrefs.SetString("ServerIP", serverIP);
            PlayerPrefs.Save();
            Debug.Log("IPs are saved! : " + playerIP + " : " + serverIP);
        }
    }
}

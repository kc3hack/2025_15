using UnityEngine;
using TMPro;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Wifi1 : MonoBehaviour
{
    public TMP_Text Wifi1Display;
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi1"))
        {
            Wifi1Display.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi1"];
        }
    }
}

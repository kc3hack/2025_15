using UnityEngine;
using TMPro;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Wifi3 : MonoBehaviour
{
    public TMP_Text Wifi1Display;
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi3"))
        {
            Wifi1Display.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi3"];
        }
    }
}

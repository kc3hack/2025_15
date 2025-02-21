using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;


public class ShowTeminal : MonoBehaviour
{
    public TMP_Text ShowTerminal;
    void Update(){
         /*----------テキストに反映----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("TerminalDisplay"))
        {
            ShowTerminal.text = (string)PhotonNetwork.LocalPlayer.CustomProperties["TerminalDisplay"];
        }
    }
}

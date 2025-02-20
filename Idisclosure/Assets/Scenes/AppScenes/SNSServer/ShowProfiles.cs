using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class ShowProfiles : MonoBehaviour
{
    public TMP_Text Plofiles;
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Profiles"))
        {
            Plofiles.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["Profiles"];
        }
            
    }
}

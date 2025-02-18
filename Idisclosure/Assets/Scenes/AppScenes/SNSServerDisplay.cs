using UnityEngine;
using TMPro;
using Photon.Pun;

public class SNSServerDisplay : MonoBehaviour
{
    public TMP_Text displayText; // データを表示するTextMeshProUGUIコンポーネント

    private void Start()
    {

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles"))
        {
            displayText.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"];
        }
    }
}

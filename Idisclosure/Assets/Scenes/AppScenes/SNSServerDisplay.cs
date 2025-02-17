using UnityEngine;
using TMPro;
using Photon.Pun;

public class SNSServerDisplay : MonoBehaviour
{
    public TMP_Text displayText; // データを表示するTextMeshProUGUIコンポーネント

    private void Start()
    {
        // // BrowserSearch で保存されたデータを表示
        // if (!string.IsNullOrEmpty(BrowserSearch.searchData))
        // {
        //     displayText.text = $"公開されたデータ: {BrowserSearch.searchData}";
        //     Debug.Log($"[SNSServer] データ: {BrowserSearch.searchData} を表示しました。");
        // }
        // else
        // {
        //     displayText.text = "データがありません。";
        // }

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles"))
        {
            displayText.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"];
        }
    }
}

using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.EventSystems; // クリックイベントを使うために追加

public class Wifi1 : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Wifi1Display;

    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi1"))
        {
            Wifi1Display.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi1"];
        }
    }

    // テキストをクリックしたときに ":" の前のみコピー
    public void OnPointerClick(PointerEventData eventData)
    {
        string fullText = Wifi1Display.text;
        GUIUtility.systemCopyBuffer = CopyBeforeColon(fullText); // ":" の前をコピー
    }

    // ":" の前のみコピー
    string CopyBeforeColon(string text)
    {
        int index = text.IndexOf(':');
        if (index != -1)
        {
            return text.Substring(0, index).Trim(); // ":" の前の部分をコピー
        }
        return text; // ":" がない場合は全文コピー
    }

    // ":" の後のみコピー
    string CopyAfterColon(string text)
    {
        int index = text.IndexOf(':');
        if (index != -1)
        {
            return text.Substring(index + 1).Trim(); // ":" の後の部分をコピー
        }
        return text; // ":" がない場合は全文コピー
    }
}

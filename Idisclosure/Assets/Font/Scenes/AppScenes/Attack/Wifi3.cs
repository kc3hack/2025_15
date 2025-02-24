using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.EventSystems; // クリックイベントを使うために追加

public class Wifi3 : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Wifi1Display;

    void Update()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("WiFi3"))
        {
            Wifi1Display.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["WiFi3"];
        }
    }

    // クリックされたときにコロンの前か後をコピー
    public void OnPointerClick(PointerEventData eventData)
    {
        string fullText = Wifi1Display.text;
        
        // コロンの前のみコピーする場合
        GUIUtility.systemCopyBuffer = CopyBeforeColon(fullText);
        
        // コロンの後のみコピーする場合は以下のように切り替えます：
        // GUIUtility.systemCopyBuffer = CopyAfterColon(fullText);
    }

    // コロンの前のみコピー
    string CopyBeforeColon(string text)
    {
        int index = text.IndexOf(':');
        if (index != -1)
        {
            return text.Substring(0, index).Trim(); // コロンの前の部分をコピー
        }
        return text; // コロンがない場合は全文コピー
    }

    // コロンの後のみコピー
    string CopyAfterColon(string text)
    {
        int index = text.IndexOf(':');
        if (index != -1)
        {
            return text.Substring(index + 1).Trim(); // コロンの後の部分をコピー
        }
        return text; // コロンがない場合は全文コピー
    }
}

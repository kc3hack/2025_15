using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class CreateStoreWeb : MonoBehaviour
{
    public TMP_Text ShowBrowser;
    /*----------Reset時必要----------*/
    string showBrowser = "My Server\n" + "SNS Server\n";

    void Start()
    {
        // 起動してから1秒間隔でランダムを回す
        InvokeRepeating(nameof(VirusOO), 0f, 1f);
    
        /*----------判別しているプロパティをResetする、Reset時必要----------*/
        Hashtable Webs = new Hashtable { { "VirusOO", false } };
        PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
    }

    void VirusOO()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        // 1が出たらStoreWebを建ちあげる
        if (randomValue == 1)
        {
            // 判別しているプロパティをtrueにする
            Hashtable Webs = new Hashtable { { "VirusOO", true } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
            Debug.Log("Create VirusOO!!!!!!");
            // IPの生成処理忘れずに
        }
    }

    void Update()
    {
        /*----------VirusOO----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"])
        {
            if (!(showBrowser.Contains("VirusOO\n")))
            {
                // Browserに追加
                showBrowser += "VirusOO\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            showBrowser = showBrowser.Replace("VirusOO\n", "");
        }

        /*----------テキストに反映----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
        {
            ShowBrowser.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
        }
    }
}

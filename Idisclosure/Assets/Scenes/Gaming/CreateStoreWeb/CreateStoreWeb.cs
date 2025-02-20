using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class CreateStoreWeb : MonoBehaviour
{
    public TMP_Text ShowBrowser;
    /*----------Reset時必要----------*/
    string showBrowser = "SNS Server\n";

     void Start()
    {
        // 起動してから1秒間隔でランダムを回す
        InvokeRepeating(nameof(VirusOO), 0f, 1f);
        InvokeRepeating(nameof(SpareBattery), 0f, 1f);
        InvokeRepeating(nameof(SmallBattery), 0f, 1f);
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

    void SpareBattery()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        // 1が出たらStoreWebを建ちあげる
        if (randomValue == 1)
        {
            // 判別しているプロパティをtrueにする
            Hashtable Webs = new Hashtable { { "SpareBattery", true } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
            Debug.Log("Create SpareBattery!!!!!!");
            // IPの生成処理忘れずに
        }
        else if(randomValue == 0)
        {
            Debug.Log(".......");
        }
    }

    void SmallBattery()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 2);

        // 1が出たらStoreWebを建ちあげる
        if (randomValue == 1)
        {
            // 判別しているプロパティをtrueにする
            Hashtable Webs = new Hashtable { { "SamllBattery", true } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
            Debug.Log("Create SmallBattery!!!!!!");
            // IPの生成処理忘れずに
        }
        else if(randomValue == 0)
        {
            Debug.Log(".......");
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
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------SpareBattery----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"])
        {
            if (!(showBrowser.Contains("Spare Battery\n")))
            {
                // Browserに追加
                showBrowser += "Spare Battery\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            showBrowser = showBrowser.Replace("SpareBattery\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

         /*----------SmallBattery----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"])
        {
            if (!(showBrowser.Contains("Small Battery\n")))
            {
                // Browserに追加
                showBrowser += "Small Battery\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            showBrowser = showBrowser.Replace("SmallBattery\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------テキストに反映----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
        {
            ShowBrowser.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
        }
    }
}

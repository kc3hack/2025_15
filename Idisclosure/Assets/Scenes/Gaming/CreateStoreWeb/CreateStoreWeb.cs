using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;
using System.Collections.Generic;


public class CreateStoreWeb : MonoBehaviour
{
    public TMP_Text ShowBrowser;
    /*----------Reset時必要----------*/
    string showBrowser = "SNS Server\n";

    void Start()
    {
        // 起動してから1秒間隔でランダムを回す
        InvokeRepeating(nameof(VirusOO), 0f, 1f);
    }

    void VirusOO()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 2);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "VirusOO", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("VirusOO");
                Debug.Log("Create VirusOO!!!!!!");
            }
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

        /*----------テキストに反映----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
        {
            ShowBrowser.text = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
        }
    }

    public void MakeIP(string AppName)
    {
        // IPアドレスのリストを取得する
        List<string> IPList = new List<string>();
        string NewIP = "";
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPList"))
        {
            IPList = new List<string>(PhotonNetwork.CurrentRoom.CustomProperties["IPList"].ToString().Split(','));
        }

        // 一意性の確認と追加
        while (true)
        {
            // IPを生成
            int first = UnityEngine.Random.Range(0, 256);
            int second = UnityEngine.Random.Range(0, 256);
            int third = UnityEngine.Random.Range(0, 256);
            int fourth = UnityEngine.Random.Range(0, 256);

            NewIP = $"{first}.{second}.{third}.{fourth}";
            
            // 一意性が保証されたら追加
            if (!(IPList.Contains(NewIP)))
            {
                IPList.Add(NewIP);
                break;
            }
        }

        // サーバー上に保存
        Hashtable props = new Hashtable
        {
            { "IPList", string.Join(",", IPList) },
            { AppName + "IP", NewIP }
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
        Debug.Log("IPList is saved! : " + string.Join(",", IPList));
    }
}

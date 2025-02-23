using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;
using System.Collections.Generic;


public class NewCreateStoreWeb : MonoBehaviour
{
    public TMP_Text ShowBrowser;
    int randomValue = 0;
    string[] Webs = {"VirusOO", "SpareBatteryPC", "SpareBatteryMyServer", "SmallBatteryPC", "SmallBatteryMyServer", "IPBST1", "IPBST2", "IPBST3", "DoSTool","CrackTool"};
    /*----------Reset時必要----------*/
    string showBrowser = "SNS Server\n";

     void Start()
    {
        // 起動してから1秒間隔でランダムを回す
        InvokeRepeating(nameof(RandomCreator), 0f, 1f);
    }

    void RandomCreator()
    {
        randomValue = Random.Range(0, 10);
        for (int i = 0; i < Webs.Length; i++)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(Webs[i]) && !((bool)PhotonNetwork.CurrentRoom.CustomProperties[Webs[i]]))
            {
                if (randomValue == i)
                {
                    // 判別しているプロパティをtrueにする
                    Hashtable props = new Hashtable { { Webs[i], true } };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(props);
                    MakeIP(Webs[i]);
                    Debug.Log("Create" + Webs[i]);
                    if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
                    {
                        showBrowser = (string)PhotonNetwork.CurrentRoom.CustomProperties["BrowserDisplay"];
                    }
                    if (!(showBrowser.Contains(Webs[i] + "\n")))
                    {
                        // Browserに追加
                        showBrowser += Webs[i] + "\n";
                        Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                        PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
                    }
                }
            }
        }
    }

    void Update()
    {
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


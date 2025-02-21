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
        InvokeRepeating(nameof(SpareBattery), 0f, 1f);
        InvokeRepeating(nameof(SpareBatteryMyServer), 0f, 1f);
        InvokeRepeating(nameof(SmallBattery), 0f, 1f);
        InvokeRepeating(nameof(SmallBatteryMyServer), 0f, 1f);
        InvokeRepeating(nameof(IPBST1), 0f, 1f);
        InvokeRepeating(nameof(IPBST2), 0f, 1f);
        InvokeRepeating(nameof(IPBST3), 0f, 1f);
        InvokeRepeating(nameof(Dos), 0f, 1f);
    }


    void VirusOO()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

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

    void SpareBattery()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "SpareBattery", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("SpareBattery");
                Debug.Log("Create SpareBattery!!!!!!");
            }
        }
    }

    void SpareBatteryMyServer()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServer") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServer"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "SpareBatteryMyServer", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("SpareBatteryMyServer");
                Debug.Log("Create SpareBatteryMyServer!!!!!!");
            }
        }
    }

    void SmallBattery()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "SmallBattery", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("SmallBattery");
                Debug.Log("Create SmallBattery!!!!!!");
            }
        }
    }

    void SmallBatteryMyServer()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServer") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServer"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "SmallBatteryMyServer", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("SmallBatteryMyServer");
                Debug.Log("Create SmallBatteryMyServer!!!!!!");
            }
        }
    }

    void IPBST1()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST1") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST1"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "IPBST1", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("IPBST1");
                Debug.Log("Create IPBST1!!!!!!");
            }
        }
    }

    void IPBST2()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST2") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST2"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "IPBST2", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("IPBST2");
                Debug.Log("Create IPBST2!!!!!!");
            }
        }
    }

    void IPBST3()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST3") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST3"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "IPBST3", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("IPBST3");
                Debug.Log("Create IPBST3!!!!!!");
            }
        }
    }

     void Dos()
    {
        // 単位秒数あたりの確率
        int randomValue = Random.Range(0, 100);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Dos") && !((bool)PhotonNetwork.CurrentRoom.CustomProperties["Dos"]))
        {
            // 1が出たらStoreWebを建ちあげる
            if (randomValue == 1)
            {
                // 判別しているプロパティをtrueにする
                Hashtable Webs = new Hashtable { { "Dos", true } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);
                MakeIP("Dos");
                Debug.Log("Create Dos!!!!!!");
            }
        }
    }
    void Update()
    {
        /*----------VirusOO----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
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
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("VirusOO\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------SpareBattery----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("Spare Battery(PC)\n")))
            {
                // Browserに追加
                showBrowser += "Spare Battery(PC)\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("Spare Battery(PC)\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------SpareBatteryMyServer----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("Spare Battery(Server)\n")))
            {
                // Browserに追加
                showBrowser += "Spare Battery(Server)\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("Spare Battery(Server)\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

         /*----------SmallBattery----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("Small Battery(PC)\n")))
            {
                // Browserに追加
                showBrowser += "Small Battery(PC)\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("Small Battery(PC)\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------SmallBatteryMyServer----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBatteryMyServer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBatteryMyServer"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("Small Battery(Server)\n")))
            {
                // Browserに追加
                showBrowser += "Small Battery(Server)\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("Small Battery(Server)\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------IPBST1----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST1") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST1"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("IPBST1\n")))
            {
                // Browserに追加
                showBrowser += "IPBST1\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("IPBST1\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------IPBST2----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST2") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST2"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("IPBST2\n")))
            {
                // Browserに追加
                showBrowser += "IPBST2\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("IPBST2\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------IPBST3----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("IPBST3") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["IPBST3"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("IPBST3\n")))
            {
                // Browserに追加
                showBrowser += "IPBST3\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("IPBST3\n", "");
            Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
        }

        /*----------Dos----------*/
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Dos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Dos"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            if (!(showBrowser.Contains("DoS Tool\n")))
            {
                // Browserに追加
                showBrowser += "DoS Tool\n";
                Hashtable ShowDisplay = new Hashtable { { "BrowserDisplay", showBrowser } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ShowDisplay);
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("BrowserDisplay"))
            {
                showBrowser = PhotonNetwork.CurrentRoom.CustomProperties("BrowserDisplay");
            }
            showBrowser = showBrowser.Replace("DoS Tool\n", "");
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


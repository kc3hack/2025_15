using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;

public class Start5m : MonoBehaviourPunCallbacks
{
    private int totalPlayers;
    private float seconds = 5*60;

    void Awake()
    {
        // シーン同期を有効にする
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void StartByMaster()
    {
        // 判別用プロパティをResetする
        Hashtable Webs = new Hashtable 
        { 
            { "VirusOO", false },
            {"FishingVirusOO", false},
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(Webs);

        Hashtable props = new Hashtable
        {
            { "FishingNow", false},
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        //Masterが押しているかどうかのチェック
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogWarning("スタートボタンはマスタークライアントのみが押せます。");
            return;
        }

        // 一応Playerの人数を把握
        totalPlayers = PhotonNetwork.PlayerList.Length;

        // 1ゲーム何分のモードかを保存
        SaveTime();

        // 全員で一気にシーン遷移
        PhotonNetwork.LoadLevel("Gaming");

        // IPListを生成
        MakeIPList();

    }

    // プレイヤーに番号を割り振る
    private void SaveTime()
    {
        // プレイ時間を保存
        Hashtable time = new Hashtable
        {
            { "Time", seconds }
        };

        // 保存
        PhotonNetwork.CurrentRoom.SetCustomProperties(time);
    }

    /*----------IPアドレスを生成----------*/
    private const byte SendIPs = 2;
    public void MakeIPList()
    {
        List<string> IPList = new List<string>();
        int NumberOfPlayer = PhotonNetwork.PlayerList.Length;

        while (IPList.Count < NumberOfPlayer * 2 + 1)
        {
            // IPを生成
            int first = UnityEngine.Random.Range(0, 256);
            int second = UnityEngine.Random.Range(0, 256);
            int third = UnityEngine.Random.Range(0, 256);
            int fourth = UnityEngine.Random.Range(0, 256);

            string NewIP = $"{first}.{second}.{third}.{fourth}";
            
            // 一意性が保証されたら追加
            if (!(IPList.Contains(NewIP)))
            {
                IPList.Add(NewIP);
            }
        }
            // サーバー上に保存
            Hashtable props = new Hashtable
            {
                { "IPList", string.Join(",", IPList) },
                { "SNSServerIP", IPList[0] }
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(props);
            Debug.Log("IPList is saved! : " + string.Join(",", IPList));

        // プレイヤーに配布
        int i = 1;
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            object[] data = new object[] { IPList[i], IPList[i + 1] };

            RaiseEventOptions options = new RaiseEventOptions
            {
                TargetActors = new int[] { player.ActorNumber }
            };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SendIPs, data, options, sendOptions);
            i += 2;
        }
    }
}



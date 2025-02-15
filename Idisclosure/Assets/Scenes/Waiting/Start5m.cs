using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Start5m : MonoBehaviourPunCallbacks
{
    private int totalPlayers;
    private int minutes = 5;

    void Awake()
    {
        // シーン同期を有効にする
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void StartByMaster()
    {
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

    }

    // プレイヤーに番号を割り振る
    private void SaveTime()
    {
        // プレイ時間を保存
        Hashtable time = new Hashtable
        {
            { "Time", minutes }
        };

        // 保存
        PhotonNetwork.CurrentRoom.SetCustomProperties(time);
    }
}



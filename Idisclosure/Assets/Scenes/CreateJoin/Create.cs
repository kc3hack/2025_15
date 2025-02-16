using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;//追加

public class RoomCreator : MonoBehaviourPunCallbacks
{
    private bool isConnectedToMaster = false; // Masterサーバー接続チェック
    // public TMP_Text playerListText; // プレイヤーリストを表示するためのUI
    public TMP_InputField roomNameInputField; // ルーム名を入力するためのUI

    void Start()
    {
        // プレイヤー名を PlayerPrefs から取得し、Photon の NickName に設定
        string playerName = PlayerPrefs.GetString("PlayerName", "Guest" + Random.Range(1000, 9999));
        PhotonNetwork.NickName = playerName;

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings(); // Photonに接続
            Debug.Log($"Photonに接続中... プレイヤー名: {PhotonNetwork.NickName}");
        }
    }

    public override void OnConnectedToMaster()
    {
        isConnectedToMaster = true;
        Debug.Log("Photonに接続完了！ マスターサーバーに接続しました。");
    }

    public void CreateRoom()
    {
        if (!isConnectedToMaster)
        {
            Debug.LogError("Photonにまだ接続されていません。接続が完了するまで待ってください。");
            return;
        }

        string roomName = roomNameInputField.text.Trim(); // 入力フィールドからルーム名を取得
        if (string.IsNullOrEmpty(roomName))
        {
            Debug.LogError("ルーム名を入力してください。");
            return;
        }

        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4, // ルームの最大人数
            IsVisible = true,
            IsOpen = true
        };

        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log($"ルーム '{roomName}' を作成中...");

        SceneManager.LoadScene("Waiting");//シーン遷移
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"ルーム作成失敗: {message}");
    }
}

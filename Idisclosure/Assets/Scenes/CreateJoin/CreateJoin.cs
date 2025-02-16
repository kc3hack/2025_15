using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateJoin : MonoBehaviourPunCallbacks
{
    private bool isConnectedToMaster = false;
    public TMP_InputField RoomName;

    void Start()
    {
        // プレイヤー名を設定（未設定ならランダム名）
        string playerName = PlayerPrefs.GetString("PlayerName", "Guest" + Random.Range(1000, 9999));
        PhotonNetwork.NickName = playerName;

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log($"Photonに接続中... プレイヤー名: {PhotonNetwork.NickName}");
        }
    }

    public override void OnConnectedToMaster()
    {
        isConnectedToMaster = true;
        Debug.Log("Photonに接続完了！ マスターサーバーに接続しました。");
    }

    public void JoinRoom()
    {
        if (!isConnectedToMaster)
        {
            Debug.LogError("Photonにまだ接続されていません。接続が完了するまで待ってください。");
            return;
        }

        string roomName = RoomName.text;
        if (string.IsNullOrEmpty(roomName))
        {
            Debug.LogError("ルーム名を入力してください。");
            return;
        }

        // ルームに参加を試みる
        PhotonNetwork.JoinRoom(roomName);
        Debug.Log($"ルーム '{roomName}' に参加中...");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームに参加できなかった場合、新しいルームを作成
        Debug.LogWarning($"ルーム '{RoomName.text}' への参加に失敗: {message}");

        string roomName = RoomName.text;
        if (string.IsNullOrEmpty(roomName))
        {
            roomName = "Room_" + Random.Range(1000, 9999); // ランダムなルーム名を生成
        }

        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 6,
            IsVisible = true,
            IsOpen = true
        };

        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log($"新しいルーム '{roomName}' を作成中...");
    }

    public override void OnJoinedRoom()
    {
        // ルームに参加成功した場合の処理
        Debug.Log("ルームに参加成功！");
        SceneManager.LoadScene("Waiting"); // "Waiting"シーンに遷移
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ルーム作成に失敗した場合の処理（例えば同名のルームがすでに存在する場合）
        Debug.LogError($"ルーム作成失敗: {message}");
    }
}

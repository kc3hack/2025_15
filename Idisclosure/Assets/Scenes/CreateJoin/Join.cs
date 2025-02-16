using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomJoiner : MonoBehaviourPunCallbacks
{
    private bool isConnectedToMaster = false;
    public TMP_InputField roomNameInputField;

    void Start()
    {
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

        string roomName = roomNameInputField.text.Trim();
        if (string.IsNullOrEmpty(roomName))
        {
            Debug.LogError("ルーム名を入力してください。");
            return;
        }

        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 4, IsVisible = true, IsOpen = true }, TypedLobby.Default);
        Debug.Log($"ルーム '{roomName}' に参加中...");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに参加成功！");
        SceneManager.LoadScene("Waiting");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"ルーム参加失敗: {message}");
    }
}


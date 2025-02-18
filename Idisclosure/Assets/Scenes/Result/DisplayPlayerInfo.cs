using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;

public class DisplayPlayerInfo : MonoBehaviourPunCallbacks
{
    // UI テキストコンポーネント
    public TMP_Text playerInfoText;

    private void Start()
    {
        // プレイヤーの情報を取得して表示
        DisplayPlayerInfoOnUI();
    }

    // プレイヤーの情報をUIに表示
    void DisplayPlayerInfoOnUI()
    {
        // プレイヤー情報をリストに格納
        List<PlayerInfo> playerList = new List<PlayerInfo>();

        // 自分をリストに追加
        playerList.Add(GetPlayerInfo(PhotonNetwork.LocalPlayer));

        // 他のプレイヤーの情報をリストに追加
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player != PhotonNetwork.LocalPlayer)
            {
                playerList.Add(GetPlayerInfo(player));
            }
        }

        // BuhiCoin の降順でソート
        playerList = playerList.OrderByDescending(p => p.buhiCoin).ToList();

        // 表示用テキストをリセット
        if (playerInfoText != null)
        {
            playerInfoText.text = "";
        }

        // ソートされたリストを表示
        foreach (var playerInfo in playerList)
        {
            if (playerInfoText != null)
            {
                playerInfoText.text += $"{playerInfo.playerName}: BuhiCoin = {playerInfo.buhiCoin}\n";
            }
        }
    }

    // プレイヤーの情報を取得
    PlayerInfo GetPlayerInfo(Player player)
    {
        string playerName = "Unknown";
        int buhiCoin = 0;

        playerName = PhotonNetwork.NickName;

        if (player.CustomProperties.ContainsKey("BuhiCoin"))
        {
            buhiCoin = int.Parse(player.CustomProperties["BuhiCoin"].ToString());
        }

        return new PlayerInfo { playerName = playerName, buhiCoin = buhiCoin };
    }

    // プレイヤー情報を保持する構造体
    public struct PlayerInfo
    {
        public string playerName;
        public int buhiCoin;
    }
}

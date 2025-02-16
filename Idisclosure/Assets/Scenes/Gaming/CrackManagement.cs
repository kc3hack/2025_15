using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class CrackManagement : MonoBehaviourPunCallbacks
{
    public TMP_Text GuessSecretID;

    // イベントコードを定義
    private const byte CrackedSecretID = 1;

    void Start()
    {
        CheckOrSafe();
    }

    // 全員のパスワードをコンソールで確認
    void CheckOrSafe()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("SecretID"))
            {
                string playerSecretID = ((string)player.CustomProperties["SecretID"]).Replace("\u200B", "");
                Debug.Log(player.NickName + ":" + playerSecretID);
            }
        }
    }

    public void CrackFunction()
    {
        // IDが予測されていなければ中止
        if (GuessSecretID == null)
        {
            Debug.LogError("GuessSecretID is nothing!");
            return;
        }

        // ユーザーがGuessIDに入力したパスワードを取得
        string guessedSecretID = GuessSecretID.text.Replace("\u200B", "");

        // プレイヤーのパスワードが一致するか確認
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("SecretID"))
            {
                // 一人のプレイヤーのSecretIDを取得
                string playerSecretID = ((string)player.CustomProperties["SecretID"]).Replace("\u200B", "");

                if ((string)guessedSecretID == (string)playerSecretID)
                {
                    // messageの定義
                    string message = "Your SecretID is cracked!";
                    // 送信先の定義
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { player.ActorNumber } };
                    // オプションの定義
                    SendOptions sendOptions = new SendOptions { Reliability = true };
                    // 送信する
                    PhotonNetwork.RaiseEvent(CrackedSecretID, message, raiseEventOptions, sendOptions);
                    return;
                }
            }
        }
    }
}


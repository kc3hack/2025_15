using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class CountdownTimerWithCover : MonoBehaviourPunCallbacks
{
    // タイマー設定
    public float timeRemaining = 90.0f;
    public TextMeshProUGUI timerText;

    // イベントコード
    private const byte EventCode = 1;
    private bool isNotified = false;

    // 表示する文字列の定義
    string snsPlofiles = "";

    private void Update()
    {
        // カウントダウン
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0) timeRemaining = 0;

        // 表示を更新
        UpdateTimerDisplay();

        // 残り 1 分 になったら通知
        if (timeRemaining <= 60 && !isNotified)
        {
            isNotified = true;

            // プレイヤーごとのデータを取得
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Age"))
                {
                    // CustomProperties から Birthday を取得
                    int age = (int)player.CustomProperties["Age"];
                    snsPlofiles += (player.NickName + " → " + age + "years old" + "\n");
                }
            }

            // Room Custom Properties に保存
            if (!string.IsNullOrEmpty(snsPlofiles))
            {
                Hashtable plofiles = new Hashtable {
                    { "Plofiles", snsPlofiles }
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(plofiles);
                Debug.Log("[保存] Plofiles: " + snsPlofiles);
            }
        }
    }

    // タイマーの表示を更新
    private void UpdateTimerDisplay()
    {
        if (timeRemaining > 60)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = timeRemaining % 60;
            timerText.text = minutes + ":" + seconds.ToString("F0");
        }
        else
        {
            timerText.text = timeRemaining.ToString("F1");
        }
    }

}

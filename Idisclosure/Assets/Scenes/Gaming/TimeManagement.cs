using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class CountdownTimerWithCover : MonoBehaviourPunCallbacks, IOnEventCallback
{
    // タイマー設定
    public float timeRemaining = 90.0f;
    public TextMeshProUGUI timerText;

    // イベントコード
    private const byte EventCode = 1;
    private bool isNotified = false;

    // 保存するデータのキー
    private string dataKey = "YourDataKey";
    private string savedData;

    // 表示する文字列の定義
    string snsPlofiles = "";

    private void Start()
    {
        // PlayerPrefs からデータを取得
        savedData = PlayerPrefs.GetString(dataKey, "データがありません");

        // 取得したデータをリモートに保存（Room Custom Properties を利用）
        ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
        customProperties[dataKey] = savedData;
        PhotonNetwork.CurrentRoom.SetCustomProperties(customProperties);

        Debug.Log($"[保存] データ: {savedData} をリモートに保存しました。");
    }

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
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Name"))
                {
                    string playerName = ((string)player.CustomProperties["Name"]).Replace("\u200B", "");
                    snsPlofiles += (playerName + "\n");
                    Hashtable plofiles = new Hashtable {
                        {"Plofiles",snsPlofiles}
                    };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(plofiles);
                }
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
            timerText.text = minutes + ":" + seconds.ToString("F1") + "秒";
        }
        else
        {
            timerText.text = timeRemaining.ToString("F1") + "秒";
        }
    }

    // 全員に通知
    public void SendEvent()
    {
        string message = $"データ: {savedData}";

        // 全員に通知
        RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };

        // イベントを送信
        PhotonNetwork.RaiseEvent(EventCode, message, options, sendOptions);

        Debug.Log($"[通知] {message}");
    }

    // イベントを受信
    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == EventCode)
        {
            string receivedMessage = (string)photonEvent.CustomData;
            Debug.Log($"[受信] メッセージ: {receivedMessage}");
            timerText.text = receivedMessage;
        }
    }

    public override void OnEnable() { PhotonNetwork.AddCallbackTarget(this); }
    public override void OnDisable() { PhotonNetwork.RemoveCallbackTarget(this); }
}

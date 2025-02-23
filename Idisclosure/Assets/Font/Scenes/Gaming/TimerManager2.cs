using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic; // System.Collections.Generic 名前空間をインポート
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TimerController: MonoBehaviourPunCallbacks
{
    public static TimerController Instance; // シングルトンインスタンス

    private double timeLimit;
    private double timeRemaining;
    private double startTime;
    private bool isTimeInitialized = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は破棄
        }
    }

    private void Update()
    {
        /*----------時間関連情報取得処理----------*/
        if (!isTimeInitialized)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Time") &&
                PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("StartTime"))
            {
                timeLimit = (double)PhotonNetwork.CurrentRoom.CustomProperties["Time"];
                startTime = (double)PhotonNetwork.CurrentRoom.CustomProperties["StartTime"];
                isTimeInitialized = true;
                Debug.Log("Time: " + timeLimit);
                Debug.Log("StartTime: " + startTime);
            }
            else
            {
                Debug.LogWarning("Time または StartTime がまだ設定されていません。");
                return; // まだ取得できていないので処理しない
            }
        }

        /*----------残り時間計算処理----------*/
        double elapsedTime = Time.time - startTime;
        timeRemaining = timeLimit - elapsedTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            TimeUp(); // 時間切れ時の処理を実行
        }

        // ここにタイマーの値をカスタムプロパティに保存するコードを組み込む
        if (PhotonNetwork.IsMasterClient) // マスタークライアントのみが値を更新
        {
            Hashtable props = new Hashtable();
            props["TimerValue"] = timeRemaining;
            PhotonNetwork.CurrentRoom.SetCustomProperties(props);
        }

        // 送信するテキストを格納する変数
        HashSet<string> existingProfiles = new HashSet<string>();
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles"))
        {
            string currentProfiles = (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"];
            string[] existingEntries = currentProfiles.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in existingEntries)
            {
                existingProfiles.Add(entry);
            }
        }

        List<string> newProfiles = new List<string>();

        if (timeRemaining <= 270)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.ContainsKey("Birthyear"))
                {
                    string birthyear = (string)player.CustomProperties["Birthyear"];
                    string profileEntry = player.NickName + " → " + birthyear + " years born";
                    if (!existingProfiles.Contains(profileEntry))
                    {
                        newProfiles.Add(profileEntry);
                    }
                }
            }
        }

        // ... (他のプレイヤー情報収集コード)

        // 既に送信されていないデータがあれば追加
        if (newProfiles.Count > 0)
        {
            string newProfilesText = string.Join("\n", newProfiles);
            string updatedProfiles = (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Plofiles")
                ? (string)PhotonNetwork.CurrentRoom.CustomProperties["Plofiles"] + "\n"
                : "") + newProfilesText;

            Hashtable profiles = new Hashtable { { "Plofiles", updatedProfiles } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(profiles);
            Debug.Log("[保存] Plofiles: " + newProfilesText);
        }
    }

    private void TimeUp()
    {
        Debug.Log("Time Up!");
        // 時間切れ時の処理をここに記述 (例: 結果表示、ゲーム終了など)
    }
}

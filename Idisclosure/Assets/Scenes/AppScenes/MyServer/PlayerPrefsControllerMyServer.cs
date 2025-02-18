using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine;
using TMPro;

public class PlayerPrefsControllerMyServer : MonoBehaviourPunCallbacks
{
    public TMP_Text BuhiCoinText;
    public TMP_Text BatteryMyServerText;

    void Update()
    {
        // 自分の情報をPlayerPrefsから取得
        string name = PlayerPrefs.GetString("Name", "name").Replace("\u200B", "");
        string birth = PlayerPrefs.GetString("Birth", "2000/0101").Replace("\u200B", "");
        string secretID = PlayerPrefs.GetString("SecretID", "secret").Replace("\u200B", "");
        string buhiCoin = PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", "");
        string battery = PlayerPrefs.GetString("Battery", "0").Replace("\u200B", "");
        string batteryMyServer = PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", "");

        // UIに表示
        if (BuhiCoinText != null)
        {
            BuhiCoinText.text = buhiCoin;
        }
        if (BatteryMyServerText != null)
        {
            BatteryMyServerText.text = batteryMyServer;
        }

        // カスタムプロパティに設定
        Hashtable props = new Hashtable();
        props["Name"] = name;
        props["Birth"] = birth;
        props["SecretID"] = secretID;
        props["BuhiCoin"] = buhiCoin;
        props["Battery"] = battery;
        props["BatteryMyServer"] = batteryMyServer;

        // Photonのネットワークに保存
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }
}


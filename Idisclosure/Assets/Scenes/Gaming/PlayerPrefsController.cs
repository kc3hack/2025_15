using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine;
using TMPro;

public class PlayerPrefsController : MonoBehaviourPunCallbacks
{
    public TMP_Text BuhiCoinText;
    public TMP_Text BatteryText;

    void Start()
    {
        // 自分の情報を PlayerPrefs から取得
        string playerName = PlayerPrefs.GetString("Name", "name").Replace("\u200B", "");
        string birth = PlayerPrefs.GetString("Birth", "2000/0101").Replace("\u200B", "");
        string secretID = PlayerPrefs.GetString("SecretID", "secret").Replace("\u200B", "");
        string buhiCoin = PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", "");
        string battery = PlayerPrefs.GetString("Battery", "0").Replace("\u200B", "");
        string birthday = PlayerPrefs.GetString("Birthday", "0101").Replace("\u200B", "");
        string birthyear = PlayerPrefs.GetString("Birthyear", "2000").Replace("\u200B", "");
        int age = PlayerPrefs.GetInt("Age", 0);

        // UI に表示
        if (BuhiCoinText != null)
        {
            BuhiCoinText.text = buhiCoin;
        }
        if (BatteryText != null)
        {
            BatteryText.text = battery;
        }

        // カスタムプロパティに設定
        Hashtable props = new Hashtable();
        props["Name"] = playerName;
        props["Birth"] = birth;
        props["SecretID"] = secretID;
        props["BuhiCoin"] = buhiCoin;
        props["Battery"] = battery;
        props["Birthday"] = birthday;
        props["Birthyear"] = birthyear;
        props["Age"] = age;

        // Photon のネットワークに保存
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }
}

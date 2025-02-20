using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerPrefsController : MonoBehaviourPunCallbacks
{
    public TMP_Text BuhiCoinText;
    public TMP_Text BatteryText;

    void Update()
    {
        // 自分の情報をPlayerPrefsから取得
        string name = PlayerPrefs.GetString("Name", "name").Replace("\u200B", "");
        string birth = PlayerPrefs.GetString("Birth", "2000/0101").Replace("\u200B", "");
        string secretID = PlayerPrefs.GetString("SecretID", "secret").Replace("\u200B", "");
        string buhiCoin = PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", "");
        string battery = PlayerPrefs.GetString("Battery", "0").Replace("\u200B", "");
        string birthday = PlayerPrefs.GetString("Birthday", "0101").Replace("\u200B", "");
        string birthyear = PlayerPrefs.GetString("Birthyear", "2000").Replace("\u200B", "");
        int age = PlayerPrefs.GetInt("Age", 00);

        // UIに表示
        if (BuhiCoinText != null)
        {
            BuhiCoinText.text = buhiCoin;
        }
        if (BatteryText != null)
        {
            if (int.Parse(battery) > 100)
            {
                battery = "100";
                BatteryText.text = battery;
            }
            else if (int.Parse(battery) <= 0)
            {
                battery = "0";
                BatteryText.text = battery;
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                BatteryText.text = battery;
            }
            
        }

        // カスタムプロパティに設定
        Hashtable props = new Hashtable();
        props["Name"] = name;
        props["Birth"] = birth;
        props["SecretID"] = secretID;
        props["BuhiCoin"] = buhiCoin;
        props["Battery"] = battery;
        props["Birthyear"] = birthyear;
        props["Age"] = age;

        // Photonのネットワークに保存
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }
}


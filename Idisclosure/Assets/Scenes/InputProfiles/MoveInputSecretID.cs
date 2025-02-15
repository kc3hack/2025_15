using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveInputSecretID : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Birth;

    public void SaveAndNext()
    {
        // Inputの文字列を各変数に代入
        string playerName = Name.text;
        string playerBirth = Birth.text;

        // PlayerPrefsに名前を保存
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetString("PlayerBirth", playerBirth);
        //保存する
        PlayerPrefs.Save();
        //Logをコンソールに出す。
        Debug.Log("Player Name Saved: " + playerName);
        Debug.Log("Player Birth Saved: " + playerBirth);

        // シーン遷移
        SceneManager.LoadScene("InputSecretID");
    }
}

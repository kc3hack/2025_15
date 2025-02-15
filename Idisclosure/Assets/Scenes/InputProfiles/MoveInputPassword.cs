using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveInputPassword : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Birthday;

    public void SaveAndNext()
    {
        // Inputの文字列を各変数に代入
        string playerName = Name.text;
        string playerBirth = Birthday.text;

        // PlayerPrefsに名前を保存
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetString("PlayerBirthday", playerBirth);
        //保存する
        PlayerPrefs.Save();
        //Logをコンソールに出す。
        Debug.Log("Player Name Saved: " + playerName);
        Debug.Log("Player Birthday Saved: " + playerBirth);

        // シーン遷移
        SceneManager.LoadScene("InputPassword");
    }
}

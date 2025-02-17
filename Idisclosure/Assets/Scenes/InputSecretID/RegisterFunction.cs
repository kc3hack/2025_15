using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RegisterFunction : MonoBehaviour
{
    public TMP_Text SecretID;

    public void SaveAndNext()
    {
        string secret = SecretID.text;

        // PlayerPrefsに名前を保存
        PlayerPrefs.SetString("SecretID", secret);
        PlayerPrefs.SetString("Battery", "100");
        //保存する
        PlayerPrefs.Save();
        //Logをコンソールに出す。
        Debug.Log("Secret ID Saved: " + secret);

        // シーン遷移
        SceneManager.LoadScene("CreateJoin");
    }
}



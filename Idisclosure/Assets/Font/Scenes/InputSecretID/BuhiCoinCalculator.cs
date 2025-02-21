using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class BuhiCoinCalculator : MonoBehaviour
{
    public TMP_Text ShowBuhiCoin;
    public TMP_Text EnteredSecretID;
    public TMP_Text warningText; // 追加: 警告テキスト
    public Button registerButton; // 追加: 登録ボタン

    public void GetBuhiCoin()
    {
        string PlayerName = PlayerPrefs.GetString("Name", "Guest").Replace("\u200B", "");
        string PlayerBirth = PlayerPrefs.GetString("Birth", "2000/0101").Replace("\u200B", "");

        if (!PlayerBirth.Contains("/"))
        {
            Debug.LogError("Invalid Birth format: " + PlayerBirth);
            return;
        }

        string PlayerBirthday = PlayerBirth.Substring(PlayerBirth.IndexOf("/") + 1);
        string PlayerBirthyear = PlayerBirth.Substring(0, PlayerBirth.IndexOf("/"));
        int BuhiCoinNow = 0;
        int age = 0;
        string SecretID = EnteredSecretID.text.Replace("\u200B", "");

        Debug.Log(PlayerName.Length);
        Debug.Log(PlayerName);
        bool isIncludeName = false;
        bool isIncludeBirthday = false;
        bool isIncludeBirthyear = false;
        Debug.Log("Length...??" + SecretID.Length);

        /*----------点数計算----------*/
        if (SecretID.Contains(PlayerName))
        {
            BuhiCoinNow += 500;
            isIncludeName = true;
        }
        if (SecretID.Contains(PlayerBirthday))
        {
            BuhiCoinNow += 400;
            isIncludeBirthday = true;
        }
        if (SecretID.Contains(PlayerBirthyear))
        {
            BuhiCoinNow += 300;
            isIncludeBirthyear = true;
        }

        /*----------OtherWords検査----------*/
        int LengthNow = SecretID.Length;
        if (isIncludeName)
        {
            LengthNow -= PlayerName.Length;
            Debug.Log("LengthNow: " + LengthNow);
        }
        if (isIncludeBirthday)
        {
            LengthNow -= PlayerBirthday.Length;
            Debug.Log("LengthNow: " + LengthNow);
        }
        if (isIncludeBirthyear)
        {
            LengthNow -= PlayerBirthyear.Length;
            Debug.Log("LengthNow: " + LengthNow);
        }

        /*----------OtherWords計算結果----------*/
        BuhiCoinNow -= LengthNow * 100;

        // ShowBuhiCoinにBuhiCoinの結果を渡す
        ShowBuhiCoin.text = BuhiCoinNow.ToString();

        /*----------年齢計算----------*/
        try
        {
            // PlayerBirthyear と PlayerBirthday を使用して DateTime を生成
            string fullBirthDate = PlayerBirthyear + "/" + PlayerBirthday;
            DateTime birthDate = DateTime.ParseExact(fullBirthDate, "yyyy/MMdd", null);

            // 現在の日付を取得
            DateTime today = DateTime.Today;

            // 年齢を計算
            age = today.Year - birthDate.Year;
            if (today < birthDate.AddYears(age)) age--;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error in age calculation: " + ex.Message);
        }

        // --- 追加部分 ---
        if (BuhiCoinNow < 0)  // ScoreNow → BuhiCoinNow に修正
        {
            // マイナスの時、警告文を表示してボタンを無効化
            warningText.text = "Buhicoin is negative";
            warningText.gameObject.SetActive(true);
            registerButton.interactable = false;
        }
        else
        {
            // マイナスでない時、警告文を非表示にしてボタンを有効化
            warningText.text = "";
            warningText.gameObject.SetActive(false);
            registerButton.interactable = true;
        }

        // PlayerPrefsに保存
        PlayerPrefs.SetString("Birthday", PlayerBirthday);
        PlayerPrefs.SetString("Birthyear", PlayerBirthyear);
        PlayerPrefs.SetString("BuhiCoin", BuhiCoinNow.ToString());
        PlayerPrefs.SetInt("Age", age);
        PlayerPrefs.Save();
    }
}



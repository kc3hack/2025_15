using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class BuhiCoinCalc : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text EnteredPassword;

    // 警告文のテキスト
    public TMP_Text warningText;

    // Register ボタン
    public Button registerButton;

    public void ScoreManager()
    {//関数名
        string PlayerName = PlayerPrefs.GetString("PlayerName", "Guest").Replace("\u200B", "");
        string PlayerBirthday = PlayerPrefs.GetString("PlayerBirthday", "0101").Replace("\u200B", "");
        int ScoreNow = 0;//パスワードに関するポイントの初期値を設定
        string Password = EnteredPassword.text.Replace("\u200B", "");//要素を取得

        Debug.Log(PlayerName.Length);
        Debug.Log(PlayerName);
        bool isIncludeName = false;
        bool isIncludeBirthday = false;
        Debug.Log("Length...??" + Password.Length);
        if (Password.Contains(PlayerName))
        {//名前が含まれていたら+1点
            ScoreNow += 500;
            isIncludeName = true;
        }
        if (Password.Contains(PlayerBirthday))
        {
            ScoreNow += 300;
            isIncludeBirthday = true;
        }

        int LengthNow = Password.Length;
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
        ScoreNow -= LengthNow * 100;

        score.text = ScoreNow.ToString();

        // PlayerPrefsに名前を保存
        PlayerPrefs.SetString("BuhiCoin", ScoreNow.ToString());
        //保存する
        PlayerPrefs.Save();

        // --- 追加部分 ---
        if (ScoreNow < 0)
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
    }
}

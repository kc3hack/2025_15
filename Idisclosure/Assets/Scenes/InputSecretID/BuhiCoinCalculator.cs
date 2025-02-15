using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class BuhiCoinCalculator : MonoBehaviour
{
    public TMP_Text ShowBuhiCoin;
    public TMP_Text EnteredSecretID;
    public void GetBuhiCoin()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName", "Guest").Replace("\u200B", "");
        string PlayerBirth = PlayerPrefs.GetString("PlayerBirth", "2000/0101").Replace("\u200B", "");
        string PlayerBirthday = PlayerBirth.Substring(PlayerBirth.IndexOf("/") + 1); // "/"より後の4桁
        string PlayerBirthyear = PlayerBirth.Substring(0, PlayerBirth.IndexOf("/")); // "/"より前の4桁
        int BuhiCoinNow = 0;
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
        if (SecretID.Contains(PlayerBirthyear)){
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

        // PlayerPrefsに名前を保存
        PlayerPrefs.SetString("BuhiCoin", BuhiCoinNow.ToString());
        //保存する
        PlayerPrefs.Save();

    }
}





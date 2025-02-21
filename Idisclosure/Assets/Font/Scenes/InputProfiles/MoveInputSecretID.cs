using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MoveInputSecretID : MonoBehaviour
{
    public TMP_InputField Name;             // 名前のInputField
    public TMP_InputField Birthday;          // 生年月日のInputField
    public TMP_Text nameWarningText;         // 名前の警告テキスト
    public TMP_Text birthdayWarningText;     // 生年月日の警告テキスト
    public Button nextButton;                // Nextボタン

    // Startは初期設定
    void Start()
    {
        // 初期状態で警告テキストを非表示、Nextボタンを無効化
        nameWarningText.gameObject.SetActive(false);
        birthdayWarningText.gameObject.SetActive(false);
        nextButton.interactable = false;

        // InputFieldの変更イベントを登録
        Name.onValueChanged.AddListener(delegate { OnInputChange(); });
        Birthday.onValueChanged.AddListener(delegate { OnInputChange(); });
    }

    public void change_button2() // 実際に動作する関数
    {
        string playerName = Name.text;
        string playerBirth = Birthday.text;

        bool isNameValid = ValidateName(playerName);
        bool isBirthdayValid = ValidateBirthday(playerBirth);

        // 名前と生年月日が正しい場合にのみ次のシーンに遷移
        if (isNameValid && isBirthdayValid)
        {
            // PlayerPrefsに名前と生年月日を保存
            PlayerPrefs.SetString("Name", playerName);
            PlayerPrefs.SetString("Birth", playerBirth);
            PlayerPrefs.Save();

            // シーン遷移
            SceneManager.LoadScene("InputSecretID");
        }
        else
        {
            // 警告メッセージを表示し、Nextボタンを無効化
            if (!isNameValid)
            {
                nameWarningText.gameObject.SetActive(true);
            }
            if (!isBirthdayValid)
            {
                birthdayWarningText.gameObject.SetActive(true);
            }

            // Nextボタンを無効化
            nextButton.interactable = false;
        }
    }

    // 名前が11文字以上かをチェック
    private bool ValidateName(string name)
    {
        if (name.Length >= 11 || name.Length == 0)
        {
            return false; // 名前が11文字以上、または空欄なら無効
        }
        return true; // 名前が1文字以上10文字以内なら有効
    }

    // 生年月日が「YYYY/MMDD」形式かをチェック
private bool ValidateBirthday(string birthday)
{
    // 正規表現で「YYYY/MMDD」形式のチェック
    Regex regex = new Regex(@"^\d{4}/\d{2}\d{2}$");
    if (!regex.IsMatch(birthday))
    {
        return false; // 正しい形式でなければ無効
    }

    // YYYY, MM, DDに分割
    string[] parts = birthday.Split('/');
    string year = parts[0];
    string month = parts[1].Substring(0, 2);
    string day = parts[1].Substring(2, 2);

    // 年(YYYY)のチェック: 1960〜2015の範囲内
    int yearInt = int.Parse(year);
    if (yearInt < 1960 || yearInt > 2015)
    {
        return false; // 年が1960〜2015の範囲外なら無効
    }
    
    // 月(MM)のチェック: 01〜12の範囲内
    int monthInt = int.Parse(month);
    if (monthInt < 1 || monthInt > 12)
    {
        return false; // 月が1〜12の範囲外なら無効
    }

    // 日(DD)のチェック: 01〜31の範囲内
    int dayInt = int.Parse(day);
    if (dayInt < 1 || dayInt > 31)
    {
        return false; // 日が1〜31の範囲外なら無効
    }

    return true; // 全てのチェックを通過したら有効
}


    // 入力内容が変更されたときにNextボタンの有効/無効を更新
public void OnInputChange()
{
    // Birthdayの入力を英数字と「/」のみに制限
    string filteredBirthday = Regex.Replace(Birthday.text, @"[^a-zA-Z0-9/]", "");
    if (Birthday.text != filteredBirthday)
    {
        Birthday.text = filteredBirthday;
        Birthday.caretPosition = Birthday.text.Length; // カーソル位置を末尾に
    }

    string playerName = Name.text;
    string playerBirth = Birthday.text;

    bool isNameValid = ValidateName(playerName);
    bool isBirthdayValid = ValidateBirthday(playerBirth);

    // 名前と生年月日が正しい場合にNextボタンを有効化
    if (isNameValid && isBirthdayValid)
    {
        nextButton.interactable = true;
    }
    else
    {
        nextButton.interactable = false;
    }

    // 警告テキストの表示/非表示を更新
    nameWarningText.gameObject.SetActive(!isNameValid);
    birthdayWarningText.gameObject.SetActive(!isBirthdayValid);
}

}


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Text.RegularExpressions;
using Photon.Realtime;
using System.Collections.Generic;

public class CrackTool : MonoBehaviour
{
    string CheckSecretID = "";
    string pattern = "";
    public UnityEngine.UI.Text ShowID; // UnityのTextコンポーネント
    
    // 使用するキャラクターセット
    private static readonly string digits = "0123456789";      // 数字
    private static readonly string symbols = "!#$%&()*+,-./:;<=>?@[]/^-{}|~";      // 記号
    private static readonly string lowercase = "abcdefghijklmnopqrstuvwxyz";  // 小文字
    private static readonly string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  // 大文字

    // 表示する最大件数
    private static int maxDisplayCount = 23;

    // クラックしたパスワードと失敗したパスワードを管理するリスト
    private static List<string> crackedPasswords = new List<string>();
    private static List<string> failedPasswords = new List<string>();

    void Start()
    {
        // 文字列として全ての人のパスワードを連結
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("SecretID"))
            {
                CheckSecretID += ((string)player.CustomProperties["SecretID"]).Replace("\u200B", "");
            }
        }

        pattern = PlayerPrefs.GetString("TargetSecretID", "");

        // 総当たり生成
        GenerateCombinations(pattern);
        
        // 結果表示
        DisplayResults();
    }

    // パターンに基づいて総当たり
    void GenerateCombinations(string pattern)
    {
        // パターンの文字列を1文字ずつチェック
        var replacements = new Dictionary<string, string>
        {
            { "?d", digits },
            { "?s", symbols },
            { "?l", lowercase },
            { "?u", uppercase }
        };

        GenerateCombinationsRecursive(pattern, replacements, 0);
    }

    // 再帰的にパスワードを生成
    void GenerateCombinationsRecursive(string pattern, Dictionary<string, string> replacements, int index)
    {
        if (index == pattern.Length)  // 基本条件：パターンをすべて処理した
        {
            // クラックする
            string generatedPassword = pattern;

            if (CheckCrack(generatedPassword))
            {
                crackedPasswords.Add(generatedPassword);
            }
            else
            {
                failedPasswords.Add(generatedPassword);
            }

            // 最大表示件数を超えた場合、古いものを削除
            if (crackedPasswords.Count + failedPasswords.Count > maxDisplayCount)
            {
                // 最も古いものを削除
                if (crackedPasswords.Count > maxDisplayCount)
                    crackedPasswords.RemoveAt(0);
                else
                    failedPasswords.RemoveAt(0);
            }

            return;
        }

        // 現在のインデックスの文字が置換対象であれば、そのキャラクターセットを適用
        foreach (var key in replacements.Keys)
        {
            if (pattern.Substring(index, key.Length) == key)
            {
                string characters = replacements[key];

                foreach (var c in characters)
                {
                    // 新しい文字列を生成して再帰呼び出し
                    string newPattern = pattern.Substring(0, index) + c + pattern.Substring(index + key.Length);
                    GenerateCombinationsRecursive(newPattern, replacements, index + 1);
                }
            }
        }

        // 現在の文字は変換対象でない場合、そのまま再帰
        GenerateCombinationsRecursive(pattern, replacements, index + 1);
    }

    // パスワードがクラックできたか確認
    bool CheckCrack(string generatedPassword)
    {
        return CheckSecretID.Contains(generatedPassword);
    }

    // クラック成功したパスワードと失敗したパスワードを表示
    void DisplayResults()
    {
        ShowID.text = ""; // 初期化

        ShowID.text += "Cracked Passwords:\n";
        foreach (var password in crackedPasswords)
        {
            ShowID.text += password + "\n";
        }

        ShowID.text += "\nFailed Passwords:\n";
        foreach (var password in failedPasswords)
        {
            ShowID.text += password + "\n";
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Text.RegularExpressions;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;  // これを追加


public class CrackTool : MonoBehaviour
{
    string CheckSecretID = "";
    string pattern = "";
    public TMP_Text ShowIDDisplay;
    string ShowID = "";
    string Pattern = "";
    
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
        ShowID = "";

        // 文字列として全ての人のパスワードを連結
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("SecretID"))
            {
                CheckSecretID += ((string)player.CustomProperties["SecretID"]).Replace("\u200B", "");
                CheckSecretID += "\n";
            }
        }

        pattern = PlayerPrefs.GetString("TargetSecretID", "");

        // 総当たり生成
        GenerateCombinations(pattern);
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

        GenerateCombinationsRecursive(pattern, replacements);
    }

    // 再帰的にパスワードを生成
    void GenerateCombinationsRecursive(string pattern, Dictionary<string, string> replacements)
    {
        while (GetBlockCount(ShowID) >= maxDisplayCount)
        {
            int firstNewlineIndex = ShowID.IndexOf('\n');
            if (firstNewlineIndex != -1)
            {
                ShowID = ShowID.Remove(0, firstNewlineIndex + 1);
            }
            else
            {
                ShowID = "";
                break;
            }
        }

        var result = from a in Enumerable.Range(0,replacements["?d"].Length)
                    from b in Enumerable.Range(0,replacements["?s"].Length)
                    from c in Enumerable.Range(0,replacements["?l"].Length)
                    from d in Enumerable.Range(0,replacements["?u"].Length)
                    select new
                    {
                        Pattern = pattern
                        .Replace("?d", replacements["?d"][a].ToString())
                        .Replace("?s", replacements["?s"][b].ToString())
                        .Replace("?l", replacements["?l"][c].ToString())
                        .Replace("?u", replacements["?u"][d].ToString())
                    };
        
        foreach (var ID in result)
        {
            if (CheckSecretID.Contains(ID.Pattern.Replace("CrackTool ","")))
            {
                // 最初のみ初期値設定
                if (!(ShowID.Contains("Cracked!")))
                {
                    ShowID += "Cracked!" + "\n";
                }
                // 一致したらCrackedに記録
                if (!(ShowID.Contains(ID.Pattern.Replace("CrackTool ",""))))
                {
                    ShowID += ID.Pattern.Replace("CrackTool ", "") + "\n";
                    Debug.Log("Generated Pattern: " + ID.Pattern);  // 各パターンを確認する
                }
                else
                {
                    continue;
                }
            }
        }
        foreach (var ID in result)
        {
            if (!(CheckSecretID.Contains(ID.Pattern.Replace("CrackTool ",""))))
            {
                // 最初のみ初期値設定
                if (!(ShowID.Contains("Exhaust!")))
                {
                    ShowID += "Exhaust!" + "\n";
                }
                // 一致したらCrackedに記録
                if (!(ShowID.Contains(ID.Pattern.Replace("CrackTool ",""))))
                {
                    ShowID += ID.Pattern.Replace("CrackTool ", "") + "\n";
                    Debug.Log("Generated Pattern: " + ID.Pattern);  // 各パターンを確認する
                }
                else
                {
                    continue;
                }
            }
        }
        ShowIDDisplay.text = ShowID;
    }
        

    

    private int GetBlockCount(string text)
    {
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '\n')
            {
                count++;
            }
        }
        return count;
    }
}

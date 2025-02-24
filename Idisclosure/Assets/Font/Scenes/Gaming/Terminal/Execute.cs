using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Text.RegularExpressions;
using Photon.Realtime;


public class Execute : MonoBehaviour
{
    public TMP_Text Command;
    private const byte VirusOO = 101;
    private const byte DoSToolPlayer = 102;
    private const byte DoSToolServer = 103;

    // クールタイムの設定（秒）
    private float commandCooldown = 5f;  // 5秒のクールタイム
    private float lastCommandTime = -Mathf.Infinity;  // 最後のコマンド実行時刻
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if (eventCode == VirusOO)
        {
            string message = (string)photonEvent.CustomData;
            Debug.Log($"VirusOOイベント受信！ メッセージ: {message}");
        }
        else if (eventCode == DoSToolPlayer || eventCode == DoSToolServer)
        {
            string attackerIP = (string)photonEvent.CustomData;
            Debug.Log($"DoS攻撃イベント受信！ 攻撃元IP: {attackerIP}, イベントコード: {eventCode}");

            // バッテリーを減らす処理
            int battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
            int drainAmount = 25; // DoS攻撃のバッテリー減少量

            if (battery - drainAmount >= 0)
            {
                battery -= drainAmount;
                PlayerPrefs.SetString("Battery", battery.ToString());
                PlayerPrefs.Save();
                Debug.Log($"バッテリーが {drainAmount} 減少しました。残り: {battery}");
            }
            else
            {
                Debug.Log("バッテリーが不足しています！");
            }
        }
    }
    public void ExecuteCommand()
    {
        string command = Command.text.Trim().Replace("\u200B", "");
        Debug.Log("Terminal起動:" + command);

        /*----------Virus Osakano Obatyannを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadVirusOO") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadVirusOO"])
        {
            if (Regex.IsMatch(command, @"VirusOO.*"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    /*----------IP処理----------*/
                    string TargetIP = command.Replace("VirusOO ", "");
                    /*----------IP探索----------*/
                    foreach (Player player in PhotonNetwork.PlayerList)
                    {
                        if ((string)player.CustomProperties["PlayerIP"] == TargetIP || (string)player.CustomProperties["ServerIP"] == TargetIP)
                        {
                            string message = "Ametyann Ageruwa";
                            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { player.ActorNumber } };
                            SendOptions sendOptions = new SendOptions { Reliability = true };
                            PhotonNetwork.RaiseEvent(VirusOO, message, raiseEventOptions, sendOptions);
                        }
                    }

                }
            }
        }

        /*----------IPBST1を実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadIPBST1") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadIPBST1"])
        {
            if (Regex.IsMatch(command, "IPBST1"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Wifi1");
                }
            }
        }

        /*----------IPBST2を実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadIPBST2") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadIPBST2"])
        {
            if (Regex.IsMatch(command, "IPBST2"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Wifi2");
                }
            }
        }

        /*----------IPBST3を実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadIPBST3") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadIPBST3"])
        {
            if (Regex.IsMatch(command, "IPBST3"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Wifi3");
                }
            }
        }

        /*----------DoSToolを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadDoSTool") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadDoSTool"])
        {
            // クールタイムが経過していない場合は実行しない
            if (Time.time - lastCommandTime < commandCooldown)
            {
                Debug.Log("コマンドはクールタイム中です。少し待ってから再試行してください。");
                return;
            }

            if (Regex.IsMatch(command, @"DoSTool.*"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();

                    /*----------IP処理----------*/
                    string TargetIP = command.Replace("DoSTool ", "");

                    /*----------IP探索----------*/
                    foreach (Player player in PhotonNetwork.PlayerList)
                    {
                        string PlayerIP = "";
                        if ((string)player.CustomProperties["PlayerIP"] == TargetIP)
                        {
                            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                            {
                                PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                            }
                            string message = PlayerIP;
                            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { player.ActorNumber } };
                            SendOptions sendOptions = new SendOptions { Reliability = true };
                            PhotonNetwork.RaiseEvent(DoSToolPlayer, message, raiseEventOptions, sendOptions);
                        }
                        else if ((string)player.CustomProperties["ServerIP"] == TargetIP)
                        {
                            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerIP"))
                            {
                                PlayerIP = (string)PhotonNetwork.LocalPlayer.CustomProperties["PlayerIP"];
                            }
                            string message = PlayerIP;
                            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { player.ActorNumber } };
                            SendOptions sendOptions = new SendOptions { Reliability = true };
                            PhotonNetwork.RaiseEvent(DoSToolServer, message, raiseEventOptions, sendOptions);
                        }
                    }


                    // コマンド実行時刻を保存して、次のコマンド実行時に使用する
                    lastCommandTime = Time.time;
                }
            }
        }

        /*----------CrackToolを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadCrackTool") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadCrackTool"])
        {
            if (Regex.IsMatch(command, @"CrackTool.*"))
            {
                string IDCandidate = command.Replace("cracktool ", "");
                
                // 正しいカウント処理
                int CountL = Regex.Matches(IDCandidate, @"\?l").Count;
                int CountU = Regex.Matches(IDCandidate, @"\?u").Count;
                int CountD = Regex.Matches(IDCandidate, @"\?d").Count;
                int CountS = Regex.Matches(IDCandidate, @"\?s").Count;
                int CountA = Regex.Matches(IDCandidate, @"\?a").Count;

                int drain = CountL * 3 + CountU * 3 + CountD * 1 + CountS * 5 + CountA * 15;
                
                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0")); // \u200B を除去
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.SetString("TargetSecretID", IDCandidate);
                    PlayerPrefs.Save();

                    /*----------シーン遷移----------*/
                    SceneManager.LoadScene("CrackToolDisplay");
                }
            }
        }
    }
}

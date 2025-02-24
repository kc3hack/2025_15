using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Text.RegularExpressions;
using Photon.Realtime;


public class ExecuteMyServer : MonoBehaviour
{
    public TMP_Text Command;
    private const byte VirusOO = 101;
    private const byte DoSToolPlayer = 102;
    private const byte DoSToolServer = 103;

    // クールタイムの設定（秒）
    private float commandCooldown = 5f;  // 5秒のクールタイム
    private float lastCommandTime = -Mathf.Infinity;  // 最後のコマンド実行時刻

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

                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                    PlayerPrefs.Save();
                    /*----------IP処理----------*/
                    string TargetIP = command.Replace("VirusOO ","");
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
                
                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
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
                
                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
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
                
                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
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

                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
                    PlayerPrefs.Save();
                    /*----------IP処理----------*/
                    string TargetIP = command.Replace("DoSTool ","");
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
    }
}


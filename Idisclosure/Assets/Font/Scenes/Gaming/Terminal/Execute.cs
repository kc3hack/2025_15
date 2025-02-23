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
        string command = Command.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Terminal起動:" + command);

        /*----------Virus Osakano Obatyannを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadVirusOO") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadVirusOO"])
        {
            if (Regex.IsMatch(command, @"virusoo.*"))
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
                    string TargetIP = command.Replace("virusoo ","");
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
            if (Regex.IsMatch(command, "ipbst1"))
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
            if (Regex.IsMatch(command, "ipbst2"))
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
            if (Regex.IsMatch(command, "ipbst3"))
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
            if (Regex.IsMatch(command, @"dostool.*"))
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
                    string TargetIP = command.Replace("dostool ","");
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
                }
            }
        }

        /*----------CrackToolを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadCrackTool") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadCrackTool"])
        {
            if (Regex.IsMatch(command, "cracktool"))
            {
                int drain = 10;
                
                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("CrackTool");
                }
            }
        }
        
    }
}


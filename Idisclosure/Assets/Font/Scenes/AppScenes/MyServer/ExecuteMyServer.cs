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

                int BatteryMyServer = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                if ((BatteryMyServer - drain >= 0))
                {
                    /*----------BatteryMyServer処理----------*/
                    BatteryMyServer -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", BatteryMyServer.ToString());
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
            if (Regex.IsMatch(command, "ipbst2"))
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
            if (Regex.IsMatch(command, "ipbst3"))
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
            if (Regex.IsMatch(command, @"dostool.*"))
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
            if (Regex.IsMatch(command, @"cracktool.*"))
            {
                string IDCandidate = command.Replace("cracktool ", "");
                
                // 正しいカウント処理
                int CountL = Regex.Matches(IDCandidate, @"\?l").Count;
                int CountU = Regex.Matches(IDCandidate, @"\?u").Count;
                int CountD = Regex.Matches(IDCandidate, @"\?d").Count;
                int CountS = Regex.Matches(IDCandidate, @"\?s").Count;
                int CountA = Regex.Matches(IDCandidate, @"\?a").Count;

                int drain = CountL * 3 + CountU * 3 + CountD * 1 + CountS * 5 + CountA * 15;
                
                int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0")); // \u200B を除去
                if ((Battery - drain >= 0))
                {
                    /*----------Battery処理----------*/
                    Battery -= drain;
                    PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                    PlayerPrefs.SetString("TargetSecretID", IDCandidate);
                    PlayerPrefs.Save();

                    /*----------シーン遷移----------*/
                    SceneManager.LoadScene("CrackTool");
                }
            }
        }
    }
}


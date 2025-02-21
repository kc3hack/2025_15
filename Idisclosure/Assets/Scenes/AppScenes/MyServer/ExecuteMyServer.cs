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
    private const byte DoSPlayer = 102;
    private const byte DoSServer = 103;

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

        /*----------Dosを実行----------*/
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("DownloadDos") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["DownloadDos"])
        {
            if (Regex.IsMatch(command, @"dos.*"))
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
                    string TargetIP = command.Replace("dos ","");
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
                            PhotonNetwork.RaiseEvent(DoSPlayer, message, raiseEventOptions, sendOptions);
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
                            PhotonNetwork.RaiseEvent(DoSServer, message, raiseEventOptions, sendOptions);
                        }
                    }
                }
            }
        }
    }
}


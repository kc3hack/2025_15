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
    private const byte DoSPlayer = 102;
    private const byte DoSServer = 103;

    public void ExecuteCommand()
    {
        string command = Command.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Terminal起動:" + command);

        /*----------Virus Osakano Obatyannを実行----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DownloadVirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DownloadVirusOO"])
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
        /*----------PullDeerを実行----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DownloadPullDeer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DownloadPullDeer"])
        {
            if (Regex.IsMatch(command, "pulldeer"))
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

        /*----------Dosを実行----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DownloadDos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DownloadDos"])
        {
            if (Regex.IsMatch(command, @"dos.*"))
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


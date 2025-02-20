using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.Text.RegularExpressions;

public class Execute : MonoBehaviour
{
    public TMP_Text Command;

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
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("VirusOO");
                }
            }
        }
        /*----------PullDeerを実行----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DownloadPullDeer") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DownloadPullDeer"])
        {
            if (Regex.IsMatch(command, @"PullDeer.*"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("PullDeer");
                }
            }
        }

        /*----------Dosを実行----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("DownloadDos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["DownloadDos"])
        {
            if (Regex.IsMatch(command, @"Dos.*"))
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Dos");
                }
            }
        }
    }
}


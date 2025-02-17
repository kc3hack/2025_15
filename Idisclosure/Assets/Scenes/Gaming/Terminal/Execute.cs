using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;

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
            if (command == "./virusoo")
            {
                int drain = 10;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("VirusOO");
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }
    }
}

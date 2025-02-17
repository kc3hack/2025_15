using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;

public class BrowserSearch : MonoBehaviour
{
    public TMP_Text SearchWords;

    public void SearchAndMove()
    {
        string searchWords = SearchWords.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Browser起動:" + searchWords);

        /*----------My Serverを検索----------*/
        if (searchWords == "my server")
        {
            int drain = 1;

            int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {
                Battery -= drain;
                PlayerPrefs.SetString("Battery", Battery.ToString());
                PlayerPrefs.Save();
                SceneManager.LoadScene("MyServer");
            }
            // ここにwifiにIPメモる処理忘れずに
        }

        /*----------SNS Serverを検索----------*/
        if (searchWords == "sns server")
        {
            int drain = 1;

            int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {
                Battery -= drain;
                PlayerPrefs.SetString("Battery", Battery.ToString());
                PlayerPrefs.Save();
                SceneManager.LoadScene("SNSServer");
            }
            // ここにwifiにIPメモる処理忘れずに
        }
        
        /*----------Virus Osakano Obatyannを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"])
        {
            if (searchWords == "virusoo")
            {
                int drain = 1;

                int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                if ((Battery - drain >= 0))
                {
                    Battery -= drain;
                    PlayerPrefs.SetString("Battery", Battery.ToString());
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("VirusOO");
                }
                // ここにwifiにIPをメモる処理忘れずに
            }
        }
    }
}

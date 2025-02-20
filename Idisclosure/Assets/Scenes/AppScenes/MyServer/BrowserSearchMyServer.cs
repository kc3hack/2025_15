using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Pun;

public class BrowserSearchMyServer : MonoBehaviour
{
    public TMP_Text SearchWords;

    public void SearchAndMove()
    {
        string searchWords = SearchWords.text.Trim().ToLower().Replace("\u200B", "");
        Debug.Log("Browser起動:" + searchWords);

        /*----------SNS Serverを検索----------*/
        if (searchWords == "sns server")
        {
            int drain = 1;

            int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
            if ((Battery - drain >= 0))
            {
                Battery -= drain;
                PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                PlayerPrefs.Save();
                SceneManager.LoadScene("SNSServer");
            }
            // ここにwifiにIPメモる処理忘れずに
        }

        /*----------Virus Osakano Obatyannを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("VirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["VirusOO"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingVirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingVirusOO"])
            {
                if (searchWords == "virusoo")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("FishingVirusOO");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
            else
            {
                if (searchWords == "virusoo")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("VirusOO");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }

            /*----------Dosを検索----------*/
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Dos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Dos"])
            {
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingDos") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingDos"])
                {
                    if (searchWords == "dos")
                    {
                        int drain = 1;

                        int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                        if ((Battery - drain >= 0))
                        {
                            Battery -= drain;
                            PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                            PlayerPrefs.Save();
                            SceneManager.LoadScene("FishingDos");
                        }
                        // ここにwifiにIPをメモる処理忘れずに
                    }
                }
                else
                {
                    if (searchWords == "dos")
                    {
                        int drain = 1;

                        int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer", "0").Replace("\u200B", ""));
                        if ((Battery - drain >= 0))
                        {
                            Battery -= drain;
                            PlayerPrefs.SetString("BatteryMyServer", Battery.ToString());
                            PlayerPrefs.Save();
                            SceneManager.LoadScene("Dos");
                        }
                        // ここにwifiにIPをメモる処理忘れずに
                    }
                }
            }
        }
    }
}

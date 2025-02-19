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
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingVirusOO") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingVirusOO"])
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

        /*----------SpareBatteryを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SpareBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSpareBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSpareBattery"])
            {
                if (searchWords == "spare battery")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("FishingSpareBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
            else
            {
                if (searchWords == "spare battery")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("SpareBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }

        /*----------SmallBatteryを検索----------*/
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("SmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["SmallBattery"])
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("FishingSmallBattery") && (bool)PhotonNetwork.CurrentRoom.CustomProperties["FishingSmallBattery"])
            {
                if (searchWords == "small battery")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("FishingSmallBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
            else
            {
                if (searchWords == "small battery")
                {
                    int drain = 1;

                    int Battery = int.Parse(PlayerPrefs.GetString("Battery", "0").Replace("\u200B", ""));
                    if ((Battery - drain >= 0))
                    {
                        Battery -= drain;
                        PlayerPrefs.SetString("Battery", Battery.ToString());
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("SmallBattery");
                    }
                    // ここにwifiにIPをメモる処理忘れずに
                }
            }
        }
    }
}

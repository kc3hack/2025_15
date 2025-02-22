using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using TMPro;

public class FishingDownload : MonoBehaviour
{
    private const byte SuccessFishing = 3;
    public void FishingDownloadVirusOO()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherVirusOO"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadSpareBatteryPC()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherSpareBatteryPC"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadSpareBatteryMyServer()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherSpareBatteryMyServer"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadSmallBatteryPC()
    {
        int drain = 100;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherSmallBatteryPC"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadSmallBatteryMyServer()
    {
        int drain = 100;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherSmallBatteryMyServer"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }
    public void FishingDownloadIPBST1()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherIPBST1"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadIPBST2()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherIPBST2"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadIPBST3()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherIPBST3"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }

    public void FishingDownloadDoSTool()
    {
        int drain = 300;
        int BuhiCoin = int.Parse(PlayerPrefs.GetString("BuhiCoin", "0").Replace("\u200B", ""));

        // BuhiCoinの支払いについて
        if ((BuhiCoin - drain) >= 0){
            BuhiCoin -= drain;
            PlayerPrefs.SetString("BuhiCoin", BuhiCoin.ToString());
            PlayerPrefs.Save();

            // 宛先探索
            string fisherName = (string)PhotonNetwork.CurrentRoom.CustomProperties["FisherDoSTool"];
            Player targetPlayer = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == fisherName)
                {
                    targetPlayer = player;
                    break;
                }
            }

            // 支払われたらServerの主に送金
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { TargetActors = new int[] { targetPlayer.ActorNumber } };
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(SuccessFishing, drain, raiseEventOptions, sendOptions);
            SceneManager.LoadScene("Failed");
        }
    }
}


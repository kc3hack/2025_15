using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using System.Collections;


public class AttackedManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private const byte VirusOO = 101;
    private const byte DoS = 102;
    string Device;
    string AttackIP;
    string BlockedIPMyServer;
    string BlockedIP;


    public void OnEvent(EventData photonEvent)
    {
        /*----------VirusOOを受信----------*/
        if (photonEvent.Code == VirusOO)
        {
            StartCoroutine(ShowAndUnloadCandyScene());
        }
        /*----------DoSを受信----------*/
        if (photonEvent.Code == DoS)
        {
            object[] data = (object[])photonEvent.CustomData; // 受け取ったデータを取得
            Device = (string)data[0];
            AttackIP = (string)data[1];
            StartCoroutine(ShowAndUnloadDoSScene());
        }
    }

    private IEnumerator ShowAndUnloadCandyScene()
    {
        // "Candy" シーンを現在のシーンに重ねる（Additive モード）
        SceneManager.LoadScene("Candy", LoadSceneMode.Additive);
        
        // 10秒待つ
        yield return new WaitForSeconds(10);
        
        // "Candy" シーンを削除（アンロード）
        SceneManager.UnloadSceneAsync("Candy");
    }

    private IEnumerator ShowAndUnloadDoSScene()
    {
        if (Device == "Server")
        {
            BlockedIPMyServer = (string)PlayerPrefs.GetString("BlockedIPMyServer","0.0.0.0");
            if (!(BlockedIP.Contains(AttackIP)))
            {
                int Battery = int.Parse(PlayerPrefs.GetString("BatteryMyServer","0"));
                Battery -= 25;
                PlayerPrefs.SetString("BatteryMyServer",Battery.ToString());
                PlayerPrefs.Save();
                // "DoS" シーンを現在のシーンに重ねる
                SceneManager.LoadScene("DoS", LoadSceneMode.Additive);
                
                // 2秒待つ
                yield return new WaitForSeconds(2);
                
                // "DoS" シーンを削除
                SceneManager.UnloadSceneAsync("DoS");
            }
        }
        else if (Device == "Player")
        {
            BlockedIP = (string)PlayerPrefs.GetString("BlockedIP","0.0.0.0");
            if (!(BlockedIP.Contains(AttackIP)))
            {
                int Battery = int.Parse(PlayerPrefs.GetString("Battery","0"));
                Battery -= 25;
                PlayerPrefs.SetString("Battery",Battery.ToString());
                PlayerPrefs.Save();
                // "DoS" シーンを現在のシーンに重ねる
                SceneManager.LoadScene("DoS", LoadSceneMode.Additive);
                
                // 2秒待つ
                yield return new WaitForSeconds(2);
                
                // "DoS" シーンを削除
                SceneManager.UnloadSceneAsync("DoS");
            }
        }
    }
}

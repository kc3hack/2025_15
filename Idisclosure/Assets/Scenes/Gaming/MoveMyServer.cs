using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMyServer : MonoBehaviour
{
    public void Move()
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
}

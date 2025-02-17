using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
            SceneManager.LoadScene("MyServer");
            // ここにwifiにIPメモる処理忘れずに
        }

        /*----------SNS Serverを検索----------*/
        if (searchWords == "sns server")
        {
            SceneManager.LoadScene("SNSServer");
            // ここにwifiにIPメモる処理忘れずに
        }
    }
}

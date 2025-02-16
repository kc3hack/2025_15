using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveStartClick : MonoBehaviour
{
    void Update()
    {
        // 画面をタップしたときに実行
        if (Input.GetMouseButtonDown(0))
        {
            // 次のシーンに遷移
            SceneManager.LoadScene("StartClick");
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTerminalMyServer : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("TerminalMyServer");
    }
}

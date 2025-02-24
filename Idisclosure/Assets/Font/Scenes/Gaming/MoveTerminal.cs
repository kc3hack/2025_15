using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTerminal : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("Terminal");
    }
}

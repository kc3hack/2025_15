using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMyServer : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("MyServer");
    }
}

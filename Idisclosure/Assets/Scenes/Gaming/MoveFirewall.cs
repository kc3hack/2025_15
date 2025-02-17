using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFirewall : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("Firewall");
    }
}

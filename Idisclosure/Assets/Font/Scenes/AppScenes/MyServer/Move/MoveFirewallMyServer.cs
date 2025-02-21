using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFirewallMyServer : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("FirewallMyServer");
    }
}

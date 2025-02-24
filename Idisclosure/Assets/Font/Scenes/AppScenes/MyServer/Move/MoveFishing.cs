using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFishing : MonoBehaviour
{
    public void Move()
    {
        SceneManager.LoadScene("FishingMyServer");
    }
}

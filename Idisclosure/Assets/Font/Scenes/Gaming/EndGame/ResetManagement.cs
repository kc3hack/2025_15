using UnityEngine;

public class ResetManagement : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("BuhiCoin","0");
    }
}

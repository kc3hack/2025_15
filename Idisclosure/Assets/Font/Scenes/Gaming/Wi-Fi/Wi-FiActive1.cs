using UnityEngine;

public class WiFiActive1 : MonoBehaviour
{
    public GameObject ActiveCircle;
    public void Active()
    {
        PlayerPrefs.SetString("WifiNumber","1");
        PlayerPrefs.Save();
    }
    void Update()
    {
        if ((string)PlayerPrefs.GetString("WifiNumber","1") == "1")
        {
            ActiveCircle.SetActive(true);
        }
        else
        {
            ActiveCircle.SetActive(false);
        }
    }
}

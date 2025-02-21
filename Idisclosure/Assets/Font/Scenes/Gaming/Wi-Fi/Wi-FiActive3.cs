using UnityEngine;

public class WiFiActive3 : MonoBehaviour
{
    public GameObject ActiveCircle;
    public void Active()
    {
        PlayerPrefs.SetString("WifiNumber","3");
        PlayerPrefs.Save();
    }
    void Update()
    {
        if ((string)PlayerPrefs.GetString("WifiNumber","1") == "3")
        {
            ActiveCircle.SetActive(true);
        }
        else
        {
            ActiveCircle.SetActive(false);
        }
    }
}

using UnityEngine;

public class WiFiActive2 : MonoBehaviour
{
    public GameObject ActiveCircle;
    public void Active()
    {
        PlayerPrefs.SetString("WifiNumber","2");
        PlayerPrefs.Save();
    }
    void Update()
    {
        if ((string)PlayerPrefs.GetString("WifiNumber","1") == "2")
        {
            ActiveCircle.SetActive(true);
        }
        else
        {
            ActiveCircle.SetActive(false);
        }
    }
}

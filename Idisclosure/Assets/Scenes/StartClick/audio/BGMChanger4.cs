using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BGMChanger4 : MonoBehaviour
{
    public AudioClip bgm_A;
    public AudioClip bgm_B;
    private AudioSource audioSource;

    // �V�[������enum�ŊǗ�
    public enum SceneName
    {
        StartClick,
        InputProfiles,
        InputSecretID,
        CreateJoin,
        Waiting,
        Gaming,
        EndGame,
        Connecting,
        TimeUp,
        MyServer,
        SNSServer,
        Firewall,
        Terminal,
        VirusOO,
        TerminalMyServer,
        FirewallMyServer,
        FishingMyServer,
        FishingVirusOO,
        Success,
        Failed,
        FishingNow,
        CreateFishing,
        BatteryDead,
        Candy,
        DoSNotification,
        Wifi1,
        Wifi2,
        Wifi3,
        SpareBattery,
        SmallBattery,
        IPBST1,
        Dos,
        FishingSpareBattery,
        FishingSmallBattery,
        FishingIPBST1,
        FishingDos
    }

    // BGM_A�������V�[��
    private HashSet<SceneName> bgmAScenes = new HashSet<SceneName>()
    {
        SceneName.StartClick,
        SceneName.InputProfiles,
        SceneName.InputSecretID,
        SceneName.CreateJoin,
        SceneName.Waiting,
    };

    // BGM_B�������V�[��
    private HashSet<SceneName> bgmBScenes = new HashSet<SceneName>()
    {
        SceneName.Gaming,
        SceneName.EndGame,
        SceneName.Connecting,
        SceneName.TimeUp,
        SceneName.MyServer,
        SceneName.SNSServer,
        SceneName.Firewall,
        SceneName.Terminal,
        SceneName.VirusOO,
        SceneName.TerminalMyServer,
        SceneName.FirewallMyServer,
        SceneName.FishingMyServer,
        SceneName.FishingVirusOO,
        SceneName.Success,
        SceneName.Failed,
        SceneName.FishingNow,
        SceneName.CreateFishing,
        SceneName.BatteryDead,
        SceneName.Candy,
        SceneName.DoSNotification,
        SceneName.Wifi1,
        SceneName.Wifi2,
        SceneName.Wifi3,
        SceneName.SpareBattery,
        SceneName.SmallBattery,
        SceneName.IPBST1,
        SceneName.Dos,
        SceneName.FishingSpareBattery,
        SceneName.FishingSmallBattery,
        SceneName.FishingIPBST1,
        SceneName.FishingDos
    };

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
            return;
        }

        // BGM�����[�v�Đ�
        audioSource.loop = true;

        // �V�[���J�ڎ���BGM���p��
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // ���݂̃V�[�������擾
        SceneName currentScene;
        if (System.Enum.TryParse(SceneManager.GetActiveScene().name, out currentScene))
        {
            // BGM��؂�ւ�
            ChangeBGM(currentScene);
        }
        else
        {
            Debug.LogWarning("Unknown scene name: " + SceneManager.GetActiveScene().name);
        }
    }

    void ChangeBGM(SceneName sceneName)
    {
        AudioClip targetBGM = null;

        if (bgmAScenes.Contains(sceneName) && bgm_A != null)
        {
            targetBGM = bgm_A;
        }
        else if (bgmBScenes.Contains(sceneName) && bgm_B != null)
        {
            targetBGM = bgm_B;
        }

        if (targetBGM != null && audioSource.clip != targetBGM)
        {
            audioSource.clip = targetBGM;
            audioSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Timers;
public class SettingsManager : MonoBehaviour
{
    //public Slider masterVolume;
    //public Slider effectVolume;
    public Timer waitUpdate;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Settings.OnStartup();
    }
    void ApplyValues()
    {
        Screen.SetResolution(Settings.resolutionX, Settings.resolutionY, IntToBool(Settings.isFullscreen));
        QualitySettings.SetQualityLevel(Settings.graphicsMode);
        QualitySettings.vSyncCount = Settings.vSync;
        Debug.Log("beans");
        
    }
    void Start()
    {
        ApplyValues();
        waitUpdate = new Timer(1000);
        waitUpdate.Elapsed += WaitUpdate_Elapsed;
        waitUpdate.AutoReset = true;
        waitUpdate.Enabled = true;
    }

    private void WaitUpdate_Elapsed(object sender, ElapsedEventArgs e)
    {
        foreach(AudioSource aS in GameObject.FindObjectsOfType<AudioSource>())
        {
            aS.volume = Settings.masterVolume;
        }
    }

    bool IntToBool(int input)
    {
        if (input == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //UI Controls
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SaveChangesToSettings()
    {
        //need to implement UI before doing this
        //example: Settings.masterVolume = MasterVolumeSlider.value;
    }
}

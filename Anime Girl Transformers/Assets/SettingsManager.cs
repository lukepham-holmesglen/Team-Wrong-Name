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
    public List<AudioSource> audioSources = new List<AudioSource>();
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Settings.OnStartup();
        ApplyValues();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SearchForAudio();
        Camera cam = GameObject.FindObjectOfType<Camera>();
        float targetaspect = 16.0f / 9.0f;
        cam.aspect = targetaspect;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Camera cam = GameObject.FindObjectOfType<Camera>();
        float targetaspect = 16.0f / 9.0f;
        SearchForAudio();
        cam.aspect = targetaspect;
    }

    void ApplyValues()
    {
        Screen.SetResolution(Settings.resolutionX, Settings.resolutionY, IntToBool(Settings.isFullscreen));
        QualitySettings.SetQualityLevel(Settings.graphicsMode);
        QualitySettings.vSyncCount = Settings.vSync;
        
        
    }
    void SearchForAudio()
    {
        foreach (AudioSource aS in GameObject.FindObjectsOfType<AudioSource>())
        {
            audioSources.Add(aS);
            Debug.Log(Settings.masterVolume / 100f + "n");
            aS.volume = Settings.masterVolume / 100f;
        }
    }

    private void WaitUpdate_Elapsed(object sender, ElapsedEventArgs e)
    {

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

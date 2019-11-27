using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    // PlayerPrefs does not support bool type, int used instead: 0 = false, 1 = true.
    // Audio
    [Range(0,100)]
    public static float musicVolume;
    [Range(0, 100)]
    public static float effectVolume;
    [Range(0, 100)]
    public static float masterVolume;
    [Range(0,1)]
    public static int musicEnabled;
    [Range(0, 1)]
    public static int effectsEnabled;

    //Graphics
    public static int resolutionY;
    public static int resolutionX;
    [Range(0,1)]
    public static int isFullscreen;
    public static int graphicsMode;
    //0 = none, 1 = f/2, 2 = f. f = framerate of monitor;
    [Range(0,2)]
    public static int vSync;

    static string[] playerpreferences = new string[]
    {
        "musicVolume", "effectsVolume", "masterVolume", "musicEnabled", "effectsEnabled", "resolutionY", "resolutionX", "isFullscreen", "graphicsMode", "vSync"
    };


    public static void OnStartup()
    {
        int i = 1;
        foreach (string setting in playerpreferences)
        {
            if (PlayerPrefs.HasKey(setting))
            {
                i++;
            }
            else
            {
                Debug.LogError(setting + " does not exist");
                Debug.Log("Creating Settings");
                AssignDefaultValues();
            }


        }
             if (i == playerpreferences.Length)
             {
                  AssignValues();
             }
   }
        public static void AssignDefaultValues()
        {
        PlayerPrefs.SetFloat("musicVolume", 50);
        PlayerPrefs.SetFloat("effectsVolume", 60);
        PlayerPrefs.SetFloat("masterVolume", 75);
        PlayerPrefs.SetInt("musicEnabled", 1);
        PlayerPrefs.SetInt("effectsEnabled", 1);
        PlayerPrefs.SetInt("resolutionY", 1080);
        PlayerPrefs.SetInt("resolutionX", 1920);
        PlayerPrefs.SetInt("isFullscreen", 1);
        PlayerPrefs.SetInt("graphicsMode", 3);
        PlayerPrefs.SetInt("vSync", 0);
        Debug.Log("Settings reset to default");
        PlayerPrefs.Save();
        AssignValues();



        }
        public static void AssignValues()
        {
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        effectVolume = PlayerPrefs.GetFloat("effectsVolume");
        masterVolume = PlayerPrefs.GetFloat("masterVolume");
        musicEnabled = PlayerPrefs.GetInt("musicEnabled");
        effectsEnabled = PlayerPrefs.GetInt("effectsEnabled");
        resolutionY = PlayerPrefs.GetInt("resolutionY");
        resolutionX = PlayerPrefs.GetInt("resolutionY");
        isFullscreen = PlayerPrefs.GetInt("isFullscreen");
        graphicsMode = PlayerPrefs.GetInt("graphicsMode");
        vSync = PlayerPrefs.GetInt("vSync");
        
        Debug.Log("Settings assigned");
        }
    }



using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public static bool isSoundsEnabled { get; private set; }   // включение и громкость звуковых эффектов - 
    public static float soundsVolume { get; private set; }     // должны быть доступны для др. скриптов

    private static GameObject MenuContent;
    private static TMPro.TextMeshProUGUI MenuMessage;
    private static TMPro.TextMeshProUGUI ButtonCaption;
    private static TMPro.TextMeshProUGUI StatMessage;

    private AudioSource bgMusic;   // ссылка на AudioSource фоновой музыки
    private bool bgMusicEnabled;   // теущее состояние (играет или нет)
    private float bgMusicVolume;   // громкость фоновой музыки

    private const string settingsFilename = "Assets/Files/settings.txt";

    #region lifecycle
    void Start()
    {
        MenuContent   = GameObject.Find(nameof(MenuContent));
        MenuMessage   = GameObject.Find(nameof(MenuMessage)).GetComponent<TMPro.TextMeshProUGUI>();
        ButtonCaption = GameObject.Find(nameof(ButtonCaption)).GetComponent<TMPro.TextMeshProUGUI>();
        StatMessage   = GameObject.Find(nameof(StatMessage)).GetComponent<TMPro.TextMeshProUGUI>();

        bgMusic = this.GetComponent<AudioSource>();

        var MusicToggle  = GameObject.Find("MusicToggle")
                            .GetComponent<UnityEngine.UI.Toggle>();
        var MusicSlider  = GameObject.Find("MusicSlider")
                            .GetComponent<UnityEngine.UI.Slider>();
        var SoundsToggle = GameObject.Find("SoundsToggle")
                            .GetComponent<UnityEngine.UI.Toggle>();
        var SoundsSlider = GameObject.Find("SoundsSlider")
                            .GetComponent<UnityEngine.UI.Slider>();
        if (LoadSettings())
        {
            MusicToggle.isOn   = bgMusicEnabled;
            MusicSlider.value  = bgMusicVolume;
            SoundsToggle.isOn  = GameMenu.isSoundsEnabled;
            SoundsSlider.value = GameMenu.soundsVolume;
        }
        else
        {
            bgMusicEnabled = MusicToggle.isOn;
            bgMusicVolume  = MusicSlider.value;
            GameMenu.isSoundsEnabled = SoundsToggle.isOn;
            GameMenu.soundsVolume    = SoundsSlider.value;
        }
        UpdateBgMusic();

        Time.timeScale = MenuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameMenu.Toggle();
        }
    }

    private void OnDestroy()
    {
        SaveSettings();
    }
    #endregion

    #region event handlers
    public void MenuButtonClick()
    {
        GameMenu.Hide();
    }
    public void MusicToggleChanged(bool isChecked)
    {
        bgMusicEnabled = isChecked;
        UpdateBgMusic();
    }
    public void MusicVolumeChanged(float value)
    {
        bgMusicVolume = value;
        UpdateBgMusic();
    }
    public void SoundsToggleChanged(bool isChecked)
    {
        GameMenu.isSoundsEnabled = isChecked;
    }
    public void SoundsVolumeChanged(float value)
    {
        GameMenu.soundsVolume = value;
    }
    #endregion

    #region inner methods
    private void SaveSettings()
    {
        System.IO.File.WriteAllText(settingsFilename,
            $"{bgMusicEnabled};{bgMusicVolume};{isSoundsEnabled};{soundsVolume}"
        );
    }
    private bool LoadSettings()
    {
        if (System.IO.File.Exists(settingsFilename))
        {
            string[] data = System.IO.File.ReadAllText(settingsFilename).Split(";");
            try
            {
                bgMusicEnabled  = Convert.ToBoolean(data[0]);
                bgMusicVolume   = Convert.ToSingle(data[1]);
                isSoundsEnabled = Convert.ToBoolean(data[2]);
                soundsVolume    = Convert.ToSingle(data[3]);
                // Debug.Log(bgMusicEnabled +" "+ bgMusicVolume + " " + isSoundsEnabled  + " " + soundsVolume);
                return true;
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message);
            }            
        }
        return false;
    }

    private void UpdateBgMusic()
    {
        bgMusic.volume = bgMusicVolume;
        if (bgMusicEnabled) 
        { 
            if( ! bgMusic.isPlaying) bgMusic.Play(); 
        }
        else bgMusic.Stop();
    }
    public static void Show(
        string menuMessage = "Game paused", 
        string buttonText = "Continue")       // GameMenu.Show()
    {
        Time.timeScale = 0.0f;
        MenuMessage.text = menuMessage;
        ButtonCaption.text = buttonText;
        string cp1Text = GameStat.CheckPoint1Time switch { 
            -1f => "Failed",
            0   => "No contact",
            _   => GameStat.CheckPoint1Time.ToString("F1")
        };
        StatMessage.text = $"Time in game: {GameStat.GameTime:F1} s\nCheckpoint1: {cp1Text}";
        MenuContent.SetActive(true);

    }
    public static void Hide()                 // GameMenu.Hide()
    {
        MenuContent.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public static void Toggle()               // GameMenu.Toggle()
    {
        if (MenuContent.activeInHierarchy) GameMenu.Hide();
        else GameMenu.Show();
    }
    #endregion
}
/* Обеспечить появление/исчезновение меню по ESC
 * Реализовать обработчик события кнопки
 * 
 * При активации меню выводить статистику:
 * time in game: 01:02.1
 * checkpoint1:  pass @ 00:05.2
 * checkpoint2:  failed
 * checkpoint3:  inactive
 * Total score:  100500
 * 
 * Добавить регулировку скорости игры (слайдер),
 * технически меняющий timeScale
 * 
 * Settings: Настройки окружения
 * Звуковое сопровождение:
 * - фоновая музыка -- обеспечить вкл/выкл и регулировку громкости
 */
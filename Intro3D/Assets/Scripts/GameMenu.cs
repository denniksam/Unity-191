using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private static GameObject MenuContent;
    private static TMPro.TextMeshProUGUI MenuMessage;
    private static TMPro.TextMeshProUGUI ButtonCaption;
    private static TMPro.TextMeshProUGUI StatMessage;

    void Start()
    {
        MenuContent = GameObject.Find(nameof(MenuContent));
        MenuMessage = GameObject.Find(nameof(MenuMessage)).GetComponent<TMPro.TextMeshProUGUI>();
        ButtonCaption = GameObject.Find(nameof(ButtonCaption)).GetComponent<TMPro.TextMeshProUGUI>();
        StatMessage = GameObject.Find(nameof(StatMessage)).GetComponent<TMPro.TextMeshProUGUI>();

        Time.timeScale = MenuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameMenu.Toggle();
        }
    }

    public void MenuButtonClick()
    {
        GameMenu.Hide();
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
    public static void Toggle()              // GameMenu.Toggle()
    {
        if (MenuContent.activeInHierarchy) GameMenu.Hide();
        else GameMenu.Show();
    }

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
 */
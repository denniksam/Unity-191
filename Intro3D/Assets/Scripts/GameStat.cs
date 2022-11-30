using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    private static TMPro.TextMeshProUGUI Clock;
    private static UnityEngine.UI.Image Checkpoint1Image;
    private static UnityEngine.UI.Image Checkpoint2Image;

    private static float _gameTime;
    public static float GameTime
    {
        get => _gameTime;
        set
        {
            _gameTime = value;
            UpdateTime();
        }
    }

    private static float _checkpoint1Fill;
    public static float Checkpoint1Fill
    {
        get => _checkpoint1Fill;
        set
        {
            _checkpoint1Fill = value;
            UpdateCheckpoint1Fill();
        }
    }
    public static float CheckPoint1Time { get; set; } = 0;  // время прохождения CP1


    private static float _checkpoint2Fill;
    public static float Checkpoint2Fill
    {
        get => _checkpoint2Fill;
        set
        {
            _checkpoint2Fill = value;
            UpdateCheckpoint2Fill();
        }
    }

    void Start()
    {
        GameStat.Clock = GameObject.Find("Clock")
                        .GetComponent<TMPro.TextMeshProUGUI>();
        GameStat.Checkpoint1Image = GameObject.Find("CheckImage1")
                                    .GetComponent<UnityEngine.UI.Image>();
        GameStat.Checkpoint2Image = GameObject.Find("CheckImage2")
                                    .GetComponent<UnityEngine.UI.Image>();
    }

    void LateUpdate()
    {
        GameStat.GameTime += Time.deltaTime;
    }
    private static void UpdateTime()
    {
        int t = (int)_gameTime;
        GameStat.Clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((_gameTime - t) * 10):0}";
    }
    private static void UpdateCheckpoint1Fill()
    {
        if (Checkpoint1Fill >= 0 && Checkpoint1Fill <= 1)
        {
            GameStat.Checkpoint1Image.fillAmount = Checkpoint1Fill;
            // меняем цвет изображения в зависимости от заполнения
            GameStat.Checkpoint1Image.color = new Color(
                1 - Checkpoint1Fill,  // красный: больше, если fill меньше
                Checkpoint1Fill,      // зеленый: наоборот красному
                0.1f                  // синий: постоянный
            );
        }
        else
            Debug.LogError("Checkpoint1Fill value error: " + Checkpoint1Fill);
    }
    private static void UpdateCheckpoint2Fill()
    {
        if (Checkpoint2Fill >= 0 && Checkpoint2Fill <= 1)
            GameStat.Checkpoint2Image.fillAmount = Checkpoint2Fill;
        else
            Debug.LogError("Checkpoint2Fill value error: " + Checkpoint2Fill);
    }
    public static void PassCheckpoint1(bool status)
    {
        Checkpoint1Fill = 1;
        GameStat.Checkpoint1Image.color = status ? Color.green : Color.red;
        CheckPoint1Time = status ? GameTime : -1f;
    }
    public static void PassCheckpoint2(bool status)
    {
        Checkpoint2Fill = 1;
        GameStat.Checkpoint2Image.color = status ? Color.green : Color.red;
    }
}

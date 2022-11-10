using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   // TextMeshPro

public class Clock : MonoBehaviour
{
    private TextMeshProUGUI clock;   // ссылка на компонент TextMeshProUGUI
    private float time;

    void Start()
    {
        clock = GetComponent<TextMeshProUGUI>();  // получение ссылки на компонент

        time = 0;
    }

    
    void Update()
    {
        time += Time.deltaTime;        
    }

    private void LateUpdate()  // метод ЖЦ, вызывающийся позже всех
    {
        int t = (int)time;
        /* clock.text = string.Format(
            "{0:00}:{1:00}:{2:00}.{3:0}",
           t / 3600 % 24,
           t / 60 % 60,
           t % 60,
           (int)((time - t) * 10)); */
        clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((time - t) * 10):0}";
    }
}

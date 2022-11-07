using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    // Запускается один раз когда GameObject появляется на сцене
    void Start()
    {
        
    }

    // Запускается периодически UnityEngine-ом
    void Update()
    {
        // Скрипт является компонентом, то есть принадлежит GameObject (Hexagon)
        // ccылка this в скрипте указывает на "родительский" GameObject
        this.transform  // ссылка на компонент Transform GameObject (Hexagon)
            .Rotate(           // Вращение
            Vector3.forward,   // вокруг оси Z (forward)
            1);                // на 1 градус
    }
}
/*  Д.З. Установить Unity Hub, Unity Editor
 *  Настроить взаимодействие Unity и редактора кода (VS, Rider, ...)
 *  Создать 2D проект, реализовать активность, рассмотренную на занятии
 *  Добавить еще один спрайт, создать для него отдельный скрипт,
 *  обеспечить вращение нового спрайта в противоположную сторону.
 */
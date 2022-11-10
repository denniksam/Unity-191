using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;  // ссылка на компонент Rigidbody2D данного GameObject

    // Запускается один раз когда GameObject появляется на сцене
    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();  // сила прикладывается к тв.телу
    }

    void Update()
    {
        // приложение силы
        if (Input.GetKey(KeyCode.Space))  // GetKey - удержание, многократный учет
        {
            Rigidbody2D.AddForce(   // прикладываем силу
                Vector2.up * 10);   // 10 единиц в направлении вверх
            // Debug.Log("Force");
        }
    }

    // Запускается периодически UnityEngine-ом
    void UpdateDemo()
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
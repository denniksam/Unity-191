using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Поведение объектов, вышедших за пределы "экрана"
public class OutOfScreen : MonoBehaviour
{
    private GameObject SpawnPoint;  // ссылка на объект, задающий позицию появления

    void Start()
    {
        SpawnPoint = GameObject.Find("SpawnPoint");  // поиск объекта по имени (в иерархии)
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Destroy(other.gameObject);   // удаляем объект, вышедший за экран

        // if (other.gameObject.CompareTag("Tube"))   // выход трубы за пределы экрана
        // {
        //     other.gameObject.transform.position =      // переносим позицию объекта
        //         SpawnPoint.transform.position          // в точку появления
        //         + Vector3.up * Random.Range(-2f, 2f);  // + случайный сдвиг по вертикали
        // } 
        
    }
}
/* Твердое тело - кинематическое, коллайдер - триггер
 * 
 * Проблема: два коллайдера частей трубы срабатывают одновременно (из-за симметрии)
 * Как отличить первое это событие или нет / убрать второе событие:
 *  - pipe.SetActive(false); - не помогло, два события генерируются активным объектом,
 *     деактивация не убирает второе из них
 *  - GameObject.Destroy(pipe); - то же самое, удаление объекта происходит после
 *     того, как возникли оба события триггера
 *  - pipe.transform.Translate   +     
 *     (pipe.transform.position - this.transform.position).magnitude
 *       работает, второе событие показывает что объект уже перемещен
 */

/*
if (other.gameObject.CompareTag("Pipe"))   // выход трубы за пределы экрана
{
    // other.gameObject.transform.Translate(Vector2.right * 10); - перенос дочерних эл-тов
    // Родительский элемент определяется не через gameObject, а через transform
    GameObject pipe = other.transform.parent.gameObject;
    Debug.Log("OutOfScreen::Trigger " + 
        (pipe.transform.position - this.transform.position).magnitude );

    if((pipe.transform.position - this.transform.position).magnitude < 10)
    {
        pipe.transform.Translate(Vector2.right * 10);  // перенос родительского блока - трубы
    }

} */

/* Перенос VS Пересоздание
 * Перенос: + менее требователен к ресурсам
 *          - необходимо изначально создавать несколько объектов
 *          - нужно задавать расстояние между объектами, чувствительное к 
 *             изменениям размера экрана
 * Пересоздание: + Можно разделить процессы создания и удаления
 *               + Можно менять кол-во объектов на сцене
 *               + Скрипты переносимого объекта перезапускаются (Start())
 *               - Более ресурсоемко
 *               - Удаление ресурсов, возможных к повторному использованию
 *               
 * Особенности пересоздания:
 * Префаб - подготовленный шаблон, сохраненный объект со всеми компонентами
 * 
 */
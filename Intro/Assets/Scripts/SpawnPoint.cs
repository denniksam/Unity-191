using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Периодическая генерация новых объектов
public class SpawnPoint : MonoBehaviour
{
    // ссылка на префаб
    [SerializeField]
    private GameObject Pipe;
    private float PipeTime;
    private float PipeSpawnTime = 3;  // 3 секунды между трубами

    void Start()
    {
        PipeTime = 0;
    }

    void LateUpdate()
    {
        PipeTime -= Time.deltaTime;
        if(PipeTime < 0)
        {
            PipeTime = PipeSpawnTime;
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        GameObject.Instantiate(Pipe, this.transform.position, Quaternion.identity);
    }
}
/* Д.З. При столкновении птицы с трубой:
 *  - удалить все трубы
 *  - перевести птицу в исходное состояние (любой вариант: перенос или удалить/создать)
 *  - запустить "заново" генерацию и движение труб
 *  (сцену не перезапускать, нужно сохранять очки и прочую статистику)
 *  * изменять наклон птицы в зависимости от скорости движения (клювом вверх/вниз)
 */
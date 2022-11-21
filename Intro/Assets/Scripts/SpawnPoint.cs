using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Периодическая генерация новых объектов
public class SpawnPoint : MonoBehaviour
{
    // ссылки на префабы
    [SerializeField]
    private GameObject Pipe;
    [SerializeField]
    private GameObject Energy;

    private float PipeTime;
    private float PipeSpawnTime = 3;  // 3 секунды между трубами
    private float TimeRange = 4;      // диапазон изменения в зав. от сложности игры
    private float EnergyTime;
    private float EnergyFrequency = 1f/3f;   // частота появления энергии (1 раз на 3 трубы случайно)

    void Start()
    {
        PipeTime = 0;
        EnergyTime = 0;
    }

    void LateUpdate()
    {
        PipeTime -= Time.deltaTime;   // безусловный блок - постоянная генерация
        if(PipeTime < 0)
        {
            PipeTime = PipeSpawnTime + TimeRange * (1 - MenuCanvas.Difficulty);
            SpawnPipe();
            if(Random.value < EnergyFrequency)  // условие с вероятностью EnergyFrequency
            {
                EnergyTime = PipeTime / 2;
            }
        }

        if(EnergyTime > 0)  // условный блок - разовая генерация
        {
            EnergyTime -= Time.deltaTime;
            if(EnergyTime <= 0)
            {
                SpawnEnergy();
            }
        }
    }

    void SpawnPipe()
    {
        GameObject.Instantiate(Pipe, 
            this.transform.position + Vector3.up * Random.Range(-2f, 2f), 
            Quaternion.identity);
    }
    void SpawnEnergy()
    {
        GameObject.Instantiate(Energy, 
            this.transform.position + Vector3.up * Random.Range(-3f, 3f), 
            Quaternion.Euler(0,0,Random.value * 100));
    }
}
/* Д.З. При столкновении птицы с трубой:
 *  - удалить все трубы
 *  - перевести птицу в исходное состояние (любой вариант: перенос или удалить/создать)
 *  - запустить "заново" генерацию и движение труб
 *  (сцену не перезапускать, нужно сохранять очки и прочую статистику)
 *  * изменять наклон птицы в зависимости от скорости движения (клювом вверх/вниз)
 */
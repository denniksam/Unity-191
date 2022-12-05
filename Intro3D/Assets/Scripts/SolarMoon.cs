using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarMoon : MonoBehaviour
{
    [SerializeField] private GameObject Earth;
    [SerializeField] private GameObject Sun;

    private float period = 4;
    private float yearPeriod = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * 100 / period, 0);
        this.transform.RotateAround(Earth.transform.position, Earth.transform.up, Time.deltaTime * 100 / period);
        this.transform.RotateAround(Sun.transform.position, Sun.transform.up, Time.deltaTime * 100 / yearPeriod);  
    }
}
/* Луна!
 * Вращается вокруг своей оси с периодом вращения вокруг Земли
 * Вращается вокруг Земли
 * НО ! этих вращений недостаточно ! (проверяем закомментировав стр.22)
 * Луна еще также вращается вокруг Солнца с периодом Земли
 */

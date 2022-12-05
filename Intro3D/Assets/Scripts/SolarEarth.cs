using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarEarth : MonoBehaviour
{
    [SerializeField] private GameObject Earth;
    [SerializeField] private GameObject Atmosphere;
    [SerializeField] private GameObject Sun;

    private float dayPeriod  = 5f;
    private float yearPeriod = 10f;
    private float windPeriod = 2.5f;

    private Vector3 rotAxis;

    void Start()
    {
        rotAxis = new Vector3(1, 1, 0);  // Ось с наклоном 45 градусов
    }

    void Update()
    {
        // Earth.transform.Rotate(0, Time.deltaTime * 100 / dayPeriod, 0);
        Earth.transform.Rotate(rotAxis, Time.deltaTime * 100 / dayPeriod);
        Atmosphere.transform.Rotate(rotAxis, Time.deltaTime * 100 / windPeriod);
        this.transform.RotateAround(              // относительное вращение (не вокруг себя)
            Sun.transform.position,               // Центр круга вращения
            Sun.transform.up,                     // Ось вращения
            Time.deltaTime * 100 / yearPeriod);   // Угол поворота
    }
}
/* Земля вращается вокруг своей оси и вокруг Солнца
 * Атмосфера Земли вращается вокруг Земли
 * * угол оси Земли и плоскости орбиты - 23.5 градуса
 */
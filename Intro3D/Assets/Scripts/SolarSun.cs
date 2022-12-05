using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSun : MonoBehaviour
{
    private float period = 40;

    void Start()
    {
        
    }


    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * 100 / period, 0);
    }
}
/* Солнце вращается вокруг своей оси
 */
/* Солнечная система: 
 * Добавить планету Венера, реализовать поверхность и атмосферу
 * Обеспечить движение атмосферы, вращение планеты вокруг собственной оси
 *  и Солнца.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
        Rigidbody2D.centerOfMass = new Vector2(0, -.1f);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))  // GetKeyDown - однократный учет, зажатие не учитывается
        {
            Rigidbody2D.AddTorque(50);  // крутящий момент
            // Debug.Log("Torque");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Rigidbody2D.angularVelocity = 0;
        }
    }
}
/* Задание: ограничить все простанство "границами" чтобы объекты не выходили
 * за игровое поле.
 * Добавить физику для всех игровых объектов, проверить их взаимодействие при
 * столкновениях
 * Для одного из объектов реализовать приложение силы и вращательного момента
 * одновременно (силу под 45 градусов + вращение)
 * 
 * Д.З. Реализовать "выстрел из пушки": по нажатию клавиш  A - S - D производится
 * выстрел разной силы.
 * Добавить мишень в виде конструкции, которую можно разрушить попаданием ядра
 * 
 */

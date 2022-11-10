using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField]
    private float ForceMagnitude = 10;  // public и [SerializeField] поля доступны для изменения из редактора
                                        // причем значение из редактора имеет приоритет
    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");  // Величина "усилия" по осям:
        float dy = Input.GetAxis("Vertical");    // клавиши, джойстик, "стрелки"

        ForceDirection = new Vector2(ForceMagnitude * dx, ForceMagnitude * dy);
        Rigidbody2D.AddForce(ForceDirection);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collision " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger " + other.gameObject.name);
    }
}
/* Д.З. Реализовать ограничение времени на неподвижность объекта:
 * по прошествии 4сек объект, приносящий очки, меняет свое положение.
 * Выводить оставшееся время на экране (до десятых долей секунды)
 * ** Изменить алгоритм работы со случайным положением - переносить объект
 *     не ближе чем 3-4 единицы от шайбы
 */
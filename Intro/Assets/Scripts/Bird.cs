using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float ForceFactor = 10;

    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;
    private float holdTime;                 // время удержания пробела
    private const float holdTimeLimit = 1;  // предельное время удержания
    private const float discrete2continualFactor = 30;  // разница в однократном и постоянном действии
    private const float deltaTimeScaler = 100;  // множитель при deltaTime для коррекции на быстродейстие

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        ForceDirection = Vector2.up * ForceFactor;
        holdTime = 0;
        // this.transform.localScale = new Vector3(2, 2, 2);
    }

    void Update()

    {
        #region Непрерывное управление (постоянное нажатие)
        // if (Input.GetKey(KeyCode.Space))  // только с клавиатуры
        // {
        //     // Rigidbody2D.AddForce(ForceDirection); - зависит от частоты Update
        //     Rigidbody2D.AddForce(ForceDirection * Time.deltaTime * deltaTimeScaler);
        // }

        // float force = Input.GetAxis("Jump");  // с клавиатуры и джойстика
        // if(force != 0)
        //     Rigidbody2D.AddForce(ForceDirection * Time.deltaTime * deltaTimeScaler * force);
        #endregion

        #region Импульсное управление (однократные нажатия)
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Rigidbody2D.AddForce(ForceDirection * discrete2continualFactor);
        // }
        #endregion

        #region Гибридный режим
        // Сила растет при удержании пробела, но не дольше 1 секунды,
        //  дальнейшее удержание пробела игнорируется, требуется повторное нажатие
        // Более короткие нажатия - прилагают меньшую силу
        if (Input.GetKeyDown(KeyCode.Space)) holdTime = holdTimeLimit;
        if (Input.GetKey(KeyCode.Space) && holdTime > 0) holdTime -= Time.deltaTime;         
        if (Input.GetKeyUp(KeyCode.Space)) holdTime = 0;
        if (holdTime > 0)
            Rigidbody2D.AddForce(ForceDirection * Time.deltaTime * deltaTimeScaler);

        #endregion
    }
    // Задание: определить столкновение с трубой, вывести в консоль
    private void OnCollisionEnter2D(Collision2D other)
    {
       // if(other.gameObject.CompareTag("Pipe"))
       //     Debug.Log("Collision pipe: " + other.gameObject.name);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Camera cam;
    private Vector3 forceDirection;

    private float FORCE_MAGNITUDE = 2;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(rb.velocity.y == 0) rb.AddForce(Vector3.up * 100);
        }
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");       // стрелки "вверх,вниз" упраляют по Z
        // rb.AddForce(new Vector3(dx, 0, dy) * FORCE_MAGNITUDE);    // в векторе силы Y -> Z
        // корректируем на поворот камеры: вперед - это куда смотрит камера
        // rb.AddForce(cam.transform.forward * dy * FORCE_MAGNITUDE);
        forceDirection = cam.transform.forward;      // forward камеры наклонен вниз, усилия вдавливают/поднимают шарик
        forceDirection.y = 0;                        // убираем вертикальную составляющую вектора, но тогда его
        forceDirection = forceDirection.normalized   // длина уменьшается. normalized - сохраняет направление и задает длину 1
            * dy * FORCE_MAGNITUDE;                  // умножаем на ввод пользователя
        forceDirection += cam.transform.right        // right камеры не наклонен по Y, поэтому 
            * dx * FORCE_MAGNITUDE;                  // коррекции не нужны
        rb.AddForce(forceDirection);                 // 
    }
    
}
/* Д.З. Реализовать отсчет позиции камеры не от центра шарика, а от его верхней
 * точки (чуть выше поверхности). 
 * ** Расширить пределы zoom в область нуля (ноль - от первого лица, камера ровно над персонажем)
 *    (сложность - выход из нуля в направлении камеры)
 */
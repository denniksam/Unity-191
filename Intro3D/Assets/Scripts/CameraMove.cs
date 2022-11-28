using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject Sphere;      // ссылка на шарик
    private Vector3 cam_sphere;     // вектор камера-шарик
    private float mouseX;           // накопитель сдвигов мыши по Х
    private float mouseY;           // по Y
    private float zoom;             // приближение камеры

    private const float MAX_X_ANGLE = 70;        // предельные углы поворота
    private const float MIN_X_ANGLE = 30;        // камеры вокруг оси Х
    private const float SENSITIVITY_X = 2;       // чувствительность к мыши
    private const float SENSITIVITY_Y = 3;       // чувствительность к мыши
    private const float MAX_ZOOM = 1.5f;         // предельные значения приближения
    private const float MIN_ZOOM = 0.0f;         // камеры к шарику
    private const float SENSITIVITY_ZOOM = 10;   // чувствительность к колесу мыши


    void Start()
    {
        cam_sphere = this.transform.position - Sphere.transform.position;
        mouseY = this.transform.eulerAngles.x;
        zoom = 1;
    }

    private void Update()
    {
        // накопление данных о движении мыши
        mouseY -= SENSITIVITY_X * Input.GetAxis("Mouse Y");
        if (mouseY < MIN_X_ANGLE) mouseY = MIN_X_ANGLE;
        if (mouseY > MAX_X_ANGLE) mouseY = MAX_X_ANGLE;

        mouseX += SENSITIVITY_Y * Input.GetAxis("Mouse X");

        // поворот колеса мыши (scrolling)
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            zoom -= Input.mouseScrollDelta.y / SENSITIVITY_ZOOM;
            if (zoom < MIN_ZOOM) zoom = MIN_ZOOM;
            if (zoom > MAX_ZOOM) zoom = MAX_ZOOM;
        }
    }

    void LateUpdate()
    {
        // пересчитываем позицию камеры относительно шарика
        this.transform.position =              // cam_sphere - начальное взаимное положение
            Sphere.transform.position          // Новое положение - добавляем взаимное
            + Quaternion.Euler(0, mouseX, 0)   //  повернутое на горизонтальный угол
            * cam_sphere                       // 
            * zoom ;                           //  приближенное/удаленное в zoom раз
                                               // 
        // поворачиваем камеру
        this.transform.eulerAngles             // При повороте важно использовать eulerAngles,
            = new Vector3(                     //  а не transform.rotation, иначе можно получить
                mouseY,                        //  "завал горизонта" - вращение по оси Z
                mouseX,                        // А также обратить внимание на то, что
                0);                            //  эффект обзора по горизонтали - это вращение
    }                                          //  вокруг вертикальной оси (X <-> Y)
}
// ограничить угол поворота камеры вокруг Х в диапазоне 35..70 градусов
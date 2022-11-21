using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;

    private Vector2 moveDirection;

    void Start()
    {
        moveDirection = Vector2.left * Speed;
    }

    void Update()
    {
        // Обеспечить равномерное движение трубы влево
        this.transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }
}

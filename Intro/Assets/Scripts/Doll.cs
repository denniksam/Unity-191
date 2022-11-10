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
        if (Input.GetKeyDown(KeyCode.A))  // GetKeyDown - ����������� ����, ������� �� �����������
        {
            Rigidbody2D.AddTorque(50);  // �������� ������
            // Debug.Log("Torque");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Rigidbody2D.angularVelocity = 0;
        }
    }
}
/* �������: ���������� ��� ����������� "���������" ����� ������� �� ��������
 * �� ������� ����.
 * �������� ������ ��� ���� ������� ��������, ��������� �� �������������� ���
 * �������������
 * ��� ������ �� �������� ����������� ���������� ���� � ������������� �������
 * ������������ (���� ��� 45 �������� + ��������)
 * 
 * �.�. ����������� "������� �� �����": �� ������� ������  A - S - D ������������
 * ������� ������ ����.
 * �������� ������ � ���� �����������, ������� ����� ��������� ���������� ����
 * 
 */

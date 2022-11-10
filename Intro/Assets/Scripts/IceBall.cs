using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField]
    private float ForceMagnitude = 10;  // public � [SerializeField] ���� �������� ��� ��������� �� ���������
                                        // ������ �������� �� ��������� ����� ���������
    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");  // �������� "������" �� ����:
        float dy = Input.GetAxis("Vertical");    // �������, ��������, "�������"

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
/* �.�. ����������� ����������� ������� �� ������������� �������:
 * �� ���������� 4��� ������, ���������� ����, ������ ���� ���������.
 * �������� ���������� ����� �� ������ (�� ������� ����� �������)
 * ** �������� �������� ������ �� ��������� ���������� - ���������� ������
 *     �� ����� ��� 3-4 ������� �� �����
 */
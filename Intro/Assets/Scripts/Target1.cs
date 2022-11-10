using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreGui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            // Debug.Log("+2 pt");
            scoreGui.text = (int.Parse(scoreGui.text) + 2).ToString();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            scoreGui.text = (int.Parse(scoreGui.text) + 1).ToString();
            // Debug.Log("+1 pt");
        }
        float rX = Random.Range(-8f, 8f);
        float rY = Random.Range(-4f, 4f);
        this.transform.position = new Vector3(rX, rY, 0);        
    }
}
/* �������� �� ����� ��� ���� �� ���� ������ � ���������� ��� � Target1
 * (���������� ����� �������)
 * � ��� ���� � ���������� Target2 (���������� ���������)
 */
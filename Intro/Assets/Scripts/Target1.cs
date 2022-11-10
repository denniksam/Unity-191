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
/* Добавить на сцену еще хотя бы один объект с поведением как у Target1
 * (собирается через триггер)
 * и еще один с поведением Target2 (физическое поведение)
 */
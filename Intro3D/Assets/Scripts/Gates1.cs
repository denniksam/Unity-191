using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates1 : MonoBehaviour
{
    private const float timeout = 20;  // больше чем у чекпоинта
    private float timeleft;

    void Start()
    {
        timeleft = timeout;
    }

    void Update()
    {
        if(timeleft < 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x, 
                transform.localScale.y * (-1f/2 + timeleft/timeout), 
                transform.position.z);

            timeleft -= Time.deltaTime;
        }
    }
}
/* Д.З. Настроить движение Gates1 (только вниз, *периодически вверх-вниз)
 * Реализовать исчезновение ворот после контакта сферы и чекпоинта.
 */

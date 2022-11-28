using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private const float timeout = 5;   // 5 секунд на чекпоинт
    private float timeleft;

    void Start()
    {
        timeleft = timeout;
        image = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    void Update()
    {        
        if(timeleft < 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            image.fillAmount = timeleft / timeout;
            timeleft -= Time.deltaTime;
        }
    }
}
/* Эффект обратного таймера:
 * - создаем спрайт с круглой формой (берем Circle из прошлого 2D проекта
 *      можно взять любой рисунок круга)
 * - в Asset в инспекторе спрайта меняем TextureType - Sprite(2D / UI)   
 * - создаем Canvas, размещаем в WorldSpace, устанавливаем позицию 0-0-0 и размеры 1х1
 * - создаем Image, устанавливаем позицию 0-0-0 и размеры 1х1
 *    свойство SourceImage заполняем спрайтом с кругом
 *    ImageType -- Filled
 *    Method    -- radial 360
 * - масштабируем холст и помещаем поверх цилиндра-чекпоинта
 * - иерархически помещаем холст с рисунком в подчинение цилиндру
 * - отключаем рендер поверхности цилиндра, остается только Image
 */
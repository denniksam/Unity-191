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
            GameStat.PassCheckpoint1(false);
        }
        else
        {
            GameStat.Checkpoint1Fill = image.fillAmount = timeleft / timeout;
            image.color = new Color(1 - image.fillAmount, image.fillAmount, 0.1f);
            timeleft -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(this.gameObject);
        GameStat.PassCheckpoint1(true);
    }
}
/* Отображение информации (3D)
 * реализовать действие (убрать преграду 2) при успешном прохождении
 *   чекпоинта 2
 * реализовать третий чекпоинт: его активацию, обратный отсчет, дублирование
 *   на холсте.
 * Добавить текстовое поле для отображения набранных очков
 * ** Реализовать систему накопления очков в зависимости от пройденных
 *    чекпоинтов и времени их прохождения (чем раньше, тем больше очков)
 */
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
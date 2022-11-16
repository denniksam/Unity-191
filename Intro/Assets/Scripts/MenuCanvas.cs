using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт меню пользователя
public class MenuCanvas : MonoBehaviour
{
    public static int ControlTypeIndex;   // стат. поле позволят обращаться к классу 
                                          // (не искать объект из других скриптов)
    [SerializeField]
    private GameObject UserMenu;

    [SerializeField]
    private TMPro.TextMeshProUGUI ResumeButtonText;

    [SerializeField]
    private TMPro.TMP_Dropdown ChangeTypeDropdown;

    void Start()
    {
        ControlTypeIndex = 0;

        if (UserMenu.activeInHierarchy)
        {
            ShowMenu(true, "Start");
        }
    }
    
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu( ! UserMenu.activeInHierarchy);
        }
    }

    public void ResumeButtonClick()
    {
        // Debug.Log("Resume clicked");
        ShowMenu(false);
    }

    public void ControlTypeChanged(int value)
    {
        Debug.Log(ChangeTypeDropdown.value);
        ControlTypeIndex = ChangeTypeDropdown.value;   // сохраняем стат. поле
    }

    private void ShowMenu(bool mode, string buttonText = "Resume")
    {
        if (mode)   // режим отображения меню
        {
            UserMenu.SetActive(true);            // Отображаем контейнер меню (все эл-ты)
            Time.timeScale = 0;                  // Останавливаем физическое время
            ResumeButtonText.text = buttonText;  // Устанавливаем надпись кнопке
        }
        else
        {
            UserMenu.SetActive(false);           // Скрываем контейнер меню
            Time.timeScale = 1;                  // Запускаем физическое время
        }
    }
}
/* Кнопки и события
 * 1. Кнопка - элемент UI и размещается на холсте.
 * 2. Кнопка состоит из двух элементов: кнопка и дочерний эл-т "текст"/текстПро
 *     Надпись на кнопке задается через "текст"
 *     Событие - через кнопку
 * 3. Для создания обработчика нажатия кнопки нужно в каком-либо скрипте
 *     создать public void () метод
 *    А в элементе кнопки добавить обработчик (+), выбрать объект (GameObject),
 *     на котором размещен скрипт с обработчиком, выбрать обработчик
 */
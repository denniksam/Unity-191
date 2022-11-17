using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт меню пользователя
public class MenuCanvas : MonoBehaviour
{
    public static int ControlTypeIndex;   // стат. поле позволят обращаться к классу 
                                          // (не искать объект из других скриптов)
    public static float Difficulty;

    [SerializeField]
    private GameObject UserMenu;

    [SerializeField]
    private TMPro.TextMeshProUGUI ResumeButtonText;

    [SerializeField]
    private TMPro.TMP_Dropdown ChangeTypeDropdown;

    [SerializeField]
    private TMPro.TextMeshProUGUI MessageUGUI;

    private GameStat gameStat;   // ссылка на объект класса GameStat, находящийся на холсте "GameStat"

    void Start()
    {
        ControlTypeIndex = 0;

        gameStat =                        // Объект класса GameStat - это компонент
            GameObject.Find("GameStat")   // GameObject-а "GameStat" (холста)
            .GetComponent<GameStat>();    // 

        if (UserMenu.activeInHierarchy)
        {
            ShowMenu(true, "Start");
        }
    }
    
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UserMenu.activeInHierarchy) {
                ShowMenu(false);
            }
            else
            {
                ShowMenu(true, message: "Game paused @ time " + gameStat.GameTime );
            }
        }
    }

    public void ResumeButtonClick()
    {
        // Debug.Log("Resume clicked");
        ShowMenu(false);
    }

    public void ControlTypeChanged(int value)
    {
        // Debug.Log(ChangeTypeDropdown.value);
        MenuCanvas.ControlTypeIndex = ChangeTypeDropdown.value;   // сохраняем стат. поле
    }
    public void DifficultyChanged(float value)
    {
        // Debug.Log(value);
        MenuCanvas.Difficulty = value;
    }

    private void ShowMenu(bool mode, string buttonText = "Resume", string message = "")
    {
        if (mode)   // режим отображения меню
        {
            UserMenu.SetActive(true);            // Отображаем контейнер меню (все эл-ты)
            Time.timeScale = 0;                  // Останавливаем физическое время
            ResumeButtonText.text = buttonText;  // Устанавливаем надпись кнопке
            MessageUGUI.text = message;          // текст главного сообщения
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
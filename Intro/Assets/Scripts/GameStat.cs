using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private UnityEngine.UI.Image energy;  // EnergyIndicator - filled-type image


    private float _gameTime;
    private float _gameEnergy;   // [0..1] value
    public float GameTime { 
        get => _gameTime;
        set
        {
            _gameTime = value;
            UpdateUiTime();
        }
    }
    public float GameEnergy { 
        get => _gameEnergy;
        set
        {
            _gameEnergy = value;
            UpdateUiEnergy();
        }
    }

    void Start()
    {
        GameTime = 0;
        GameEnergy = energy.fillAmount;   // TODO: зависимость от сложности
    }
    void LateUpdate()
    {
        GameTime += Time.deltaTime;
    }

    private void UpdateUiTime()
    {
        int t = (int)_gameTime;
        clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((_gameTime - t) * 10):0}";
    }
    private void UpdateUiEnergy()
    {
        if(_gameEnergy >=0 && _gameEnergy <= 1)
        {
            energy.fillAmount = _gameEnergy;
        }
        else
        {
            Debug.LogError("Game Energy ot of range: " + _gameEnergy);
        }
    }
}

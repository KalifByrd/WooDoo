using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DPUtils.Systems.DateTime;

public class ClockManager : MonoBehaviour
{
    public TextMeshProUGUI Date, Time, Season, Week;

    public Image weatherSprite;
    public Sprite[] weatherSprites;

    public void OnEnable()
    {
        TimeManager.OnDateTimeChanged +=  UpdateDateTime;
    }
    public void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(DateTime dateTime)
    {
        Date.text = dateTime.DateToString();
        Time.text = dateTime.TimeToString();
        Season.text = dateTime.Season.ToString();
        Week.text = $"WK: {dateTime.CurrentWeek}";
        //weatherSprite.sprite = weatherSprites[(int)WeatherManager.currentWeather];

        float t = (float)dateTime.Hour / 24f;
    }
    
}

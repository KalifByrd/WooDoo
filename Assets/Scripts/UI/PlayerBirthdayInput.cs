using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerBirthdayInput : MonoBehaviour
{
    public GameObject player;
    public int currentBirthMonth;
    public int currentBirthDay;
    public string currentBirthDate;
    public GameObject acceptBtn;
    public TMP_Text monthText;
    public TMP_Text dayText;
    public GameObject errorMessage;
    public GameManager gameManager;
    public DialogueData whisperIntro3Dialogue;
    public GameObject birthdaySelection;
    private Dictionary<int, string> monthNames = new Dictionary<int, string>
    {
        {1, "Jan."},
        {2, "Feb."},
        {3, "March"},
        {4, "April"},
        {5, "May"},
        {6, "June"},
        {7, "July"},
        {8, "Aug."},
        {9, "Sep."},
        {10, "Oct."},
        {11, "Nov."},
        {12, "Dec."},
    };
    private Dictionary<int, int> maxDates = new Dictionary<int, int>
    {
        {1, 31},
        {2, 29},
        {3, 31},
        {4, 30},
        {5, 31},
        {6, 30},
        {7, 31},
        {8, 31},
        {9, 30},
        {10, 31},
        {11, 30},
        {12, 31},
    };

    private struct ZodiacRange
    {
        public int startMonth;
        public int startDay;
        public int endMonth;
        public int endDay;
        public string zodiacSign;
        public ZodiacRange(int startMonth, int startDay, int endMonth, int endDay, string zodiacSign)
        {
            this.startMonth = startMonth;
            this.startDay = startDay;
            this.endMonth = endMonth;
            this.endDay = endDay;
            this.zodiacSign = zodiacSign;
        }
    }

    private ZodiacRange[] zodiacRanges = new ZodiacRange[]
    {
        new ZodiacRange(12, 22, 1, 19, "Capricorn"), // Capricorn
        new ZodiacRange(1, 20, 2, 18, "Aquarius"), // Aquarius
        new ZodiacRange(2, 19, 3, 20, "Pisces"), // Pisces
        new ZodiacRange(3, 21, 4, 19, "Aries"), // Aries
        new ZodiacRange(4, 20, 5, 20, "Taurus"), // Taurus
        new ZodiacRange(5, 21, 6, 20, "Gemini"), // Gemini
        new ZodiacRange(6, 21, 7, 22, "Cancer"), // Cancer
        new ZodiacRange(7, 23, 8, 22, "Leo"), // Leo
        new ZodiacRange(8, 23, 9, 22, "Virgo"), // Virgo
        new ZodiacRange(9, 23, 10, 22, "Libra"), // Libra
        new ZodiacRange(10, 23, 11, 21, "Scorpio"), // Scorpio
        new ZodiacRange(11, 22, 12, 21, "Sagittarius"), // Sagittarius
    };
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Month"))
        {
            TMP_Text textMesh = other.gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>();
            string text = textMesh.text;
            int.TryParse(text, out int month);
            currentBirthMonth = month;

            Debug.Log("A month has entered the trigger! " + currentBirthMonth);
               
            
        }
        else if(other.CompareTag("Day"))
        {
            TMP_Text textMesh = other.gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>();
            string text = textMesh.text;
            int.TryParse(text, out int day);
            currentBirthDay = day;

            Debug.Log("A day has entered the trigger! " + currentBirthDay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // --------------------------------Months--------------------------------- \\
        if(currentBirthMonth == null || currentBirthMonth == 0) // Invalid Month
        {
            acceptBtn.SetActive(false);
            monthText.text = "Month";
        }
        else if(monthNames.TryGetValue(currentBirthMonth, out string monthName))
        {
            acceptBtn.SetActive(true);
            monthText.text = monthName;
        }
        
        // --------------------------------Days--------------------------------- \\
        if(currentBirthDay == null || currentBirthDay == 0) // Invalid Day
        {
            acceptBtn.SetActive(false);
            dayText.text = "Day";
        }
        else
        {
            acceptBtn.SetActive(true);
            dayText.text = "Day: " + currentBirthDay.ToString();
        }
    }

    private string GetStarSign()
    {
        for(int i = 0; i < zodiacRanges.Length; i++)
        {
            ZodiacRange range = zodiacRanges[i];
            if((currentBirthMonth == range.startMonth && currentBirthDay >= range.startDay) ||
                (currentBirthMonth == range.endMonth && currentBirthDay <= range.endDay))
            {
                return range.zodiacSign;
            }
        }
        return "unknown";
    }

    public void AcceptButton()
    {
        if(maxDates.TryGetValue(currentBirthMonth, out int maxDay) && currentBirthDay > maxDay)
        {
            errorMessage.SetActive(true);
            gameManager.Wait(3);
            errorMessage.SetActive(false);
        }
        else
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            playerManager.birthMonth = currentBirthMonth;
            playerManager.birthDay = currentBirthDay;
            playerManager.starSign = GetStarSign();
            gameManager.Whisper.GetComponent<Starfolk>().dialogue = whisperIntro3Dialogue;
            birthdaySelection.SetActive(false);
            gameManager.ui.currentStarfolk = gameManager.Whisper.GetComponent<Starfolk>();
            gameManager.ui.SetCharNameAndColor();
            gameManager.ui.inDialogue = true;
            gameManager.ui.ClearText();
            gameManager.ui.FadeUI(true, .2f, .65f);
        }
    }
}

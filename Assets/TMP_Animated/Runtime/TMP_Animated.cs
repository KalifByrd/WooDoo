using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
    public enum Emotion { happy, sad, suprised, angry };
    public enum Bubble {normal, suprised, think };
    public enum Options {next, hide, name, birth, island, cc, tut1, tut2, tut3, tut4, tut5, tut6, tut7, tut8, tut9, tut10, tut11};
    public enum Name {player};
    public enum Zodiac {player};
    [System.Serializable] public class EmotionEvent : UnityEvent<Emotion> { }

    [System.Serializable] public class ActionEvent : UnityEvent<string> { }
    [System.Serializable] public class GetNameEvent : UnityEvent<Name> { }
    [System.Serializable] public class ZodiacDialogueEvent : UnityEvent<Zodiac> { }

    [System.Serializable] public class BubbleEvent : UnityEvent<Bubble> { }

    [System.Serializable] public class OptionsEvent : UnityEvent<Options> { }

    [System.Serializable] public class TextRevealEvent : UnityEvent<char> { }

    [System.Serializable] public class DialogueEvent : UnityEvent { }

    public class TMP_Animated : TextMeshProUGUI
    {

        [SerializeField] private float speed = 10;
        public EmotionEvent onEmotionChange;
        public ActionEvent onAction;
        public BubbleEvent onBubbleChange;
        public OptionsEvent onOptions;
        public TextRevealEvent onTextReveal;
        public DialogueEvent onDialogueFinish;
        public GetNameEvent onGetName;
        public string entityName;
        public string playerStarSign;
        public ZodiacDialogueEvent onGetZodiacDialogue;
        private Dictionary<string, string> zodiacDialogue = new Dictionary<string, string>
        {
            {"Aries", "Aries, independent, courageous, dynamic!"},
            {"Taurus", "Taurus, reliable, patient, sensual!"},
            {"Gemini", "Gemini, versatile, curious, expressive!"},
            {"Cancer", "Cancer, nurturing, intuitive, protective!"},
            {"Leo", "Leo, confident, charismatic, creative!"},
            {"Virgo", "Virgo, detail-oriented, analytical, practical!"},
            {"Libra", "Libra, diplomatic, social, fair-minded!"},
            {"Scorpio", "Scorpio, intense, resourceful, determined!"},
            {"Sagittarius", "Sagittarius, adventurous, optimistic, philosophical!"},
            {"Capricorn", "Capricorn, ambitious, disciplined, responsible!"},
            {"Aquarius", "Aquarius, unique, humanitarian, innovative!"},
            {"Pisces", "Pisces, intuitive, empathetic, imaginative!"},
        };

        private string ReplaceNameTag(string text, string name)
        {
            // Replace the <name> tag with the actual player name
            return text.Replace("[name*****]", name);
        }
        private string ReplaceZodiacTag(string text)
        {
            if(zodiacDialogue.TryGetValue(playerStarSign, out string zodiacDialogueString))
            {
                return text.Replace("[zodiac dialogue*******************************]", zodiacDialogueString);
            }
            else
            {
                return "unknown";
            }
            
        }
        public void ReadText(string newText)
        {
            text = string.Empty;
            // split the whole text into parts based off the <> tags 
            // even numbers in the array are text, odd numbers are tags
            string[] subTexts = newText.Split('<', '>');

            // textmeshpro still needs to parse its built-in tags, so we only include noncustom tags
            string displayText = "";
            for (int i = 0; i < subTexts.Length; i++)
            {
                Debug.Log(subTexts[i]);
                if (i % 2 == 0)
                    displayText += subTexts[i];
                else if (!isCustomTag(subTexts[i].Replace(" ", "")))
                    displayText += $"<{subTexts[i]}>";
            }
            
            // check to see if a tag is our own
            bool isCustomTag(string tag)
            {
                return tag.StartsWith("speed=") || tag.StartsWith("pause=") || tag.StartsWith("emotion=") || tag.StartsWith("action") || tag.StartsWith("bubble=") || tag.StartsWith("options=") || tag.StartsWith("name=") || tag.StartsWith("zodiac=");
            }

            

            // send that string to textmeshpro and hide all of it, then start reading
            text = displayText;
            maxVisibleCharacters = 0;
            StartCoroutine(Read());

            IEnumerator Read()
            {
                int subCounter = 0;
                int visibleCounter = 0;
                while (subCounter < subTexts.Length)
                {
                    // if 
                    if (subCounter % 2 == 1)
                    {
                        yield return EvaluateTag(subTexts[subCounter].Replace(" ", ""));
                    }
                    else
                    {
                        while (visibleCounter < subTexts[subCounter].Length)
                        {
                            onTextReveal.Invoke(subTexts[subCounter][visibleCounter]);
                            visibleCounter++;
                            maxVisibleCharacters++;
                            yield return new WaitForSeconds(1f / speed);
                        }
                        visibleCounter = 0;
                    }
                    subCounter++;
                }
                yield return null;

                WaitForSeconds EvaluateTag(string tag)
                {
                    if (tag.Length > 0)
                    {
                        if (tag.StartsWith("speed="))
                        {
                            speed = float.Parse(tag.Split('=')[1]);
                        }
                        else if (tag.StartsWith("pause="))
                        {
                            return new WaitForSeconds(float.Parse(tag.Split('=')[1]));
                        }
                        else if (tag.StartsWith("emotion="))
                        {
                            onEmotionChange.Invoke((Emotion)System.Enum.Parse(typeof(Emotion), tag.Split('=')[1]));
                        }
                        else if (tag.StartsWith("action="))
                        {
                            onAction.Invoke(tag.Split('=')[1]);
                        }
                        else if (tag.StartsWith("bubble="))
                        {
                            onBubbleChange.Invoke((Bubble)System.Enum.Parse(typeof(Bubble), tag.Split('=')[1]));
                        }
                        else if (tag.StartsWith("options="))
                        {
                            onOptions.Invoke((Options)System.Enum.Parse(typeof(Options), tag.Split('=')[1]));
                        }
                        else if (tag.StartsWith("name="))
                        {
                            onGetName.Invoke((Name)System.Enum.Parse(typeof(Name), tag.Split('=')[1]));
                            text = ReplaceNameTag(text, entityName);
                            
                            
                        }
                        else if (tag.StartsWith("zodiac="))
                        {
                            onGetZodiacDialogue.Invoke((Zodiac)System.Enum.Parse(typeof(Zodiac), tag.Split('=')[1]));
                            text = ReplaceZodiacTag(text);
                        }
                    }
                    return null;
                }
                onDialogueFinish.Invoke();
            }
        }
    }
}
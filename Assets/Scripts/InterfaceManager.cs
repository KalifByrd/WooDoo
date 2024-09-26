using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using DG.Tweening;

public class InterfaceManager : MonoBehaviour
{
    public bool inDialogue;
    public static InterfaceManager instance;

    public CanvasGroup canvasGroup;
    public TMP_Animated animatedText;
    public Image nameBubble;
    public RawImage currentDialogueBubble;
    public RawImage defaultDialogueBubble;
    public RawImage suprisedDialogueBubble;
    public RawImage thinkDialogueBubble;

    public GameObject nameSelection;
    public GameObject birthdaySelection;
    public TextMeshProUGUI nameTMP;

    [HideInInspector]
    public Starfolk currentStarfolk;

    private int dialogueIndex;
    public bool canExit;
    public bool nextDialogue;

    [Space]
    [Header("Cameras")]
    public GameObject gameCam;
    public GameObject dialogueCam;

    [Space]

    public Volume dialogueDof;

    public GameObject nextDialogueBtn;
    public GameObject nameDialogueBtn;
    public GameObject birthDialogueBtn;
    public GameObject islandDialogueBtn;
    public GameObject ccDialogueBtn;

    public GameObject tut1Options;
    public GameObject tut2Options;
    public GameObject tut3Options;
    public GameObject tut4Options;
    public GameObject tut5Options;
    public GameObject tut6Options;
    public GameObject tut7Options;
    public GameObject tut8Options;
    public GameObject tut9Options;
    public GameObject tut10Options;
    public GameObject tut11Options;

    public GameManager gameManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animatedText.onDialogueFinish.AddListener(() => FinishDialogue());
        animatedText.onBubbleChange.AddListener((newBubble) => ChangeDialogueBubble(newBubble));
        animatedText.onOptions.AddListener((newOption) => ChangeOptions(newOption));
        animatedText.onGetName.AddListener((newName) => GetName(newName));
        animatedText.onGetZodiacDialogue.AddListener((newZodiacDialogue) => GetZodiacDialogue(newZodiacDialogue));

    }

    public void NextDialogueBtn()
    {
        if (inDialogue)
        {
            if (canExit)
            {
                CameraChange(false);
                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
            }

            if (nextDialogue)
            {
                animatedText.ReadText(currentStarfolk.dialogue.conversationBlock[dialogueIndex]);
            }
        }
    }
    public void NameDialogueBtn()
    {
        if (inDialogue)
        {
            if (canExit)
            {
                //CameraChange(false);
                nameSelection.SetActive(true);

                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
                canExit = false;
            }
        }
    }
    public void BirthdayDialogueBtn()
    {
        if (inDialogue)
        {
            if (canExit)
            {
                //CameraChange(false);
                birthdaySelection.SetActive(true);

                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
                canExit = false;
            }
        }
    }
    public void CCDialogueBtn()
    {
        if (inDialogue)
        {
            if (canExit)
            {
                //CameraChange(false);
                gameManager.Vail.SetActive(false);
                gameManager.DialogueBubble.SetActive(false);

                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
                canExit = false;
            }
        }
    }
    

    public void FadeUI(bool show, float time, float delay)
    {
        Sequence s = DOTween.Sequence();
        s.AppendInterval(delay);
        s.Append(canvasGroup.DOFade(show ? 1 : 0, time));
        if (show)
        {
            dialogueIndex = 0;
            s.Join(canvasGroup.transform.DOScale(0, time * 2).From().SetEase(Ease.OutBack));
            s.AppendCallback(() =>
            {
                animatedText.ReadText(currentStarfolk.dialogue.conversationBlock[0]);
            });
                
        }
    }

    public void SetCharNameAndColor()
    {
        nameTMP.text = currentStarfolk.data.starfolkName;
        nameTMP.color = currentStarfolk.data.starfolkNameColor;
        //nameBubble.color = currentStarfolk.data.starfolkColor;

    }

    public void CameraChange(bool dialogue)
    {
        gameCam.SetActive(!dialogue);
        dialogueCam.SetActive(dialogue);

        //Depth of field modifier
        float dofWeight = dialogueCam.activeSelf ? 1 : 0;
        DOVirtual.Float(dialogueDof.weight, dofWeight, .8f, DialogueDOF);
    }

    public void DialogueDOF(float x)
    {
        dialogueDof.weight = x;
    }

    public void ClearText()
    {
        animatedText.text = string.Empty;
    }

    public void ResetState()
    {
        currentStarfolk.Reset();
        FindObjectOfType<AnimationAndMovementController>().enabled = true;
        inDialogue = false;
        canExit = false;
    }

    public void FinishDialogue()
    {
        if (dialogueIndex < currentStarfolk.dialogue.conversationBlock.Count - 1)
        {
            dialogueIndex++;
            nextDialogue = true;
        }
        else
        {
            nextDialogue = false;
            canExit = true;
        }
    } 

    public void ChangeDialogueBubble(Bubble bubble)
    {
        if(bubble == Bubble.normal)
        {
            currentDialogueBubble = defaultDialogueBubble;
        }
        if(bubble == Bubble.suprised)
        {
            currentDialogueBubble = suprisedDialogueBubble;
        }
        if(bubble == Bubble.think)
        {
            currentDialogueBubble = thinkDialogueBubble;
        }

    }

    public void ChangeOptions(Options option)
    {
        if(option == Options.next)
        {
            nextDialogueBtn.SetActive(true);
        }
        if(option == Options.hide)
        {
            if(nextDialogueBtn.activeInHierarchy == true)
            {
                nextDialogueBtn.SetActive(false);
            }
            if(nameDialogueBtn.activeInHierarchy == true)
            {
                nameDialogueBtn.SetActive(false);
            }
            if(birthDialogueBtn.activeInHierarchy == true)
            {
                birthDialogueBtn.SetActive(false);
            }
            if(ccDialogueBtn.activeInHierarchy == true)
            {
                ccDialogueBtn.SetActive(false);
            }
            
        }
        if(option == Options.name)
        {
            nameDialogueBtn.SetActive(true);
        }
        if(option == Options.birth)
        {
            birthDialogueBtn.SetActive(true);
        }
        if(option == Options.island)
        {
            islandDialogueBtn.SetActive(true);
        }
        if(option == Options.cc)
        {
            ccDialogueBtn.SetActive(true);
        }
        if(option == Options.tut1)
        {
            tut1Options.SetActive(true);
        }
        if(option == Options.tut2)
        {
            tut2Options.SetActive(true);
        }
        if(option == Options.tut3)
        {
            tut3Options.SetActive(true);
        }
        if(option == Options.tut4)
        {
            tut4Options.SetActive(true);
        }
        if(option == Options.tut5)
        {
            tut5Options.SetActive(true);
        }
        if(option == Options.tut6)
        {
            tut6Options.SetActive(true);
        }
        if(option == Options.tut7)
        {
            tut7Options.SetActive(true);
        }
        if(option == Options.tut8)
        {
            tut8Options.SetActive(true);
        }
        if(option == Options.tut9)
        {
            tut9Options.SetActive(true);
        }
        if(option == Options.tut10)
        {
            tut10Options.SetActive(true);
        }
        if(option == Options.tut11)
        {
            tut11Options.SetActive(true);
        }
    }

    public void GetName(Name entity)
    {
        if(entity == Name.player)
        {
            animatedText.entityName = gameManager.newPlayer.GetComponent<PlayerManager>().playerName;
        }
    }
    public void GetZodiacDialogue(Zodiac entity)
    {
        if(entity == Zodiac.player)
        {
            animatedText.playerStarSign = gameManager.newPlayer.GetComponent<PlayerManager>().starSign;
        }
    }
}

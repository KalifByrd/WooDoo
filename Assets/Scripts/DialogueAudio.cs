using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAudio : MonoBehaviour
{
    private Starfolk starfolk;
    private TMP_Animated animatedText;
    public Material mouthMaterial;

    public AudioClip[] voices;
    public AudioClip[] punctuations;
    [Space]
    public AudioSource voiceSource;
    public AudioSource punctuationSource;
    public AudioSource effectSource;

    [Space]
    public AudioClip sparkleClip;
    public AudioClip rainClip;


    // Start is called before the first frame update
    void Start()
    {
        starfolk = GetComponent<Starfolk>();

        animatedText = InterfaceManager.instance.animatedText;

        animatedText.onTextReveal.AddListener((newChar) => ReproduceSound(newChar));
    }

    public void ReproduceSound(char c)
    {

        if (starfolk != InterfaceManager.instance.currentStarfolk)
            return;

        if (char.IsPunctuation(c) && !punctuationSource.isPlaying)
        {
            voiceSource.Stop();
            punctuationSource.clip = punctuations[Random.Range(0, punctuations.Length)];
            punctuationSource.Play();
        }

        if (char.IsLetter(c) && !voiceSource.isPlaying)
        {
            punctuationSource.Stop();
            voiceSource.clip = voices[Random.Range(0, voices.Length)];
            voiceSource.Play();

            // mouthQuad.localScale = new Vector3(1, 0, 1);
            // mouthQuad.DOScaleY(1, .2f).OnComplete(() => mouthQuad.DOScaleY(0, .2f));
        }

    }
}

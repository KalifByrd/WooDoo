using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Eyebrows : MonoBehaviour, IPointerClickHandler
{
    public Dictionary<string, Material> eyebrowsMap= new Dictionary<string, Material>();
    public Material angry_small_eyebrows;
    public Material bird_eyebrows;
    public Material fine_eyebrows;
    public Material geisha_eyebrows;
    public Material small_eyebrows;
    public Material squiggly_eyebrows;
    public Material thicc_eyebrows;
    public Material thin_eyebrows;
    public Material tj_eyebrows;
    public Material tj_sad_eyebrows;

    private GameObject player;
    private GameObject BODY;
   
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;

        eyebrowsMap.Add("ANGRY_SMALL_eyebrows", angry_small_eyebrows);
        eyebrowsMap.Add("BIRD_eyebrows", bird_eyebrows);
        eyebrowsMap.Add("FINE_eyebrows", fine_eyebrows);
        eyebrowsMap.Add("GEISHA_eyebrows", geisha_eyebrows);
        eyebrowsMap.Add("SMALL_eyebrows", small_eyebrows);
        eyebrowsMap.Add("SQUIGGLY_eyebrows", squiggly_eyebrows);
        eyebrowsMap.Add("THICC_eyebrows", thicc_eyebrows);
        eyebrowsMap.Add("THIN_eyebrows", thin_eyebrows);
        eyebrowsMap.Add("TJ_eyebrows", tj_eyebrows);
        eyebrowsMap.Add("TJ_SAD_eyebrows", tj_sad_eyebrows);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string eyebrowsName = gameObject.name;
        gameManager.selectedEyebrowIcon = eyebrowsName;
        if(eyebrowsMap.ContainsKey(eyebrowsName))
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[5] = eyebrowsMap[eyebrowsName];
            bodyRenderer.sharedMaterials = materials;
        }
    }
}

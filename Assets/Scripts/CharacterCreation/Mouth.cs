using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouth : MonoBehaviour, IPointerClickHandler
{
    public Dictionary<string, Material> mouthMap= new Dictionary<string, Material>();
    public Material normal_mouth;
    public Material turtle_mouth;
    public Material cat_mouth;
    public Material nervous_mouth;
    public Material hello_mouth;
    public Material smile_mouth;
    public Material happy_mouth;
    public Material sad_mouth;
    public Material frown_mouth;
    public Material agd_mouth;
    public Material babybat_mouth;
    public Material bat_mouth;

    private GameObject player;
    private GameObject BODY;
   
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;

        mouthMap.Add("NORMAL_mouth", normal_mouth);
        mouthMap.Add("TURTLE_mouth", turtle_mouth);
        mouthMap.Add("CAT_mouth", cat_mouth);
        mouthMap.Add("NERVOUS_mouth", nervous_mouth);
        mouthMap.Add("HELLO_mouth", hello_mouth);
        mouthMap.Add("SMILE_mouth", smile_mouth);
        mouthMap.Add("HAPPY_mouth", happy_mouth);
        mouthMap.Add("SAD_mouth", sad_mouth);
        mouthMap.Add("FROWN_mouth", frown_mouth);
        mouthMap.Add("AGD_mouth", agd_mouth);
        mouthMap.Add("BABYBAT_mouth", babybat_mouth);
        mouthMap.Add("BAT_mouth", bat_mouth);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string mouthName = gameObject.name;
        if(mouthMap.ContainsKey(mouthName))
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[2] = mouthMap[mouthName];
            bodyRenderer.sharedMaterials = materials;
        }
    }
}

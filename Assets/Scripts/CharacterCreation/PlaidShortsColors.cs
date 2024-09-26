using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaidShortsColors : MonoBehaviour, IPointerClickHandler
{
    public Material plaidShortsBottom_black;
    public Material plaidShortsBottom_navy;
    public Material plaidShortsBottom_purple;
    public Material plaidShortsBottom_green;
    public Material plaidShortsBottom_brown;
    public Material plaidShortsBottom_mocha;
    public Material plaidShortsBottom_blue;
    public Material plaidShortsBottom_pink;
    public Dictionary<string, Material> colorMap= new Dictionary<string, Material>();
    public GameObject player;
    public GameObject BODY;
    private GameObject wornLegs;
    private GameObject parent;
    public GameManager gameManager;
    private string color = "";

    
    
    //private Material playerEyes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;
        
        colorMap.Add("black", plaidShortsBottom_black);
        colorMap.Add("navy", plaidShortsBottom_navy);
        colorMap.Add("purple", plaidShortsBottom_purple);
        colorMap.Add("green", plaidShortsBottom_green);
        colorMap.Add("brown", plaidShortsBottom_brown);
        colorMap.Add("mocha", plaidShortsBottom_mocha);
        colorMap.Add("blue", plaidShortsBottom_blue);
        colorMap.Add("pink", plaidShortsBottom_pink);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        
        wornLegs = player.GetComponent<Equipment>().wornLegs;
        color = gameObject.name;
        if(wornLegs != null && wornLegs.name == "plaid_shorts_bottom")
        {
            if(colorMap.ContainsKey(color))
            {
                Renderer bottomRenderer = wornLegs.GetComponent<Renderer>();
                Material[] materials = bottomRenderer.sharedMaterials;
                materials[0] = colorMap[color];
                bottomRenderer.sharedMaterials = materials;
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaidPantsColors : MonoBehaviour, IPointerClickHandler
{
    public Material plaidPantsBottom_black;
    public Material plaidPantsBottom_navy;
    public Material plaidPantsBottom_purple;
    public Material plaidPantsBottom_green;
    public Material plaidPantsBottom_brown;
    public Material plaidPantsBottom_mocha;
    public Material plaidPantsBottom_blue;
    public Material plaidPantsBottom_pink;
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
        
        colorMap.Add("black", plaidPantsBottom_black);
        colorMap.Add("navy", plaidPantsBottom_navy);
        colorMap.Add("purple", plaidPantsBottom_purple);
        colorMap.Add("green", plaidPantsBottom_green);
        colorMap.Add("brown", plaidPantsBottom_brown);
        colorMap.Add("mocha", plaidPantsBottom_mocha);
        colorMap.Add("blue", plaidPantsBottom_blue);
        colorMap.Add("pink", plaidPantsBottom_pink);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        
        wornLegs = player.GetComponent<Equipment>().wornLegs;
        color = gameObject.name;
        if(wornLegs != null && wornLegs.name == "plaid_bottom")
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

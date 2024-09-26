using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeartSkullChristmasSweaterColors : MonoBehaviour, IPointerClickHandler
{
    public Material heratSkullChristmasSweaterTop_black;
    public Material heratSkullChristmasSweaterTop_green;
    public Material heratSkullChristmasSweaterTop_purple;
    public Material heratSkullChristmasSweaterTop_pink;
    public Material heratSkullChristmasSweaterTop_blue;
    public Dictionary<string, Material> colorMap= new Dictionary<string, Material>();
    public GameObject player;
    public GameObject BODY;
    private GameObject wornTorso;
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
        
        colorMap.Add("black", heratSkullChristmasSweaterTop_black);
        colorMap.Add("green", heratSkullChristmasSweaterTop_green);
        colorMap.Add("purple", heratSkullChristmasSweaterTop_purple);
        colorMap.Add("pink", heratSkullChristmasSweaterTop_pink);
        colorMap.Add("blue", heratSkullChristmasSweaterTop_blue);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        
        wornTorso = player.GetComponent<Equipment>().wornTorso;
        color = gameObject.name;
        if(wornTorso != null && wornTorso.name == "heartskull_christmas_sweater_top")
        {
            if(colorMap.ContainsKey(color))
            {
                Renderer topRenderer = wornTorso.GetComponent<Renderer>();
                Material[] materials = topRenderer.sharedMaterials;
                materials[0] = colorMap[color];
                topRenderer.sharedMaterials = materials;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

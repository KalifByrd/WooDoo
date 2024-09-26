using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Details : MonoBehaviour, IPointerClickHandler
{
    public Dictionary<string, Material> detailsMap= new Dictionary<string, Material>();
    public Material doll_freckles_details;
    public Material heart_details;
    public Material moon_details;
    public Material star_details;

    private GameObject player;
    private GameObject BODY;
   
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;

        detailsMap.Add("DOLL_FRECKLES_details", doll_freckles_details);
        detailsMap.Add("HEART_details", heart_details);
        detailsMap.Add("MOON_details", moon_details);
        detailsMap.Add("STAR_details", star_details);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string detailsName = gameObject.name;
        gameManager.selectedDetailsIcon = detailsName;
        if(detailsMap.ContainsKey(detailsName))
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[4] = detailsMap[detailsName];
            bodyRenderer.sharedMaterials = materials;
        }
    }
}

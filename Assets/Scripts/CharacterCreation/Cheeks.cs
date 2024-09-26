using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cheeks : MonoBehaviour, IPointerClickHandler
{
    public Dictionary<string, Material> cheeksMap= new Dictionary<string, Material>();
    public Material heart_cheeks;
    public Material heart_stencil_cheeks;
    public Material normal_cheeks;
    public Material small_cheeks;

    private GameObject player;
    private GameObject BODY;
   
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;

        cheeksMap.Add("HEART_cheeks", heart_cheeks);
        cheeksMap.Add("HEART_STENCIL_cheeks", heart_stencil_cheeks);
        cheeksMap.Add("NORMAL_cheeks", normal_cheeks);
        cheeksMap.Add("SMALL_cheeks", small_cheeks);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string cheeksName = gameObject.name;
        gameManager.selectedCheeksIcon = cheeksName;
        if(cheeksMap.ContainsKey(cheeksName))
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[3] = cheeksMap[cheeksName];
            bodyRenderer.sharedMaterials = materials;
        }
    }
}

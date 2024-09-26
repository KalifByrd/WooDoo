using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Eyes : MonoBehaviour, IPointerClickHandler
{
    public Material vintage_eyes_black;
    public Material vintage_eyes_brown;
    public Material vintage_eyes_red;
    public Material vintage_eyes_green;
    public Material vintage_eyes_gray;
    public Material vintage_eyes_blue;
    public Material vintage_eyes_purple;

    public Material ladybug_eyes_black;
    public Material ladybug_eyes_brown;
    public Material ladybug_eyes_red;
    public Material ladybug_eyes_green;
    public Material ladybug_eyes_gray;
    public Material ladybug_eyes_blue;
    public Material ladybug_eyes_purple;

    public Material wide_eyes_black;
    public Material wide_eyes_brown;
    public Material wide_eyes_red;
    public Material wide_eyes_green;
    public Material wide_eyes_gray;
    public Material wide_eyes_blue;
    public Material wide_eyes_purple;

    public Material sanpaku_eyes_black;
    public Material sanpaku_eyes_brown;
    public Material sanpaku_eyes_red;
    public Material sanpaku_eyes_green;
    public Material sanpaku_eyes_gray;
    public Material sanpaku_eyes_blue;
    public Material sanpaku_eyes_purple;

    public Material angry_eyes_black;
    public Material angry_eyes_brown;
    public Material angry_eyes_red;
    public Material angry_eyes_green;
    public Material angry_eyes_gray;
    public Material angry_eyes_blue;
    public Material angry_eyes_purple;

    public Material serious_eyes_black;
    public Material serious_eyes_brown;
    public Material serious_eyes_red;
    public Material serious_eyes_green;
    public Material serious_eyes_gray;
    public Material serious_eyes_blue;
    public Material serious_eyes_purple;

    public Material sandwich_eyes_black;
    public Material sandwich_eyes_brown;
    public Material sandwich_eyes_red;
    public Material sandwich_eyes_green;
    public Material sandwich_eyes_gray;
    public Material sandwich_eyes_blue;
    public Material sandwich_eyes_purple;

    public Material boomerang_eyes_black;
    public Material boomerang_eyes_brown;
    public Material boomerang_eyes_red;
    public Material boomerang_eyes_green;
    public Material boomerang_eyes_gray;
    public Material boomerang_eyes_blue;
    public Material boomerang_eyes_purple;

    public GameObject player;
    public GameObject BODY;
    private GameObject parent;
    public GameManager gameManager;
    
    //private Material playerEyes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.newPlayer;
        BODY = player.transform.GetChild(0).gameObject;
        //playerEyes = BODY.GetComponent<Renderer>().sharedMaterials[1];
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.transform.parent.parent.GetChild(0).gameObject != null)
        {
            parent = gameObject.transform.parent.parent.GetChild(0).gameObject;
        }
        Debug.Log(gameObject.name);
        Debug.Log(parent.name);
        
        if(gameObject.name == "VINTAGE_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "VINTAGE_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = vintage_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "LADYBUG_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "LADYBUG_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = ladybug_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "WIDE_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "WIDE_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = wide_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "SANPAKU_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANPAKU_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sanpaku_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "ANGRY_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "ANGRY_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = angry_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "SERIOUS_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SERIOUS_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = serious_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "SANDWICH_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "SANDWICH_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = sandwich_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }

        else if(gameObject.name == "BOOMERANG_eyes")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "black")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_black;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "brown")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_brown;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "red")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_red;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "gray")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_gray;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "green")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_green;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "blue")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_blue;
            bodyRenderer.sharedMaterials = materials;
        }
        else if(parent.name == "BOOMERANG_eyes" && gameObject.name == "purple")
        {
            Renderer bodyRenderer = BODY.GetComponent<Renderer>();
            Material[] materials = bodyRenderer.sharedMaterials;
            materials[1] = boomerang_eyes_purple;
            bodyRenderer.sharedMaterials = materials;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

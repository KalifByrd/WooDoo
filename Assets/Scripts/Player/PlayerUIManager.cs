using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class PlayerUIManager : MonoBehaviour
{
    public Image dial;
    public GameObject player;
    public GameObject inventory;
    PlayerInput playerInput;
    [SerializeField]
    bool isInventoryPressed;

    public GameObject craftingGuideHomeBtn;


    public bool isKeyPressEnabled;
    public GameObject craftingGuideTitleText;
    public GameObject craftingGuideCategoriesMenue;
    public GameObject craftingGuideCategoriesText;
    public GameObject craftingGuideToolsRecipeMenue;
    public GameObject craftingGuideItemsRecipeMenue;
    public GameObject craftingGuideBuildingRecipeMenue;
    public GameObject craftingGuideDescription;
    public TextMeshProUGUI craftingGuideDescriptionTitleText;
    public TextMeshProUGUI craftingGuideDescriptionText;
    public CraftingGuideButtons craftingGuideButtons;
    public GameManager gameManager;

    void Awake()
    {
        
        playerInput = new PlayerInput();
        playerInput.CharacterUI.Inventory.started += onInventoryInput;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        isKeyPressEnabled = true;
        player = gameManager.newPlayerObject;
        
    }
    void onInventoryInput(InputAction.CallbackContext context)
    {
        isInventoryPressed = context.ReadValueAsButton();
    }
    public void AlignEarth()
    {
        Debug.Log("Aligned with Earth!");
        dial.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        dial.color = new Color32(135, 221, 171, 255);

        if(!player.GetComponent<CustomTag>().HasTag("EarthAligned"))
        {
            player.GetComponent<CustomTag>().AddTag("EarthAligned");

            if(player.GetComponent<CustomTag>().HasTag("WaterAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("WaterAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("AirAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("AirAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("FireAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("FireAligned");
            }
        }
        
    }
    public void AlignAir()
    {
        Debug.Log("Aligned with Air!");
        dial.transform.rotation = Quaternion.Euler(0f, 0f, -80.01f);
        dial.color = new Color32(221, 209, 135, 255);

        if(!player.GetComponent<CustomTag>().HasTag("AirAligned"))
        {
            player.GetComponent<CustomTag>().AddTag("AirAligned");
            if(player.GetComponent<CustomTag>().HasTag("EarthAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("EarthAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("WaterAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("WaterAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("FireAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("FireAligned");
            }
        }
    }
    public void AlignFire()
    {
        Debug.Log("Aligned with Fire!");
        dial.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        dial.color = new Color32(231, 102, 95, 255);
        if(!player.GetComponent<CustomTag>().HasTag("FireAligned"))
        {
            player.GetComponent<CustomTag>().AddTag("FireAligned");

            if(player.GetComponent<CustomTag>().HasTag("EarthAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("EarthAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("AirAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("AirAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("WaterAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("WaterAligned");
            }
        }
    }
    public void AlignWater()
    {
        Debug.Log("Aligned with Water!");
        dial.transform.rotation = Quaternion.Euler(0f, 0f, 81f);
        dial.color = new Color32(103, 198, 241, 255);
        if(!player.GetComponent<CustomTag>().HasTag("WaterAligned"))
        {
            player.GetComponent<CustomTag>().AddTag("WaterAligned");

            if(player.GetComponent<CustomTag>().HasTag("EarthAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("EarthAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("AirAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("AirAligned");
            }
            if(player.GetComponent<CustomTag>().HasTag("FireAligned"))
            {
                player.GetComponent<CustomTag>().RemoveTag("FireAligned");
            }
        }
        
    }
    public void NoAlign()
    {
        Debug.Log("Aligned with the Void?");
        dial.color = new Color32(77, 77, 77, 255);

        if(player.GetComponent<CustomTag>().HasTag("EarthAligned"))
        {
            player.GetComponent<CustomTag>().RemoveTag("EarthAligned");
        }
        if(player.GetComponent<CustomTag>().HasTag("AirAligned"))
        {
            player.GetComponent<CustomTag>().RemoveTag("AirAligned");
        }
        if(player.GetComponent<CustomTag>().HasTag("FireAligned"))
        {
            player.GetComponent<CustomTag>().RemoveTag("FireAligned");
        }
        if(player.GetComponent<CustomTag>().HasTag("WaterAligned"))
        {
            player.GetComponent<CustomTag>().RemoveTag("WaterAligned");
        }

    }
    void InventoryOpeonOrClosed()
    {
        if(isInventoryPressed && inventory.activeInHierarchy && isKeyPressEnabled)
        {
            inventory.SetActive(false);
            isInventoryPressed = false;
        }
        else if(isInventoryPressed && !inventory.activeInHierarchy && isKeyPressEnabled)
        {
            
            inventory.SetActive(true);
            isInventoryPressed = false;
        }
    }

    public void CraftingGuideToolsBtn()
    {
        craftingGuideTitleText.SetActive(false);
        craftingGuideCategoriesMenue.SetActive(false);
        craftingGuideCategoriesText.SetActive(false);
        craftingGuideHomeBtn.SetActive(true);
        craftingGuideToolsRecipeMenue.SetActive(true);
        craftingGuideDescription.SetActive(true);
        craftingGuideDescriptionTitleText.text = "Description";
        craftingGuideDescriptionText.text = "All of your discovered tool recipies are found here.";
    }
    public void CraftingGuideItemsBtn()
    {
        craftingGuideTitleText.SetActive(false);
        craftingGuideCategoriesMenue.SetActive(false);
        craftingGuideCategoriesText.SetActive(false);
        craftingGuideHomeBtn.SetActive(true);
        craftingGuideItemsRecipeMenue.SetActive(true);
        craftingGuideDescription.SetActive(true);
        craftingGuideDescriptionTitleText.text = "Description";
        craftingGuideDescriptionText.text = "All of your discovered placable item recipies are found here.";
    }
    public void CraftingGuideBuildingsBtn()
    {
        craftingGuideTitleText.SetActive(false);
        craftingGuideCategoriesMenue.SetActive(false);
        craftingGuideCategoriesText.SetActive(false);
        craftingGuideHomeBtn.SetActive(true);
        craftingGuideBuildingRecipeMenue.SetActive(true);
        craftingGuideDescription.SetActive(true);
        craftingGuideDescriptionTitleText.text = "Description";
        craftingGuideDescriptionText.text = "All of your discovered buildings are found here.";
    }
    public void CraftingGuideHomeBtn()
    {
        craftingGuideButtons = gameObject.transform.GetChild(4).gameObject.GetComponent<CraftingGuideButtons>();
        craftingGuideTitleText.SetActive(true);
        craftingGuideCategoriesMenue.SetActive(true);
        craftingGuideCategoriesText.SetActive(true);
        craftingGuideHomeBtn.SetActive(false);
        craftingGuideToolsRecipeMenue.SetActive(false);
        craftingGuideItemsRecipeMenue.SetActive(false);
        craftingGuideBuildingRecipeMenue.SetActive(false);
        craftingGuideDescription.SetActive(false);
        craftingGuideButtons.simpleToolPage.SetActive(false);
        craftingGuideButtons.simpleLadderPage.SetActive(false);
        craftingGuideButtons.simpleShearsPage.SetActive(false);
        craftingGuideButtons.simpleBedPage.SetActive(false);
        craftingGuideButtons.simpleCraftingTablePage.SetActive(false);

    }

    
    // Update is called once per frame
    void Update()
    {
        InventoryOpeonOrClosed();
    }

    void OnEnable()
    {
        playerInput.CharacterUI.Enable();
    }
    void OnDisable()
    {
        playerInput.CharacterUI.Disable();
    }
}

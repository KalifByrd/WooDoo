using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour, IPointerClickHandler
{
    public GameObject unit;
    private ChangeGear changeGearScript;
    private Equipment equipmentScript;
    private Text textChild; 
    public GameManager gameManager;
    


    private void Start()
    {
        //unit = GameObject.FindGameObjectWithTag("Unit").gameObject;
        changeGearScript = unit.GetComponent<ChangeGear>();
        equipmentScript = unit.GetComponent<Equipment>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pressed");
        if (gameObject.name == "HAIR_AfroSpaceBuns")
        {
            gameManager.selectedHairIcon = "HAIR_AfroSpaceBuns";
            Debug.Log("spacebuns");
            AddOrRemoveClothes("bald_head", "Hair", "afro_space_buns_hair", 2);

            
        }
        else if (gameObject.name == "HAIR_BlackVictorian")
        {
            gameManager.selectedHairIcon = "HAIR_BlackVictorian";
            AddOrRemoveClothes("bald_head", "Hair", "black_victorian_hair", 2);
            Debug.Log("victorian");
        }
        else if (gameObject.name == "HAIR_ButtCut")
        {
            gameManager.selectedHairIcon = "HAIR_ButtCut";
            AddOrRemoveClothes("bald_head", "Hair", "butt_cut_hair", 2);

        }
            
        else if (gameObject.name == "HAIR_WavyModern")
            AddOrRemoveClothes("bald_head", "Hair", "wavy_modern_hair", 2);
        else if (gameObject.name == "NOSE_Heart")
        {
            gameManager.selectedNoseIcon = "NOSE_Heart";
            AddOrRemoveClothes("no_nose", "Nose", "heart_nose", 9);
        }
                  
        else if (gameObject.name == "ACCESSORY_HAIR_BatWings")
            AddOrRemoveClothes("no_head_accessory", "HeadAccessory", "bat_wings_head_accessory", 6);
        else if (gameObject.name == "TOP_Sparkle")
            AddOrRemoveClothes("naked_torso", "Torso", "sparkle_top", 1);
        else if (gameObject.name == "TOP_HeartSkull_Christmas_Sweater")
        {
            AddOrRemoveClothes("naked_torso", "Torso", "heartskull_christmas_sweater_top", 1);
        }
        else if(gameObject.name == "BOTTOM_Plaid")
        {
            AddOrRemoveClothes("naked_legs", "Legs", "plaid_bottom", 0);
        }
        else if(gameObject.name == "BOTTOM_SHORTS_Plaid")
        {
            AddOrRemoveClothes("naked_legs", "Legs", "plaid_shorts_bottom", 0);
        }
        
    }
    

    public void AddOrRemoveClothes(string nakedSlug, string clothesType, string clothesSlug, int equippedItemsIndex)
    {
        Debug.Log("add or remove");
        if (equipmentScript.equippedItems[equippedItemsIndex].Slug == nakedSlug)
        {
            changeGearScript.EquipItem(clothesType, clothesSlug);
            Debug.Log("add item");
        }
        else if (equipmentScript.equippedItems[equippedItemsIndex].Slug == clothesSlug)
        {
            changeGearScript.UnequipItem(clothesType, clothesSlug);
            Debug.Log("remove item");
        }
        else if (equipmentScript.equippedItems[equippedItemsIndex].Slug != clothesSlug && equipmentScript.equippedItems[equippedItemsIndex].Slug != nakedSlug)
        {
            changeGearScript.UnequipItem(clothesType, equipmentScript.equippedItems[equippedItemsIndex].Slug);
            Debug.Log("remove item");
            changeGearScript.EquipItem(clothesType, clothesSlug);
            Debug.Log("add item");
        }
    }
}

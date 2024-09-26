using UnityEngine;
using System.Collections.Generic;

public class Equipment : MonoBehaviour
{
    #region Fields
    //gameObjects
    public GameObject avatar;

    public GameObject wornLegs;
    public GameObject wornTorso;
    public GameObject wornHair;
    public GameObject wornHandRight;
    public GameObject wornHandLeft;
    public GameObject wornHat;
    public GameObject wornHeadAccessory;
    public GameObject wornSocks;
    public GameObject wornLeggings;

    public GameObject wornNose;
    public GameObject wornEyes;
    public GameObject wornEyebrows;
    public GameObject wornMouth;
    public GameObject wornCheeks;
    public GameObject wornDetails;

    public GameObject wornFeet;


    //lists
    public List<Item> equippedItems = new List<Item>(); 
    //scripts
    private Stitcher stitcher;
    //ints
    private int totalEquipmentSlots; 
    #endregion

    #region Monobehaviour
    public void Awake()
    {
        stitcher = new Stitcher();
    }
    
    public void InitializeEquipptedItemsList()
    {
        totalEquipmentSlots = 16;

        for (int i = 0; i < totalEquipmentSlots; i++)
        {
            equippedItems.Add(new Item());
        }

        AddEquipmentToList(0); //Legs
        AddEquipmentToList(1); //Torso
        AddEquipmentToList(2); //Hair 
        AddEquipmentToList(3); //HandRight
        AddEquipmentToList(4); //HandLeft
        AddEquipmentToList(5); //Hat
        AddEquipmentToList(6); //HeadAccessory
        AddEquipmentToList(7); //Socks
        AddEquipmentToList(8); //Leggings
        AddEquipmentToList(9); //Nose
        AddEquipmentToList(10); //Eyes
        AddEquipmentToList(11); //Eyebrows
        AddEquipmentToList(12); //Mouth
        AddEquipmentToList(13); //Cheeks
        AddEquipmentToList(14); //Details
        AddEquipmentToList(15); //Feet
    }

    public void AddEquipmentToList(int id)
    {
        for(int i = 0; i < equippedItems.Count; i++)
        {
            if(equippedItems[id].ItemID == -1)
            {
                equippedItems[id] = ItemDatabase.Instance.FetchItemByID(id);
                break; 
            }
        }
    }

    public void AddEquipment(Item equipmentToAdd)
    {
        if (equipmentToAdd.ItemType == "Legs")
        {
            wornLegs = AddEquipmentHelper(wornLegs, equipmentToAdd);
            wornLegs.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Torso")
        {
            wornTorso = AddEquipmentHelper(wornTorso, equipmentToAdd);
            wornTorso.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Hair")
        {
            wornHair = AddEquipmentHelper(wornHair, equipmentToAdd);
            wornHair.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "HandRight")
        {
            wornHandRight = AddEquipmentHelper(wornHandRight, equipmentToAdd);
            wornHandRight.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "HandLeft")
        {
            wornHandLeft = AddEquipmentHelper(wornHandLeft, equipmentToAdd);
            wornHandLeft.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Hat")
        {
            wornHat = AddEquipmentHelper(wornHat, equipmentToAdd);
            wornHat.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "HeadAccessory")
        {
            wornHeadAccessory = AddEquipmentHelper(wornHeadAccessory, equipmentToAdd);
            wornHeadAccessory.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Socks")
        {
            wornSocks = AddEquipmentHelper(wornSocks, equipmentToAdd);
            wornSocks.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Leggings")
        {
            wornLeggings = AddEquipmentHelper(wornLeggings, equipmentToAdd);
            wornLeggings.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Nose")
        {
            wornNose = AddEquipmentHelper(wornNose, equipmentToAdd);
            wornNose.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Eyes")
        {
            wornEyes = AddEquipmentHelper(wornEyes, equipmentToAdd);
            wornEyes.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Eyebrows")
        {
            wornEyebrows = AddEquipmentHelper(wornEyebrows, equipmentToAdd);
            wornEyebrows.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Mouth")
        {
            wornMouth = AddEquipmentHelper(wornMouth, equipmentToAdd);
            wornMouth.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Cheeks")
        {
            wornCheeks = AddEquipmentHelper(wornCheeks, equipmentToAdd);
            wornCheeks.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Details")
        {
            wornDetails = AddEquipmentHelper(wornDetails, equipmentToAdd);
            wornDetails.layer = 10;
        }
            
        else if (equipmentToAdd.ItemType == "Feet")
        {
            wornFeet = AddEquipmentHelper(wornFeet, equipmentToAdd);
            wornFeet.layer = 10;
        }
            
    }

    public GameObject AddEquipmentHelper(GameObject wornItem, Item itemToAddToWornItem)
    {
        wornItem = Wear(itemToAddToWornItem.ItemPrefab, wornItem);
        wornItem.name = itemToAddToWornItem.Slug;
        return wornItem; 
    }

    public void RemoveEquipment(Item equipmentToAdd)
    {
        if (equipmentToAdd.ItemType == "Legs")
            wornLegs = RemoveEquipmentHelper(wornLegs, 0);
        else if (equipmentToAdd.ItemType == "Torso")
            wornTorso = RemoveEquipmentHelper(wornTorso, 1);
        else if (equipmentToAdd.ItemType == "Hair")
            wornHair = RemoveEquipmentHelper(wornHair, 2);
        else if (equipmentToAdd.ItemType == "HandRight")
            wornHandRight = RemoveEquipmentHelper(wornHandRight, 3);
        else if (equipmentToAdd.ItemType == "HandLeft")
            wornHandLeft = RemoveEquipmentHelper(wornHandLeft, 4);
        else if (equipmentToAdd.ItemType == "Hat")
            wornHat = RemoveEquipmentHelper(wornHat, 5);
        else if (equipmentToAdd.ItemType == "HeadAccessory")
            wornHeadAccessory = RemoveEquipmentHelper(wornHeadAccessory, 6);
        else if (equipmentToAdd.ItemType == "Socks")
            wornSocks = RemoveEquipmentHelper(wornSocks, 7);
        else if (equipmentToAdd.ItemType == "Leggings")
            wornLeggings = RemoveEquipmentHelper(wornLeggings, 8);
        else if (equipmentToAdd.ItemType == "Nose")
            wornNose = RemoveEquipmentHelper(wornNose, 9);
        else if (equipmentToAdd.ItemType == "Eyes")
            wornEyes = RemoveEquipmentHelper(wornEyes, 10);
        else if (equipmentToAdd.ItemType == "Eyebrows")
            wornEyebrows = RemoveEquipmentHelper(wornEyebrows, 11);
        else if (equipmentToAdd.ItemType == "Mouth")
            wornMouth = RemoveEquipmentHelper(wornMouth, 12);
        else if (equipmentToAdd.ItemType == "Cheeks")
            wornCheeks = RemoveEquipmentHelper(wornCheeks, 13);
        else if (equipmentToAdd.ItemType == "Details")
            wornDetails = RemoveEquipmentHelper(wornDetails, 14);
        else if (equipmentToAdd.ItemType == "Feet")
            wornFeet = RemoveEquipmentHelper(wornFeet, 15);
    }

    public GameObject RemoveEquipmentHelper(GameObject wornItem, int nakedItemIndex)
    {
        wornItem = RemoveWorn(wornItem);
        equippedItems[nakedItemIndex] = ItemDatabase.Instance.FetchItemByID(nakedItemIndex);
        return wornItem; 
    }

    #endregion

    private GameObject RemoveWorn(GameObject wornClothing)
    {
        if (wornClothing == null)
            return null;
        GameObject.Destroy(wornClothing);
        return null; 
    }

    private GameObject Wear(GameObject clothing, GameObject wornClothing)
    {
        if (clothing == null)
            return null;
        clothing = (GameObject)GameObject.Instantiate(clothing);
        wornClothing = stitcher.Stitch(clothing, avatar);
        GameObject.Destroy(clothing);
        return wornClothing;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingGuideButtons : MonoBehaviour
{
    public bool isPlacable = false;
    public IslandSceneManager islandSceneManager;
    public GameObject itemPlacementSystemObject;
    public GameObject placableObjectParent;
    public GameObject simpleHouseBtn;
    public GameObject simpleStarfolkBtn;
    public Transform playerHand;
    public InventorySlot inventorySlot;
    public GameManager gameManager;

    public GameObject toolRecipeMenue;
    public GameObject itemRecipeMenue;
    public GameObject simpleToolPage;
    public GameObject simpleLadderPage;
    public GameObject simpleShearsPage;
    public GameObject simpleBedPage;
    public GameObject simpleCraftingTablePage;
    
    // Start is called before the first frame update
    void Start()
    {
        islandSceneManager = GameObject.Find("IslandSceneManager").GetComponent<IslandSceneManager>();
        itemPlacementSystemObject = islandSceneManager.itemPlacementSystemObject;
        placableObjectParent = itemPlacementSystemObject.transform.GetChild(3).gameObject;
        inventorySlot = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<InventorySlot>();
        playerHand = inventorySlot.playerHand;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CraftingGuideSimpleHomeBtn()
    {
        if(gameManager.currentEnvironmentName == "Island" || gameManager.currentEnvironmentName == "SavedIsland")
        {
            GameObject currentItem = simpleHouseBtn.GetComponent<Building>().building;
            if (!isPlacable)
            {
                itemPlacementSystemObject.SetActive(true);
                isPlacable = true;
                if(placableObjectParent.transform.childCount > 0)
                {
                    Destroy(placableObjectParent.transform.GetChild(0).gameObject);
                    GameObject item = Instantiate(currentItem, placableObjectParent.transform);
                    //item.transform.position = new Vector3(item.transform.position.x, currentPlayer.transform.position.y , item.transform.position.z);
                }
                else if(placableObjectParent.transform.childCount == 0)
                {
                    GameObject item = Instantiate(currentItem, placableObjectParent.transform);
                    //item.transform.position = new Vector3(item.transform.position.x, currentPlayer.transform.position.y , item.transform.position.z);
                }
                if(playerHand.childCount == 8)
                {
                    inventorySlot.HoldItemBtn();
                }
            }
            else if(isPlacable)
            {
                itemPlacementSystemObject.SetActive(false);
                isPlacable = false;
            }
        }
        else
        {
            gameManager.broadcast.SetActive(true);
            gameManager.boradcastText.text = "This event can only happen on the island!";
            gameManager.HideBroadcast();
        }
       
    }
    public void CraftingGuideSimpleStarfolkHomeBtn()
    {
        if(gameManager.currentEnvironmentName == "Island" || gameManager.currentEnvironmentName == "SavedIsland")
        {
            GameObject currentItem = simpleStarfolkBtn.GetComponent<Building>().building;
            if (!isPlacable && !gameManager.isStarfolkHomeIniciated)
            {
                itemPlacementSystemObject.SetActive(true);
                isPlacable = true;
                gameManager.isStarfolkHomeIniciated = true;
                if(placableObjectParent.transform.childCount > 0)
                {
                    Destroy(placableObjectParent.transform.GetChild(0).gameObject);
                    GameObject item = Instantiate(currentItem, placableObjectParent.transform);
                    //item.transform.position = new Vector3(item.transform.position.x, currentPlayer.transform.position.y , item.transform.position.z);
                }
                else if(placableObjectParent.transform.childCount == 0)
                {
                    GameObject item = Instantiate(currentItem, placableObjectParent.transform);
                    //item.transform.position = new Vector3(item.transform.position.x, currentPlayer.transform.position.y , item.transform.position.z);
                }
                if(playerHand.childCount == 8)
                {
                    inventorySlot.HoldItemBtn();
                }
            }
            else if(isPlacable && !gameManager.isStarfolkHomeIniciated)
            {
                itemPlacementSystemObject.SetActive(false);
                isPlacable = false;
            }
            else if(gameManager.isStarfolkHomeIniciated)
            {
                gameManager.broadcast.SetActive(true);
                gameManager.boradcastText.text = "Open your task book and asign a Starfolk to the house on the island!";
                gameManager.HideBroadcast();
            }
        }
        else
        {
            gameManager.broadcast.SetActive(true);
            gameManager.boradcastText.text = "This event can only happen on the island!";
            gameManager.HideBroadcast();
        }
       
    }

    public void SimpleToolBtn()
    {
        if(toolRecipeMenue.activeInHierarchy)
        {
            toolRecipeMenue.SetActive(false);
            simpleToolPage.SetActive(true);
        }
        else
        {
            toolRecipeMenue.SetActive(true);
            simpleToolPage.SetActive(false);
        }
        
    }
    public void LadderBtn()
    {
        if(toolRecipeMenue.activeInHierarchy)
        {
            toolRecipeMenue.SetActive(false);
            simpleLadderPage.SetActive(true);
        }
        else
        {
            toolRecipeMenue.SetActive(true);
            simpleLadderPage.SetActive(false);
        }
    }
    public void ShearsBtn()
    {
        if(toolRecipeMenue.activeInHierarchy)
        {
            toolRecipeMenue.SetActive(false);
            simpleShearsPage.SetActive(true);
        }
        else
        {
            toolRecipeMenue.SetActive(true);
            simpleShearsPage.SetActive(false);
        }
    }

    public void SimpleBedBtn()
    {
        if(itemRecipeMenue.activeInHierarchy)
        {
            itemRecipeMenue.SetActive(false);
            simpleBedPage.SetActive(true);
        }
        else
        {
            itemRecipeMenue.SetActive(true);
            simpleBedPage.SetActive(false);
        }
    }
    public void CraftingTableBtn()
    {
        if(itemRecipeMenue.activeInHierarchy)
        {
            itemRecipeMenue.SetActive(false);
            simpleCraftingTablePage.SetActive(true);
        }
        else
        {
            itemRecipeMenue.SetActive(true);
            simpleCraftingTablePage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

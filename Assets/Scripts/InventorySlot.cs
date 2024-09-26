using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour, IDropHandler
{
    private int clickCount = 0;
    private GameObject itemOptions;
    public Transform playerHand;
    public Transform prop;
    public Button holdItemBtn;
    public Button deleteItemBtn;
    public Button placeItemBtn;
    public GameObject player;

    public bool isPlacable = false;
    [SerializeField] private IslandSceneManager placementSceneManager;
    [SerializeField] private GameObject itemPlacementSystemObject;
    [SerializeField] private GameObject placableObjectParent;
    [SerializeField] private ItemPlacementSystem itemPlacementSystem;
    public GameManager gameManager;
    
    
    void Start()
    {
        InitiateInventory();
    }
    public void InitiateInventory()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = PlayerReference.player;
        itemOptions = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/ItemOptions").gameObject;
        // player.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(6).gameObject
        //prop = playerHand.GetChild(6);
        holdItemBtn = itemOptions.transform.GetChild(0).gameObject.GetComponent<Button>();
        deleteItemBtn = itemOptions.transform.GetChild(1).gameObject.GetComponent<Button>();
        placeItemBtn = itemOptions.transform.GetChild(2).gameObject.GetComponent<Button>();
        if(gameManager.currentEnvironmentName == "Island" || gameManager.currentEnvironmentName == "SavedIsland")
        {
           // placementSceneManager = GameObject.Find("IslandSceneManager").GetComponent<IslandSceneManager>();

            placementSceneManager = GameManager.Instance.islandSceneManager;
            Debug.Log(placementSceneManager);
            itemPlacementSystemObject = placementSceneManager.itemPlacementSystemObject;
            placableObjectParent = itemPlacementSystemObject.transform.GetChild(3).gameObject;
            itemPlacementSystem = itemPlacementSystemObject.transform.GetChild(1).gameObject.GetComponent<ItemPlacementSystem>();
            
        }
        else if(gameManager.currentEnvironmentName == "PlayerHome" || gameManager.currentEnvironmentName == "SavedPlayerHome")
        {
            // May be an issue?
            //placementSceneManager = GameObject.Find("HomeSceneManager").GetComponent<IslandSceneManager>();
            placementSceneManager = GameManager.Instance.homeSceneManager;
            Debug.Log(placementSceneManager);
            itemPlacementSystemObject = placementSceneManager.itemPlacementSystemObject;
            Debug.Log(itemPlacementSystemObject);
            placableObjectParent = itemPlacementSystemObject.transform.GetChild(3).gameObject;
            Debug.Log(placableObjectParent);
            itemPlacementSystem = itemPlacementSystemObject.transform.GetChild(1).gameObject.GetComponent<ItemPlacementSystem>();
            Debug.Log(itemPlacementSystem);
        }
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject droppped = eventData.pointerDrag;
            DraggableItem draggableItem = droppped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            if(holdItemBtn.onClick.GetPersistentEventCount() == 0)
            {
                holdItemBtn.onClick.RemoveAllListeners();
            }
            if(deleteItemBtn.onClick.GetPersistentEventCount() == 0)
            {
                
                deleteItemBtn.onClick.RemoveAllListeners();
            }
            if(placeItemBtn.onClick.GetPersistentEventCount() == 0)
            {
                placeItemBtn.onClick.RemoveAllListeners();
            }
            
            
            holdItemBtn.onClick.AddListener(HoldItemBtn);
            deleteItemBtn.onClick.AddListener(DeleteItemBtn);
            placeItemBtn.onClick.AddListener(PlaceItemBtn);
            

            itemOptions.SetActive(false);
        }
        
    }
    public void SlotClick()
    {
        itemPlacementSystemObject.SetActive(false);
        clickCount++;
        itemPlacementSystem.currentInventorySlot = gameObject;
        if(gameObject.transform.childCount > 0)
        {
            if(holdItemBtn.onClick.GetPersistentEventCount() == 0)
            {
                
                holdItemBtn.onClick.RemoveAllListeners();
            }
            if(deleteItemBtn.onClick.GetPersistentEventCount() == 0)
            {
                
                deleteItemBtn.onClick.RemoveAllListeners();
            }
            if (placeItemBtn.onClick.GetPersistentEventCount() == 0)
            {

                placeItemBtn.onClick.RemoveAllListeners();
            }

            holdItemBtn.onClick.AddListener(HoldItemBtn);
            deleteItemBtn.onClick.AddListener(DeleteItemBtn);
            placeItemBtn.onClick.AddListener(PlaceItemBtn);

            if (gameObject.transform.GetChild(0).gameObject.GetComponent<CustomTag>().HasTag("PickUp"))
            {
                if(clickCount == 1)
                {
                    itemOptions.SetActive(true);

                    itemOptions.transform.GetChild(0).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(1).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(2).gameObject.SetActive(false);
                    itemOptions.transform.GetChild(3).gameObject.SetActive(true);
                }
                else if(clickCount == 2)
                {
                    itemOptions.SetActive(false);
                    clickCount = 0;
                }
                
            }
            if(gameObject.transform.GetChild(0).gameObject.GetComponent<CustomTag>().HasTag("Tool"))
            {
                if(clickCount == 1)
                {
                    itemOptions.SetActive(true);

                    itemOptions.transform.GetChild(0).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(1).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(2).gameObject.SetActive(false);
                    itemOptions.transform.GetChild(3).gameObject.SetActive(false);
                }
                else if(clickCount == 2)
                {
                    itemOptions.SetActive(false);
                    clickCount = 0;
                }
                
            }
            if(gameObject.transform.GetChild(0).gameObject.GetComponent<CustomTag>().HasTag("Item"))
            {
                if(clickCount == 1)
                {
                    itemOptions.SetActive(true);

                    itemOptions.transform.GetChild(0).gameObject.SetActive(false);
                    itemOptions.transform.GetChild(1).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(2).gameObject.SetActive(true);
                    itemOptions.transform.GetChild(3).gameObject.SetActive(false);
                }
                else if(clickCount == 2)
                {
                    itemOptions.SetActive(false);
                    clickCount = 0;
                }
                
            }
            
        }
    }
    public void HoldItemBtn()
    {
        if(playerHand.childCount == 8)
        {
            
            RemoveItemFromPlayerHand();
        }
        else
        {
            
            Debug.Log("I'm looking at the " + gameObject.transform.parent + " slot");
            GameObject currentItemIcon = gameObject.transform.GetChild(0).gameObject;
            GameObject currentItem = currentItemIcon.GetComponent<DraggableItem>().item;
            string holding = currentItem.GetComponent<Tool>().holding;
            player.GetComponent<CustomTag>().AddTag(holding);
            // This needs to be fixed its rotating wrong
            //Instantiate(currentItem, new Vector3(prop.position.x , prop.transform.position.y, prop.transform.position.z), Quaternion.Euler(new Vector3(0, playerHand.rotation.y, 0)), playerHand);
            Instantiate(currentItem, playerHand);
            
        }
        

        

    }
    private void RemoveItemFromPlayerHand()
    {
        GameObject currentItem = playerHand.GetChild(7).gameObject;
        string currentHolding = currentItem.GetComponent<Tool>().holding;
        player.GetComponent<CustomTag>().RemoveTag(currentHolding);
        Destroy(currentItem);
    }
    public void DeleteItemBtn()
    {
        GameObject currentItemIcon = gameObject.transform.GetChild(0).gameObject;
        itemPlacementSystemObject.SetActive(false);
        itemOptions.SetActive(false);
        clickCount = 0;
        if (playerHand.childCount == 8)
        {
            RemoveItemFromPlayerHand();
            Destroy(currentItemIcon);
            

        }
        else
        {
            Destroy(currentItemIcon);
        }
    }
    public void PlaceItemBtn()
    {
        GameObject currentItemIcon = gameObject.transform.GetChild(0).gameObject;
        GameObject currentItem = currentItemIcon.GetComponent<DraggableItem>().item;
        GameObject currentPlayer = GameObject.Find("Player");
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
                HoldItemBtn();
            }
        }
        else if(isPlacable)
        {
            itemPlacementSystemObject.SetActive(false);
            isPlacable = false;
        }
    }

}

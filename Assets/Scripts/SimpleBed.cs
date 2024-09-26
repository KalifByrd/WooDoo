using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DPUtils.Systems.DateTime
{
    public class SimpleBed : MonoBehaviour
    {
        public GameObject inventorySlots;
        public GameObject interactionUI;
        private bool canInteract = false;
        public GameObject simpleBedIcon;
        public bool isBeingPlaced = false;
        public bool isObjectUIPressed = false;
        [SerializeField] private GameObject indicator;
        [SerializeField] private Material indicatorMaterial;
        [SerializeField] private GameObject simpleBed;
        [SerializeField] private ObjectCraftingSystem objectCraftingSystem;
        public TimeManager timeManager;

    
        
        private List<GameObject> icons = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {
            icons.Add(simpleBedIcon);
            indicatorMaterial.SetColor("_Color", Color.green);
            inventorySlots = GameObject.Find("Player").transform.GetChild(5).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject;
            objectCraftingSystem = GameObject.Find("GameManager").GetComponent<ObjectCraftingSystem>();
            objectCraftingSystem.objectCraftingSlot = GameObject.Find("GameManager").transform.GetChild(3).GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<ObjectCraftingSlot>();
            interactionUI = GameObject.Find("GameManager").transform.GetChild(3).GetChild(0).gameObject;
            timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
            
            
        }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Someone entered: " + other);
            if(indicator.activeInHierarchy && other.tag != "PlayerFloor" && other.tag != "MouseIndicator")
            {
                
                indicatorMaterial.SetColor("_Color", Color.red);
                Debug.Log("should be red");

            }
            else if(other.tag == "Player")
            {
                Debug.Log("player is here");
                interactionUI.SetActive(true);
                canInteract = true;
            }

        }
        void OnTriggerExit(Collider other)
        {
            if(indicator.activeInHierarchy && other.tag != "PlayerFloor" && other.tag != "MouseIndicator")
            {
                indicatorMaterial.SetColor("_Color", Color.green);
                Debug.Log("should be green");
            }
            Debug.Log("oh...they left.");
            interactionUI.SetActive(false);
            if(other.tag == "Player")
            {
                interactionUI.SetActive(false);
                isObjectUIPressed = false;
                canInteract = false;
            }
            
            
        }
        // Update is called once per frame
        [System.Obsolete]
        void Update()
        {
            if(canInteract)
            {
                if(Input.GetKey("x"))
                {
                    interactionUI.SetActive(false);
                    for(int i = 0; i < inventorySlots.transform.GetChildCount(); i++)
                    {
                        GameObject slot = inventorySlots.transform.GetChild(i).gameObject;
                        for(int j = 0; j < slot.transform.GetChildCount(); j++)
                        {
                            GameObject button = slot.transform.GetChild(j).gameObject;
                            if(button.transform.childCount == 0)
                            {
                                for(int k = 0; k < icons.Count ; k++)
                                {
                                    
                                    GameObject icon = icons[k];
                                    if(gameObject.tag == icon.tag)
                                    {
                                        GameObject currentIcon = Instantiate(icon);
                                        currentIcon.transform.SetParent(button.transform);
                                        currentIcon.transform.localScale = new Vector3(0.35f, 0.35f);
                                        Destroy(gameObject);
                                        i =100;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    
                    
                }
                if (Input.GetKeyDown("i"))
                {
                    if(timeManager.NightCheck())
                    {
                        timeManager.SetMorningTime();
                    }
                    else
                    {
                        Debug.Log("You cant sleep now!");
                    }
                    
                }
                
            }
        }
    }
}

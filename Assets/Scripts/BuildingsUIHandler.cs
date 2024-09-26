using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingsUIHandler : MonoBehaviour
{
    public GameObject buildingUICanvas;
    public TextMeshProUGUI firstSlotText;
    public TextMeshProUGUI secondSlotText;
    public TextMeshProUGUI thirdSlotText;
    public TextMeshProUGUI firstCountText;
    public TextMeshProUGUI secondCountText;
    public TextMeshProUGUI thirdCountText;

    public GameObject gameManagerObject;
    public GameManager gameManager;

    public string firstSlot;
    public string secondSlot;
    public string thirdSlot;

    public int firstSlotCount;
    public int secondSlotCount;
    public int thirdSlotCount;

    public bool isFirstSlotActive;
    public bool isSecondSlotActive;
    public bool isThirdSlotActive;

    public GameObject firstSlotObject;
    public GameObject secondSlotObject;
    public GameObject thirdSlotObject;

    [SerializeField] private GameObject BuiltHome;

    private int homeBuildCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        buildingUICanvas = gameManagerObject.transform.GetChild(5).gameObject;

        firstSlotObject = buildingUICanvas.transform.GetChild(0).GetChild(0).gameObject;
        secondSlotObject = buildingUICanvas.transform.GetChild(0).GetChild(1).gameObject;
        thirdSlotObject = buildingUICanvas.transform.GetChild(0).GetChild(2).gameObject;

        firstSlotText = firstSlotObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        secondSlotText = secondSlotObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        thirdSlotText = thirdSlotObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        

        firstCountText = firstSlotObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        secondCountText = secondSlotObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        thirdCountText = thirdSlotObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        

        isFirstSlotActive = true;
        isSecondSlotActive = true;
        isThirdSlotActive = true;
        

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered: " + other);
        if(other.tag == "Player")
        {
            Debug.Log("player is here");
            buildingUICanvas.SetActive(true);
            firstSlotText.text = firstSlot;
            secondSlotText.text = secondSlot;
            thirdSlotText.text = thirdSlot;

            firstCountText.text = firstSlotCount.ToString();
            secondCountText.text = secondSlotCount.ToString();
            thirdCountText.text = thirdSlotCount.ToString();
            gameManager.buildingUICanvasActivater = gameObject;
            CheckForZeroCount();
            //13 9 10
            

        }

    }
    public void CheckForZeroCount()
    {
        if(isFirstSlotActive && !firstSlotObject.activeInHierarchy)
        {
            firstSlotObject.SetActive(true);
            

        }
        else if(!isFirstSlotActive && firstSlotObject.activeInHierarchy)
        {
            firstSlotObject.SetActive(false);
            if(gameObject.transform.parent.gameObject.tag == "SimpleHome")
            {
                BuildSimpleHome();
            }
            else if(gameObject.transform.parent.gameObject.tag == "StarfolkHome")
            {
                BuildStarfolkHome();
            }
            
            
           
        }

        if(isSecondSlotActive && !secondSlotObject.activeInHierarchy)
        {
            secondSlotObject.SetActive(true);
            

        }
        else if(!isSecondSlotActive && secondSlotObject.activeInHierarchy)
        {
            secondSlotObject.SetActive(false);
            if(gameObject.transform.parent.gameObject.tag == "SimpleHome")
            {
                BuildSimpleHome();
            }
            else if(gameObject.transform.parent.gameObject.tag == "StarfolkHome")
            {
                BuildStarfolkHome();
            }
            
        }

        if(isThirdSlotActive && !thirdSlotObject.activeInHierarchy)
        {
            thirdSlotObject.SetActive(true);
            

        }
        else if(!isThirdSlotActive && thirdSlotObject.activeInHierarchy)
        {
            thirdSlotObject.SetActive(false);
            if(gameObject.transform.parent.gameObject.tag == "SimpleHome")
            {
                BuildSimpleHome();
            }
            else if(gameObject.transform.parent.gameObject.tag == "StarfolkHome")
            {
                BuildStarfolkHome();
            }
            
        }
    }
    void Starfolk()
    {
        int randomStarfolkIndex = Random.Range(0,gameManager.starfolkParent.transform.childCount);
        if(!gameManager.starfolkParent.transform.GetChild(randomStarfolkIndex).gameObject.activeInHierarchy)
        {
            GameObject currentStarfolk = gameManager.starfolkParent.transform.GetChild(randomStarfolkIndex).gameObject;
            currentStarfolk.SetActive(true);
            currentStarfolk.transform.position = gameManager.southStarfolkLocation.position;
            gameManager.starfolkOnIsland = currentStarfolk;
            gameManager.broadcast.SetActive(true);
            gameManager.boradcastText.text = "Looks Like something washed up on the shore...";
            gameManager.HideBroadcast();
        }
        else
        {
            Starfolk();
        }
    }
    
    void BuildSimpleHome()
    {
        if(!firstSlotObject.activeInHierarchy && !secondSlotObject.activeInHierarchy && !thirdSlotObject.activeInHierarchy)
        {
            BuiltHome.SetActive(true);
            gameObject.SetActive(false);
            if(!gameManager.playerHasBuiltHouse)
            {
                if(homeBuildCount == 0)
                {
                    
                    Starfolk();
                    
                    homeBuildCount++;
                }
                gameManager.playerHasBuiltHouse = true;
                //gameManager.theGoldenHorasRune.SetActive(true);
            }
        }
    }
    void BuildStarfolkHome()
    {
        if(!firstSlotObject.activeInHierarchy && !secondSlotObject.activeInHierarchy && !thirdSlotObject.activeInHierarchy)
        {
            BuiltHome.SetActive(true);
            gameObject.SetActive(false);
            if(!gameManager.isStarfolkHomeOnIsland)
            {
        
                gameManager.isStarfolkHomeOnIsland = true;
                gameManager.starfolkHomeToBeAssigned = gameObject.transform.parent.GetChild(3).gameObject;
                //gameManager.theGoldenHorasRune.SetActive(true);
            }
            else
            {
                gameManager.broadcast.SetActive(true);
                gameManager.boradcastText.text = "Open your task book and asign a Starfolk to the house on the island!";
                gameManager.HideBroadcast();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            buildingUICanvas.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : Singleton<GameManager>
{
    public IslandSceneManager islandSceneManager;
    public IslandSceneManager homeSceneManager;
    public ColorPicker colorPicker;
    [Header("Canvases")]
    public GameObject canvas;

    [Header("CurrentEnvironment")]
    public int currentEnvironmentIndex;
    public string currentEnvironmentName;

    [Header("Player")]
    public CharacterController player;
    public GameObject playerObject;
    public List<GameObject> playerSkin = new List<GameObject>();
    public MonoBehaviour playerMovementController;
    
    //public GameObject playerCharacter;

    [Header("UI")]
    public TextMeshProUGUI dialogueDisplay;
    public TextMeshProUGUI speakerNameDisplay;

    [Header("Character Creation")]
    public float rotationSpeed = 1000.0f;

    [Header("Speaker")]
    private GameObject speaker;
    private GameObject[] speakers;

    [Header("Starfolk")]
    [SerializeField] private int numStarfolkTotal;
    [SerializeField] private GameObject starfolkToAdd;
    [SerializeField] public GameObject starfolkParent;

    [SerializeField] private GameObject[] starfolk;

    [SerializeField]
    private GameObject Whisper;
    [SerializeField]
    private GameObject DialogueBubble;
    [SerializeField]
    private GameObject Vail;
    public int current = 1;
    private string[] currentDialogue;
    private GameObject currentVail;
    private GameObject playerCreationWindow;
    private bool isDialogue = false;
    public GameObject playerCamera;
    public GameObject beach;
    public GameObject islandBoarder;
    public GameObject overViewCamera;
    public GameObject playerUI;

    [SerializeField] private GameObject NavMesh;
    private NavMeshSurface navMeshSurface;

    [SerializeField]
    public GameObject playerInventory;

    public GameObject pickUpUI;

    private bool isCraftingBookUIOpen = false;
    public GameObject craftingGuideCanvas;

    public GameObject buildingUICanvasActivater;
    [SerializeField] private bool isIslandStarted = false;
    [SerializeField] private bool isHomeStarted = false;

    public GameObject playerIslandSave;
    public GameObject playerHomeSave;
    public GameObject previousePlayerHomeSave;
    public Vector3 playerHouseExitPoint;
    public GameObject currentPlayerHome;
    [SerializeField] private int previousePlayerHomeIndex = 0;
    [SerializeField] private GameObject clockUI;

    public GameObject timeManagerObject;
    public DPUtils.Systems.DateTime.TimeManager timeManager;

    public bool playerHasBuiltHouse = false;

    public Transform southStarfolkLocation;

    public GameObject broadcast;
    public TextMeshProUGUI boradcastText;
    public GameObject taskBookUI;
    public GameObject settingsUI;
    public GameObject playerInventoryObj;

    public GameObject kiwiFirstHomeTaskObj;
    public GameObject craftingGuideUIStarfolkHomeBtn;
    public bool isStarfolkHomeOnIsland = false;
    public GameObject starfolkHomeToBeAssigned;
    public GameObject starfolkOnIsland;
    public GameObject endDemo;
    private bool isDemoSequence = false;
    public bool isStarfolkHomeIniciated = false;
    public StartManager startManager;

   

  
    


    

    // Start is called before the first frame update
    void Start()
    {
        
        InitiateEnviornment();
    }

    public void GenerateTerrainAndStartGame()
    {
        startManager.dontDestroyOnLoad.Add(gameObject);
        startManager.dontDestroyOnLoad.Add(startManager.gameObject);
        TerrainGenerator terrainGenerator = GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>();
        playerObject.transform.position = new Vector3(5f, 5f, 5f);
        terrainGenerator.worldTiles.transform.position = new Vector3(terrainGenerator.worldTiles.transform.position.x, -1000f, terrainGenerator.worldTiles.transform.position.y);
        playerObject.SetActive(true);
        playerCamera.SetActive(true);
        islandBoarder.SetActive(true);
        beach.SetActive(true);
        overViewCamera.SetActive(false);
        terrainGenerator.GenerateTerrain();
        GameObject islandSelection = GameObject.Find("UIcanvas");
        islandSelection.SetActive(false);
        playerUI.SetActive(true);

        gameObject.GetComponent<PlayerUIManager>().enabled = true;
        gameObject.GetComponent<PlayerUIManager>().inventory.SetActive(false);

        NavMesh = GameObject.Find("NavMesh");
        navMeshSurface = NavMesh.GetComponent<NavMeshSurface>();
        
        navMeshSurface.BuildNavMesh();
        NavMesh.transform.position = new Vector3(NavMesh.transform.position.x, NavMesh.transform.position.y, NavMesh.transform.position.z);
        
        //Wait(50);
        
        terrainGenerator.GetComponent<FloraGenerator>().GenerateFauna();
        clockUI.SetActive(true);


    }
    public void TaskBookUIBtn()
    {
        if(taskBookUI.activeInHierarchy)
        {
            taskBookUI.SetActive(false);
        }
        else
        {
            taskBookUI.SetActive(true);
            if(playerInventoryObj.activeInHierarchy)
            {
                playerInventoryObj.SetActive(false);
            }
            if(craftingGuideCanvas.activeInHierarchy)
            {
                craftingGuideCanvas.SetActive(false);
            }
        }
    }
    public void KiwisHome1Btn()
    {
        if(isStarfolkHomeOnIsland)
        {
            starfolkOnIsland.GetComponent<Starfolk>().home = starfolkHomeToBeAssigned.transform.parent.gameObject;
            starfolkOnIsland.transform.position = starfolkHomeToBeAssigned.transform.position;
            starfolkOnIsland.GetComponent<BoxCollider>().enabled = false;
            kiwiFirstHomeTaskObj.SetActive(false);
            starfolkOnIsland.GetComponent<Starfolk>().isFirstHomeTaskComplete = true;
            playerObject.SetActive(false);
            playerObject.transform.position = new Vector3(starfolkOnIsland.transform.position.x + 1f, starfolkOnIsland.transform.position.y, starfolkOnIsland.transform.position.z);
            playerObject.SetActive(true);
            gameObject.GetComponent<PlayerUIManager>().enabled = false;
            player.enabled = false;
            playerMovementController.enabled = false;
            starfolkOnIsland.GetComponent<CustomTag>().AddTag("Speaking");
            taskBookUI.SetActive(false);
            isStarfolkHomeIniciated = false;

            SetSpeakerNameDisplayText(starfolkOnIsland);

            isDemoSequence = true;
            DialogueBubble.SetActive(true);
            StartDialogue(starfolkOnIsland.GetComponent<Starfolk>().CompleteFirstHomeDialogue1());
            
        }
    }
    public void ResetGame()
    {
        LoadEnvironment("StartScreen");
         
        // Get all root GameObjects in the scene
        
    }
    public void ContinueDemoBtn()
    {
        gameObject.GetComponent<PlayerUIManager>().enabled = true;
        player.enabled = true;
        playerMovementController.enabled = true;
        starfolkOnIsland.GetComponent<CustomTag>().RemoveTag("Speaking");
        endDemo.SetActive(false);
    }

    public void SettingsUIBtn()
    {
        if(settingsUI.activeInHierarchy)
        {
            settingsUI.SetActive(false);
        }
        else
        {
            settingsUI.SetActive(true);
        }
    }
    


    // When the Inviornment it first loaded
    private void InitiateEnviornment()
    {  
        //DontDestroyOnLoad(playerCharacter);
        
        currentEnvironmentIndex = SceneManager.GetActiveScene().buildIndex;
        currentEnvironmentName = SceneManager.GetActiveScene().name;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<CharacterController>();
        playerMovementController = playerObject.GetComponent<AnimationAndMovementController>();
        
        playerSkin = CheckAllChildren(playerObject, "Skin", playerSkin);
        canvas = GameObject.FindGameObjectWithTag("Void");
        Debug.Log(canvas);

        startManager = GameObject.Find("StartManager").GetComponent<StartManager>();
        if(currentEnvironmentName == "StartScreen")
        {
            foreach(GameObject dontDestroyOnLoadObj in startManager.dontDestroyOnLoad)
            {
                Destroy(dontDestroyOnLoadObj);
            }
        }
        if(currentEnvironmentName == "Void")
        {
            gameObject.GetComponent<PlayerUIManager>().enabled = false;
            
            playerUI.SetActive(false);
            
            playerObject.AddComponent<RotatePlayer>();
            currentVail = Vail;
            playerCreationWindow = GameObject.Find("PlayerCreation");
            Whisper.GetComponent<CustomTag>().AddTag("Speaking");
            isDialogue = true;
            player.enabled = false;
            playerMovementController.enabled = false;
            Wait(1);
            SetSpeakerNameDisplayText(Whisper);

            StartDialogue(Whisper.GetComponent<Whisper>().IntroDialogue());
            
        }
        if(currentEnvironmentName == "Island")
        {
            //SceneManager.sceneLoaded += delegate { SpawnSavedPlayer();};
            
            //NavMesh = GameObject.Find("NavMesh");
            //navMeshSurface = NavMesh.GetComponent<NavMeshSurface>();
            timeManagerObject = GameObject.Find("TimeManager");
            timeManager = timeManagerObject.GetComponent<DPUtils.Systems.DateTime.TimeManager>();
            DontDestroyOnLoad(timeManagerObject);
            startManager.dontDestroyOnLoad.Add(timeManagerObject);
            
            
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            
            
            
            if(!isIslandStarted)
            {
                player.enabled = true;
                playerMovementController.enabled = true;
                Destroy(playerObject.GetComponent<RotatePlayer>());
                playerObject.SetActive(false);
                playerCamera = GameObject.Find("Main Camera");
                playerCamera.SetActive(false);
                islandBoarder = GameObject.Find("beachy");
                islandBoarder.SetActive(false);
                beach = GameObject.Find("BeachTides");
                beach.SetActive(false);
                overViewCamera = GameObject.Find("Over View");
                isIslandStarted = true;
                islandSceneManager = GameObject.Find("IslandSceneManager").GetComponent<IslandSceneManager>();
            }


        }
        if(currentEnvironmentName == "PlayerHome")
        {
            playerObject.SetActive(false);
            playerObject.transform.position = new Vector3(0.5f, 0.1f, -3.06f);
            playerObject.SetActive(true);
            homeSceneManager = GameObject.Find("HomeSceneManager").GetComponent<IslandSceneManager>();
            UpdatePlayerInventory();
            if(!currentPlayerHome.GetComponent<SimpleHome>().isHomeStarted)
            {
                currentPlayerHome.GetComponent<SimpleHome>().isHomeStarted = true;
                Debug.Log("Adding to previouse home index");
                previousePlayerHomeIndex++;
                currentPlayerHome.GetComponent<SimpleHome>().index = previousePlayerHomeIndex + 1;
                Debug.Log("The current Home index is: " + currentPlayerHome.GetComponent<SimpleHome>().index);
                
            }
        }
        if(currentEnvironmentName == "SavedIsland")
        {
            UpdatePlayerInventory();
        }
        if(currentEnvironmentName == "SavedPlayerHome")
        {
            UpdatePlayerInventory();
        }
        

        

        

        

        numStarfolkTotal = starfolk.Length;

        
    }
    void UpdatePlayerInventory()
    {
        for(int i = 0; i < playerObject.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(0).GetChild(0).childCount; i++)
        {
            playerObject.transform.GetChild(5).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject.GetComponent<InventorySlot>().InitiateInventory();
        }
        if( playerObject.transform.GetChild(5).GetChild(0).GetChild(1).gameObject.activeInHierarchy)
        {
            playerObject.transform.GetChild(5).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // START DIALAUGUE
    // public void SetSpeakerNameDisplayText(List<GameObject> speakerList)
    // {
    //     GameObject[] speakerArray = speakerList.ToArray();
    //     foreach(GameObject obj in speakerArray)
    //     {
    //         if(obj.GetComponent<CustomTag>() != null && obj.GetComponent<CustomTag>().HasTag("Speaking"))
    //         {
    //             speakerNameDisplay.text = obj.name;
    //             speaker = obj;

    //         }
    //     }
    // }
    public void SetSpeakerNameDisplayText(GameObject currentSpeaker)
    {
        speakerNameDisplay.text = currentSpeaker.name;
        speaker = currentSpeaker;

    }

    public List<GameObject> GetSpeakerList()
    {
        return FindGameObjectsWithTag("Speaking");
    }
    private List<GameObject> FindGameObjectsWithTag(string tag)
    {
        List<GameObject> objectsWithTags = new List<GameObject>();
        GameObject[] objectsOnScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject o in objectsOnScene)
        {
            if(o.GetComponent<CustomTag>() != null && o.GetComponent<CustomTag>().HasTag(tag))
            {
                
                objectsWithTags.Add(o);  
            }
            foreach (Transform child in o.transform)
            {
                if(child.gameObject.GetComponent<CustomTag>() != null && child.gameObject.GetComponent<CustomTag>().HasTag(tag))
                {
                    objectsWithTags.Add(child.gameObject);
                }
            }
            
        }
        
        return objectsWithTags;
    }
    public IEnumerator HideBroadcastAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        broadcast.SetActive(false);
    }
    public void HideBroadcast()
    {
        StartCoroutine(HideBroadcastAfterDelay(6f));
    }
    public void StartDialogue(List<string> dialogueSequence)
    {
        currentDialogue = dialogueSequence.ToArray();
        dialogueDisplay.text = currentDialogue[0];
    }

    public void NextDialogue()
    {
        if(current == currentDialogue.Length)
        {
            DialogueBubble.SetActive(false);
            currentVail.SetActive(false);
            //Debug.Log(speaker);
            //speaker.GetComponent<CustomTag>().RemoveTag("Speaking");
            
            isDialogue = false;
            speaker.GetComponent<CustomTag>().RemoveTag("Speaking");
            speaker = null;
            current = 1;
            if(isDemoSequence)
            {
                endDemo.SetActive(true);
                isStarfolkHomeOnIsland = false;
                starfolkOnIsland.GetComponent<BoxCollider>().enabled = true;
                isDemoSequence = false;
            }
            
        }
        dialogueDisplay.text = currentDialogue[current++ % currentDialogue.Length];
    }
    // END DIALAUGUE

   
    // Checks all gameobjects in the scene 
    public List<GameObject> CheckAllObjects()
    {
        List<GameObject> list = new List<GameObject>();
        GameObject[] objectsOnScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject o in objectsOnScene)
        {
            list.Add(o);
            foreach (Transform child in o.transform)
            {
                list.Add(child.gameObject);
            }
            
        }

        
        return list;
    }
    public List<GameObject> CheckAllChildren(GameObject o, string s, List<GameObject> list)
    {
        foreach (Transform child in o.transform)
        {
            if(child.gameObject.tag == s)
            {
                
                list.Add(child.gameObject);
            }
            CheckAllChildren(child.gameObject, s, list);
        }
        return list;
    }

    // Waits for n number of seconds
    public IEnumerator Wait(int n)
    {
        yield return new WaitForSeconds(n);
    }

    public void ChangeSkinColor()
    {
        foreach(GameObject o in playerSkin)
        {
            o.GetComponent<Renderer>().material.SetColor("_BaseColor", colorPicker.output);
        }
        //playerSkin.SetColor("_BaseColor", colorPicker.output);
    }

    public void DoneBtn()
    {
        player.enabled = true;
        playerMovementController.enabled = true;
        //playerCharacter = GameObject.FindGameObjectWithTag("Player");
        Destroy(playerObject.GetComponent<RotatePlayer>());
        DontDestroyOnLoad(playerObject);
        startManager.dontDestroyOnLoad.Add(playerObject);
        DontDestroyOnLoad(starfolkParent);
        startManager.dontDestroyOnLoad.Add(starfolkParent);
        LoadEnvironment("Island");
    }
    
    
    public void EnterHome()
    {
        playerIslandSave = GameObject.Find("PlayerIslandParent");
        playerHomeSave = currentPlayerHome.GetComponent<SimpleHome>().interior;
        GameObject sunLight = timeManagerObject.transform.GetChild(0).gameObject;
        GameObject moonLight = timeManagerObject.transform.GetChild(1).gameObject;
        sunLight.SetActive(false);
        moonLight.SetActive(false);
        
        if(!currentPlayerHome.GetComponent<SimpleHome>().isHomeStarted)
        {
            DontDestroyOnLoad(playerIslandSave);
            startManager.dontDestroyOnLoad.Add(playerIslandSave);
            LoadEnvironment("PlayerHome");
            playerIslandSave.SetActive(false);
            playerObject.SetActive(false);
            playerObject.transform.position = new Vector3(0.5f, 0.1f, -3.06f);
            playerObject.SetActive(true);
        }
        else if(currentPlayerHome.GetComponent<SimpleHome>().isHomeStarted)
        {
            LoadEnvironment("SavedPlayerHome");
            playerIslandSave.SetActive(false);
            playerHomeSave.SetActive(true);
           
            
            playerObject.SetActive(false);
            playerObject.transform.position = new Vector3(0.5f, 0.1f, -3.06f);
            playerObject.SetActive(true);
            if(previousePlayerHomeSave != null)
            {
                previousePlayerHomeSave.SetActive(false);
            }
            //UpdatePlayerInventory();
        }
        
        
    }
    public void ExitHome()
    {
        playerHomeSave = currentPlayerHome.GetComponent<SimpleHome>().interior;
        DontDestroyOnLoad(playerHomeSave);
        startManager.dontDestroyOnLoad.Add(playerHomeSave);
        
        timeManager.SunMatchTime();
        LoadEnvironment("SavedIsland");

        playerHomeSave.SetActive(false);

        if(previousePlayerHomeSave != null)
        {
            previousePlayerHomeSave.SetActive(false);
        }
        playerIslandSave.SetActive(true);

        playerObject.SetActive(false);
        playerObject.transform.position = playerHouseExitPoint;
        playerObject.SetActive(true);
        timeManagerObject.SetActive(true);
        GameObject sunLight = timeManagerObject.transform.GetChild(0).gameObject;
        GameObject moonLight = timeManagerObject.transform.GetChild(1).gameObject;
        sunLight.SetActive(true);
        moonLight.SetActive(true);

    }

    public void LoadEnvironment(string environmentToLoad)
    {
        SceneManager.LoadScene(environmentToLoad);

        SceneManager.sceneLoaded += OnSceneLoaded;
        
        
        Wait(1);
        
        Start();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        InitiateEnviornment();
    }
    public GameObject GetSceneIndex(Scene scene, int gameObjectIndex)
    {
        GameObject[] rootGameObjects = scene.GetRootGameObjects(); 
        return rootGameObjects[gameObjectIndex];
    }

    public void CraftingGuideBtn()
    {
        if(!isCraftingBookUIOpen)
        {
            craftingGuideCanvas.SetActive(true);
            isCraftingBookUIOpen = true;
            gameObject.GetComponent<PlayerUIManager>().isKeyPressEnabled = false;
            playerUI.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            craftingGuideCanvas.SetActive(false);
            isCraftingBookUIOpen = false;
            gameObject.GetComponent<PlayerUIManager>().isKeyPressEnabled = true;
            playerUI.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }



    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloraGenerator : MonoBehaviour
{
    public Tilemap placementTiles;
    public Tilemap worldTiles;
    public Tilemap terrainTiles;
    public GameObject tree;

    public GameObject pebble;
    public GameObject twig;
    public GameObject rock1;
    public GameObject rock2;

    public GameObject pebbleParent;
    public GameObject twigParent;
    public GameObject rockParent;
    public GameObject treeParent;
    public GameObject beenUsed;
    public GameObject grassParent;

    public GameObject cow;
    public GameObject cowCluster;

    public GameObject chickenCluster;

    public GameObject sheepCluster;

    public GameObject pig;
    public GameObject pigCluster;

    private int treeLoop = 0;
    private int rockLoop = 0;
    private int twigLoop = 0;
    private int pebbleLoop = 0;
    private int count = 0;

    private GameObject player;
    private GameObject playerIslandParent;

    public GameManager gameManager;

    private bool treeSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        worldTiles = gameObject.GetComponent<TerrainGenerator>().worldTiles;
        terrainTiles = gameObject.GetComponent<TerrainGenerator>().terrainTiles;
        playerIslandParent = GameObject.Find("PlayerIslandParent");
        player = gameManager.newPlayerObject;
    }

    public void GenerateFlora()
    {
        Debug.Log("our player:" + player.name);
        Debug.Log("our slots:" + player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject.name);
        foreach(Transform child in terrainTiles.transform)
        {
            if(child.gameObject.tag == "Grass")
            {
                child.parent = grassParent.transform;
            }
        }
        for(int i = 0; i < 160; i++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            currentTerrain.transform.parent = beenUsed.transform;
            GameObject ourTree = Instantiate(tree, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y +0.51f, currentTerrain.transform.position.z), Quaternion.Euler(0,-90,0));
            ourTree.transform.parent = treeParent.transform;
            ourTree.GetComponent<Tree>().woodParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(6);
            ourTree.GetComponent<Tree>().wood.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
        }
        // gameManager.Wait(1);
        // foreach(Transform child in beenUsed.transform)
        // {
        //     Debug.Log("our parent before is " + child.parent);
        //     child.parent = grassParent.transform;
        //     Debug.Log("our parent after is " + child.parent);
        // }
        gameManager.Wait(1);
        for(int i = 0; i < 53; i++)
        {
            GameObject currentTree = treeParent.transform.GetChild(Random.Range(0, treeParent.transform.childCount)).gameObject;
            currentTree.transform.parent = beenUsed.transform;
            GameObject currentTwig = Instantiate(twig, new Vector3(currentTree.transform.position.x - 0.256f, currentTree.transform.position.y -0.73f, currentTree.transform.position.z + 0.926f), Quaternion.identity);
            currentTwig.transform.parent = twigParent.transform;
            currentTwig.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
        }
        // gameManager.Wait(90);
        // foreach(Transform child in beenUsed.transform)
        // {
        //     Debug.Log("our parent before is " + child.parent);
        //     child.parent = treeParent.transform;
        //     Debug.Log("our parent after is " + child.parent);
        // }
        gameManager.Wait(1);
        for(int i = 0; i < 66; i++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            currentTerrain.transform.parent = beenUsed.transform;
            int index = Random.Range(1, 3);
            Debug.Log("our index is: " + index);
            if(index == 1)
            {
                GameObject ourRock1 = Instantiate(rock1, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y + 0.584f, currentTerrain.transform.position.z), Quaternion.identity);
                ourRock1.transform.parent = rockParent.transform;
                ourRock1.GetComponent<Rock>().stoneParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(7);
                ourRock1.GetComponent<Rock>().ironParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(9);
                ourRock1.GetComponent<Rock>().stone.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
                ourRock1.GetComponent<Rock>().iron.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
            }
            else
            {
                GameObject ourRock2 = Instantiate(rock2, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y + 0.637f, currentTerrain.transform.position.z), Quaternion.identity); 
                ourRock2.transform.parent = rockParent.transform;
                ourRock2.GetComponent<Rock>().stoneParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(7);
                ourRock2.GetComponent<Rock>().ironParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(9);
                ourRock2.GetComponent<Rock>().stone.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
                ourRock2.GetComponent<Rock>().iron.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
            }

        }
        gameManager.Wait(1);
        for(int i =0; i < 30; i++)
        {
           GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            currentTerrain.transform.parent = beenUsed.transform;
            GameObject currentPebble = Instantiate(pebble, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y + 0.5191f, currentTerrain.transform.position.z), Quaternion.identity);
            currentPebble.transform.parent = pebbleParent.transform;
            currentPebble.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
        }
        
    }

    public void GenerateFauna()
    {
        for(int j = 0; j < 13; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            if(currentTerrain.tag == "Grass")
            Instantiate(cow, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity).transform.parent = playerIslandParent.transform;
        }

        for(int j = 0; j < 3; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            if(currentTerrain.tag == "Grass")
            Instantiate(cowCluster, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity).transform.parent = playerIslandParent.transform;;
        } 

        for(int j = 0; j < 6; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            if(currentTerrain.tag == "Grass")
            Instantiate(pig, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity).transform.parent = playerIslandParent.transform;
        } 
        for(int j = 0; j < 2; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            if(currentTerrain.tag == "Grass")
            Instantiate(pigCluster, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity).transform.parent = playerIslandParent.transform;
        } 

        for(int j = 0; j < 3; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            if(currentTerrain.tag == "Grass")
            Instantiate(chickenCluster, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity).transform.parent = playerIslandParent.transform;
        } 

        for(int j = 0; j < 6; j++)
        {
            GameObject currentTerrain = grassParent.transform.GetChild(Random.Range(0, grassParent.transform.childCount)).gameObject;
            Debug.Log("our j is: " + j);
            if(currentTerrain.tag == "Grass")
            {
                GameObject ourSheepCluster = Instantiate(sheepCluster, new Vector3(currentTerrain.transform.position.x, currentTerrain.transform.position.y, currentTerrain.transform.position.z), Quaternion.identity);
                ourSheepCluster.transform.parent = playerIslandParent.transform;
                GameObject sheepOne = ourSheepCluster.transform.GetChild(0).gameObject;
                GameObject sheepTwo = ourSheepCluster.transform.GetChild(1).gameObject;
                GameObject sheepThree = ourSheepCluster.transform.GetChild(2).gameObject;
                sheepOne.GetComponent<ShearSheep>().woolParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(8);
                sheepTwo.GetComponent<ShearSheep>().woolParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(8);
                sheepThree.GetComponent<ShearSheep>().woolParent = GameObject.Find("TerrainGrid").transform.GetChild(0).GetChild(8);
                sheepOne.GetComponent<ShearSheep>().wool.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
                sheepTwo.GetComponent<ShearSheep>().wool.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
                sheepThree.GetComponent<ShearSheep>().wool.GetComponent<PickUps>().inventorySlots = player.transform.Find("PlayerUI/PlayerUICanvas/Inventory/InventoryBackground/Slots").gameObject;
                continue;
            }
            j--;
        } 
    }
}

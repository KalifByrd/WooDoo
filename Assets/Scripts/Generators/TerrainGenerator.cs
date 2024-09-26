using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

public class TerrainGenerator : MonoBehaviour
{
    public Tilemap worldTiles;
    public Tilemap terrainTiles;
    public MapGenerator mapGenerator;
    public MapRenderer mapRenderer;

    public GameObject hill;
    public GameObject hillIn;
    public GameObject hillCorner;
    public GameObject hillMerge;
    public GameObject grass;
    public GameObject water;
    public GameObject grassForWater;
    public GameObject hillForWater;
    public GameObject hillInForWater;
    public GameObject hillCornerForWater;
    public GameObject hillMergeForWater;
    
    
    public void DoneBtn()
    {
        var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GenerateTerrainAndStartGame();

    }
    public void GenerateTerrain()
    {
        int worldMapSize = mapGenerator.mapSize;
        int terrainMapSize = worldMapSize + 1;

        for (int x = -5; x < terrainMapSize +1; x++)
        {
            for (int z = -5; z < terrainMapSize +1; z++)
            {
                TileBase topRightWorldTile = worldTiles.GetTile(terrainTiles.WorldToCell(new Vector3Int(x, 0, z)));
                TileBase bottomRightWorldTile = worldTiles.GetTile(terrainTiles.WorldToCell(new Vector3Int(x, 0, z - 1)));
                TileBase topLeftWorldTile = worldTiles.GetTile(terrainTiles.WorldToCell(new Vector3Int(x - 1, 0, z)));
                TileBase bottomLeftWorldTile = worldTiles.GetTile(terrainTiles.WorldToCell(new Vector3Int(x - 1, 0, z - 1)));
                
                // 3 null tiles 1 second hill tile
                // if(topLeftWorldTile == mapGenerator.secondHillTile && topRightWorldTile == null && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                // {
                //     mapRenderer.SetTileTo(x -2, z-1, mapGenerator.firstHillTile);
                // }

                // 4 grass tiles
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }

                // 4 first hill tiles
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, 0.7f, 1f);
                }

                // 4 second hill tiles
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, 1.9f, 1f);
                }

                // 3 grass tiles 1 hill tile
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 90, 0), 0.5f, 0.6f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 90, 0), 0.5f, 1.8f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 0, 0), 1.5f, 0.6f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 0, 0), 1.5f, 1.8f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.5f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 180, 0), 0.5f, 1.8f, 1.5f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, -90, 0), 1.5f, 0.6f, 1.5f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, -90, 0), 1.5f, 1.8f, 1.5f);
                }

                // 2 grass tiles 2 hill tiles
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 180, 0), 0.5f, 1.8f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 0, 0), 1.5f, 0.6f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 0, 0), 1.5f, 1.8f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 90, 0), 1.0f, 0.6f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 90, 0), 1.0f, 1.8f, 0.5f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, -90, 0), 1.0f, 0.6f, 1.5f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, -90, 0), 1.0f, 1.8f, 1.5f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillMerge, new Vector3(0, -90, 0), 1.0f, 0.6f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hillMerge, new Vector3(0, -90, 0), 1.0f, 1.8f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillMerge, new Vector3(0, 0, 0), 1.0f, 0.6f, 1.0f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillMerge, new Vector3(0, 0, 0), 1.0f, 1.8f, 1.0f);
                }

                // 1 grass tile 3 hill tiles
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 90, 0), 1f, 0.6f, 1f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 90, 0), 1f, 1.8f, 1f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 180, 0), 1f, 0.6f, 1f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 180, 0), 1f, 1.8f, 1f);
                }
                if(topRightWorldTile == mapGenerator.grassTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 0, 0), 1f, 0.6f, 1f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.secondHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, 0, 0), 1f, 1.8f, 1f);
                }
                if(topRightWorldTile == mapGenerator.firstHillTile && topLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, -90, 0), 1f, 0.6f, 1f);
                }
                if(topRightWorldTile == mapGenerator.secondHillTile && topLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.secondHillTile && bottomLeftWorldTile == mapGenerator.secondHillTile)
                {
                    SetTerrainTileTo(x, z, hillIn, new Vector3(0, -90, 0), 1f, 1.8f, 1f);
                }

                // 3 null tiles 1 grass tile
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == null && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);;
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }

                // 2 null tiles 2 grass tiles
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, grass, grass.transform.rotation.eulerAngles, 1f, -0.5f, 1f);
                }

                // 3 null tiles 1 hill tile
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 90, 0), 0.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == mapGenerator.firstHillTile && topRightWorldTile == null && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 0, 0), 1.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, -90, 0), 1.5f, 0.6f, 1.5f);
                }

                // 2 null tiles 2 hill tiles
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.firstHillTile)
                {
                    
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.0f);
                }
                if(topLeftWorldTile == mapGenerator.firstHillTile && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 0, 0), 1.5f, 0.6f, 1.0f);
                }
                if(topLeftWorldTile == mapGenerator.firstHillTile && topRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, 90, 0), 1.0f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hill, new Vector3(0, -90, 0), 1.0f, 0.6f, 1.5f);
                }

                // 2 null tiles 1 grass tile 1 hill tile
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == null && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 90, 0), 0.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == mapGenerator.firstHillTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 0, 0), 1.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.firstHillTile && bottomLeftWorldTile == null && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 90, 0), 0.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, -90, 0), 1.5f, 0.6f, 1.5f);
                }
                if(topLeftWorldTile == null && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.firstHillTile)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 180, 0), 0.5f, 0.6f, 1.5f);
                }
                if(topLeftWorldTile == mapGenerator.firstHillTile && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, 0, 0), 1.5f, 0.6f, 0.5f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == null && bottomLeftWorldTile == mapGenerator.firstHillTile && bottomRightWorldTile == null)
                {
                    SetTerrainTileTo(x, z, hillCorner, new Vector3(0, -90, 0), 1.5f, 0.6f, 1.5f);
                }

                // 4 water tiles
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, grassForWater, grassForWater.transform.rotation.eulerAngles, 1f, -1.7f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }

                // 1 water tile 3 grass tiles
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillInForWater, new Vector3(0, -90, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillInForWater, new Vector3(0, 0, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillInForWater, new Vector3(0, 180, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillInForWater, new Vector3(0, 90, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }

                // 2 water tiles 2 grass tiles
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillForWater, new Vector3(0, -90, 0), 1.0f, -0.6f, 1.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillForWater, new Vector3(0, 90, 0), 1.0f, -0.6f, 0.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillForWater, new Vector3(0, 180, 0), 0.5f, -0.6f, 1.0f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillForWater, new Vector3(0, 0, 0), 1.5f, -0.6f, 1.0f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillMergeForWater, new Vector3(0, -90, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillMergeForWater, new Vector3(0, 0, 0), 1f, -0.6f, 1f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }

                // 3 water tiles 1 grass tile
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.grassTile)
                {
                    SetTerrainTileTo(x, z, hillCornerForWater, new Vector3(0, -180, 0), 0.5f, -0.6f, 1.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.grassTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillCornerForWater, new Vector3(0, 0, 0), 1.5f, -0.6f, 0.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.grassTile && bottomLeftWorldTile == mapGenerator.waterTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillCornerForWater, new Vector3(0, 90, 0), 0.5f, -0.6f, 0.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                if(topLeftWorldTile == mapGenerator.waterTile && topRightWorldTile == mapGenerator.waterTile && bottomLeftWorldTile == mapGenerator.grassTile && bottomRightWorldTile == mapGenerator.waterTile)
                {
                    SetTerrainTileTo(x, z, hillCornerForWater, new Vector3(0, -90, 0), 1.5f, -0.6f, 1.5f);
                    SetTerrainTileTo(x, z, water, water.transform.rotation.eulerAngles, 1f, -0.7f, 1f);
                }
                

                


            }
        }
        gameObject.GetComponent<FloraGenerator>().GenerateFlora();
    }

    private void SetTerrainTileTo(int x, int z, GameObject terrainTileType, Vector3 rotation, float minusx, float y, float minusz)
    {
        GameObject gridedTerrainTile = Instantiate(terrainTileType, new Vector3(x - minusx, y, z - minusz), Quaternion.Euler(rotation.x , rotation.y, rotation.z));
        gridedTerrainTile.transform.parent = terrainTiles.transform;
    }
}

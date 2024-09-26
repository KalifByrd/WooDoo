using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public int offsetX;
    public int offsetY;
    public MapRenderer mapRenderer;
    public TerrainGenerator terrainGenerator;
    public TileBase grassTile, waterTile, firstHillTile, secondHillTile, maxPosTile;
    public int mapSize;
    public NoiseSettings mapSettings;
    public float firstHillHeight = 0.5f, secondHillHeight = 0.6f, waterHeight = 0.4f;
    public float[,] noiseMap;

    private void Start()
    {
        noiseMap = new float[mapSize, mapSize];
        PrepareMap();
    }

    public void DsiableCanvas()
    {
        GameObject.Find("UIcanvas").SetActive(false);
    }
    public void EqualizeMap()
    {
        
        for (int prex = 0; prex < mapSize; prex++)
        {
            for (int prez = 0; prez < mapSize; prez++)
            {
                TileBase currentTile = mapRenderer.map.GetTile(mapRenderer.map.WorldToCell(new Vector3Int(prex, 0, prez)));

                TileBase topTile = mapRenderer.map.GetTile(mapRenderer.map.WorldToCell(new Vector3Int(prex, 0, prez + 1)));
                TileBase bottomTile = mapRenderer.map.GetTile(mapRenderer.map.WorldToCell(new Vector3Int(prex, 0, prez - 1)));
                TileBase leftTile = mapRenderer.map.GetTile(mapRenderer.map.WorldToCell(new Vector3Int(prex - 1, 0, prez)));
                TileBase rightTile = mapRenderer.map.GetTile(mapRenderer.map.WorldToCell(new Vector3Int(prex + 1, 0, prez)));

                if (currentTile == secondHillTile)
                {
                    if(topTile == null || bottomTile == null || leftTile == null || rightTile == null)
                    {
                        mapRenderer.SetTileTo(prex, prez, firstHillTile);
                    }
                }
                if (currentTile == waterTile)
                {
                    if(topTile == null || bottomTile == null || leftTile == null || rightTile == null)
                    {
                        mapRenderer.SetTileTo(prex, prez, grassTile);
                    }
                }
            }
        }
    }
    public void PrepareMap()
    {
        offsetX = UnityEngine.Random.Range(-10000, 10000);
        offsetY = UnityEngine.Random.Range(-10000, 10000);
        
        Debug.Log("Generating map");
        mapRenderer.ClearMap();
        
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                var noise = NoiseHelper.SumNoise(x + offsetX, z + offsetY, mapSettings);
                noiseMap[x, z] = noise;
                if (noise > secondHillHeight)
                {
                    mapRenderer.SetTileTo(x, z, secondHillTile);
                }else if(noise > firstHillHeight)
                {
                    mapRenderer.SetTileTo(x, z, firstHillTile);
                }else if (noise < waterHeight)
                {
                    mapRenderer.SetTileTo(x, z, waterTile);
                }
                else
                {
                    mapRenderer.SetTileTo(x, z, grassTile);
                }
                //Debug.Log("(" + x + ", " + z + ")");
            }
        }
        EqualizeMap();
    }

    public void ShowMaximas()
    {
        var result = NoiseHelper.FindLocalMaxima(noiseMap);
        result = result.Where(pos => noiseMap[pos.x, pos.y] > secondHillHeight).OrderBy(pos => noiseMap[pos.x, pos.y]).Take(20).ToList();
        foreach (var item in result)
        {
            mapRenderer.SetTileTo(item.x, item.y, maxPosTile);
        }
    }

    public void ShowMinimas()
    {
        var result = NoiseHelper.FindLocalMinima(noiseMap);
        result = result.Where(pos => noiseMap[pos.x, pos.y] < waterHeight).OrderBy(pos => noiseMap[pos.x, pos.y]).Take(20).ToList();
        foreach (var item in result)
        {
            mapRenderer.SetTileTo(item.x, item.y, maxPosTile);
        }
    }

}
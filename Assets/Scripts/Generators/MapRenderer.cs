using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapRenderer : MonoBehaviour
{
    public Tilemap map;

    public void ClearMap()
    {
        map.ClearAllTiles();
    }

    public void SetTileTo(int x, int z, TileBase tiletype)
    {
        map.SetTile(map.WorldToCell(new Vector3(x, 0, z)), tiletype);
    }
    
    public void SetTileTo(Vector3 pos, TileBase tiletype)
    {
        map.SetTile(map.WorldToCell(pos), tiletype);
    }

    public Vector3Int getCellposition(Vector3 pos)
    {
        return map.WorldToCell(pos);
    }
}
